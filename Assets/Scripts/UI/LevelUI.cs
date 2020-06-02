using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestWork
{
    public class LevelUI : MonoBehaviour
    {
        public int NextLevel { get; set; }
        [SerializeField]
        private Button _btnNextLevel = null;
        [SerializeField]
        private Button _btnExit = null;
        private void Start()
        {
            _btnNextLevel.onClick.AddListener(delegate () { OnGoingNextLevel(NextLevel); });
            _btnExit.onClick.AddListener(delegate () { OnGoingNextLevel(0); });
        }

        public void OnGoingNextLevel(int level)
        {
            SceneManager.LoadScene(level);
        }
    }
}
