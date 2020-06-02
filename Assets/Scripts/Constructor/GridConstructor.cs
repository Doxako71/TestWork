using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TestWork
{
    public enum Items
    {
        Floor,
        Wall,
        Box,
        Point
    }

    public class GridConstructor : BaseGrid
    {
        [SerializeField]
        private Items _item = Items.Floor;
        [SerializeField]
        private Material _wall = null;
        [SerializeField]
        private Material _box = null;
        [SerializeField]
        private Material _point = null;
        [SerializeField]
        private Material _floor = null;

        protected override void InitField()
        {
            for (int i = 0; i < LevelData.Row; ++i)
            {
                for (int j = 0; j < LevelData.Col; ++j)
                {
                    var go = Instantiate(PrefabCell, transform).GetComponent<CellConstructor>();
                    go.transform.position = new Vector3(i, 0f, j);
                    Cells.Add(go);
                    go.NumberCell = Cells.Count - 1;
                }
            }

            for (int i = 0; i < LevelData.Box.Count; ++i)
            {
                var numberCell = LevelData.Box[i];
                Cells[numberCell].GetComponent<MeshRenderer>().material = _box;
            }

            for (int i = 0; i < LevelData.Wall.Count; ++i)
            {
                var numberCell = LevelData.Wall[i];
                Cells[numberCell].GetComponent<MeshRenderer>().material = _wall;
            }

            Cells[LevelData.FinalPoint].GetComponent<MeshRenderer>().material = _point;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    var cell = hit.transform.GetComponent<CellConstructor>();
                    switch (_item)
                    {
                        case Items.Box:
                            hit.transform.GetComponent<MeshRenderer>().material = _box;
                            AddItem(LevelData.Box, cell.NumberCell);
                            ValidCell(LevelData.Wall, cell.NumberCell);
                            break;
                        case Items.Point:
                            hit.transform.GetComponent<MeshRenderer>().material = _point;
                            LevelData.FinalPoint = cell.NumberCell;
                            break;
                        case Items.Wall:
                            hit.transform.GetComponent<MeshRenderer>().material = _wall;
                            AddItem(LevelData.Wall, cell.NumberCell);
                            ValidCell(LevelData.Box, cell.NumberCell);
                            break;
                        case Items.Floor:
                            hit.transform.GetComponent<MeshRenderer>().material = _floor;
                            ValidCell(LevelData.Box, cell.NumberCell);
                            ValidCell(LevelData.Wall, cell.NumberCell);
                            break;
                    }
                }
            }
        }

        private void AddItem(List<int> items, int number)
        {
            if (!items.Contains(number))
            {
                items.Add(number);
            }
        }


        private void ValidCell(List<int> items, int number)
        {
            if (items.Contains(number))
            {
                items.Remove(number);
            }
        }
    }
}
