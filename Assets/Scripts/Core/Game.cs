using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace Pathmaker.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameObject _ball;
        [SerializeField] private GameObject _gameOverMenu;

        public Action EndingGame;

        public void GameOver()
        {
            _ball.SetActive(false);
            EndingGame?.Invoke();

            _gameOverMenu.SetActive(true);
        }
            
        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}