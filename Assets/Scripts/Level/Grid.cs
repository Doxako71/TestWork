﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestWork
{
    public class Grid : BaseGrid
    {
        public GameObject Player { get; set; }
        public LevelUI UI { get => _ui; set => _ui = value; }
        [SerializeField]
        private LevelUI _ui = null;

        [SerializeField]
        private GameObject _prefabBox = null;
        [SerializeField]
        private GameObject _prefabWall = null;
        [SerializeField]
        private GameObject _level = null;
        

        protected override void Start()
        {
            base.Start();
            _ui.NextLevel = int.Parse(NumberLevel) < ConfigLevel.dataLevels.Count ? int.Parse(NumberLevel)+1  : 0;
        }
        protected override void InitField()
        {
            // Initialize all cells
            for (var i = 0; i < LevelData.Row; ++i)
            {
                for (var j = 0; j < LevelData.Col; ++j)
                {
                    var go = Instantiate(PrefabCell, transform);
                    go.transform.position = new Vector3(i, 0f, j);
                    Cells.Add(go);
                    go.NumberCell = Cells.Count - 1;
                }
            }
            // Creating boxes
            LevelData.Box.ForEach(t => CreateObj(t, Items.Box, _prefabBox));

            // Creating walls
            LevelData.Wall.ForEach(t => CreateObj(t, Items.Wall, _prefabWall));

            // Creating final point
            var finalPoint = Cells[LevelData.FinalPoint];
            finalPoint.gameObject.AddComponent<FinishCell>();
            finalPoint.NumberCell = LevelData.FinalPoint;
        }

        private void CreateObj(int numberCell, Items Items, GameObject _prefab)
        {
            var go = Instantiate(_prefab, _level.transform);
            var cell = Cells[numberCell] as Cell;
            var pos = cell.transform.position;
            pos.y = 0.5f;
            go.transform.position = pos;
            cell.Build = go;
            cell.Item = Items;
        }
    }
}
