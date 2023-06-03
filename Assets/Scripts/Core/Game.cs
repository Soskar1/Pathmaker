using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace Pathmaker.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverMenu;
        [SerializeField] private Material _material;

        public Action EndingGame;

        private void Awake() => _material.color = UnityEngine.Random.ColorHSV();

        public void GameOver()
        {
            EndingGame?.Invoke();

            _gameOverMenu.SetActive(true);
        }
            
        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}