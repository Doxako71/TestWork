using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestWork
{
    /// <summary>
    /// Basic abstract class for all grid types
    /// </summary>
    public abstract class BaseGrid : MonoBehaviour
    {
        /// <summary>
        /// Level data from the asset
        /// </summary>
        public LevelData LevelData { get; set; }

        /// <summary>
        /// Starting position of the player
        /// </summary>
        public Vector3 StartPos { get => _startPos; set => _startPos = value; }
        [SerializeField]
        private Vector3 _startPos;

        [SerializeField]
        protected string NumberLevel;
        [SerializeField]
        protected GameObject PrefabCell;

        /// <summary>
        /// Asset with levels data
        /// </summary>
        [SerializeField]
        protected ConfigLevel ConfigLevel;
        
        public List<BaseCell> Cells { get; set; }
        protected virtual void Start()
        {
            Cells = new List<BaseCell>();
            LevelData = ConfigLevel.dataLevels.ToList().Where(t => t.NumberLevel.Equals(NumberLevel)).FirstOrDefault();
            InitField();
        }

        protected abstract void InitField();
    }
}
