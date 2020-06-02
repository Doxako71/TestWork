using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestWork
{
    public class PlayerController : MonoBehaviour
    {
        public Grid Grid { get => _grid; set => _grid = value; }
        [SerializeField]
        private Grid _grid = null;

        private Vector3 _newPos;
        private Cell _nextCell;
        private Cell _currentCell;

        private void Awake()
        {
            _grid.Player = gameObject;
            gameObject.transform.position = _grid.StartPos;
        }

        private void Start()
        {
            _newPos = Vector3.zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            _currentCell = other.GetComponent<Cell>();
        }

        private void Update()
        {
            Move();

            // Restart level
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // Return to Main menu
            if (Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene(0);
        }

        private void Move()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ValidateMove(1);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ValidateMove(-1);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ValidateMove(-_grid.LevelData.Col);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ValidateMove(_grid.LevelData.Col);
            }
        }

        /// <summary>
        /// Checks the next step for a wall or box
        /// </summary>
        /// <param name="step">Up = 1, Down = -1, Left = -Column height, Right = Column height </param>
        private void ValidateMove(int step)
        {
            var i = _currentCell.NumberCell + step;
            _nextCell = _grid.Cells[i] as Cell;

            if (_nextCell.Item == Items.Wall)
            {
                return;
            }

            if (_nextCell.Item == Items.Box)
            {
                var j = _grid.Cells[i + step] as Cell;
                if (j.Item == Items.Box || j.Item == Items.Wall)
                {
                    return;
                }

                var posBuild = j.transform.position;
                posBuild.y += 0.5f;
                j.Build = _nextCell.Build;
                j.Item = Items.Box;
                j.Build.transform.position = posBuild;
                _nextCell.Build = null;
                _nextCell.Item = Items.Floor;
            }

            
            _newPos = _nextCell.transform.position;
            _newPos.y += 0.5f;
            transform.position = _newPos;
        }
    }
}