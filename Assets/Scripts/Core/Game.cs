using UnityEngine;
using System;

namespace Pathmaker.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameObject _ball;

        public Action EndingGame;

        public void GameOver()
        {
            _ball.SetActive(false);
            EndingGame?.Invoke();
        }
    }
}