using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestWork
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField]
        private Button _btnPlay = null;

        [SerializeField]
        private Button _btnExit = null;

        private void Start()
        {
            _btnPlay.onClick.AddListener(delegate(){ SceneManager.LoadScene(1); });
            _btnExit.onClick.AddListener(delegate () { Application.Quit(); });
        }
    }
}
