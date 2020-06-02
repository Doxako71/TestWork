using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


namespace TestWork
{

    [Serializable]
    public class LevelData
    {
        public string NumberLevel { get => _numberLevel; }
        [SerializeField]
        private string _numberLevel = null;

        public int Row { get => _row; }
        [SerializeField]
        private int _row = 0;

        public int Col { get => _col; }
        [SerializeField]
        private int _col = 0;

        public List<int> Wall { get => _wall; set => _wall = value; }
        [SerializeField]
        private List<int> _wall;

        public List<int> Box { get => _box; set => _box = value; }
        [SerializeField]
        private List<int> _box;

        public int FinalPoint { get => _finalPoint; set => _finalPoint = value; }
        [SerializeField]
        private int _finalPoint = 0;
    }

    [CreateAssetMenu]
    public class ConfigLevel : ScriptableObject
    {
        public List<LevelData> dataLevels = new List<LevelData>();
    }
}
