using UnityEngine;
using System;
using Pathmaker.Core.UI;

namespace Pathmaker.Core
{
    public class StarCounter : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] private Leaderboard _leaderboard;
        private int _stars;

        public Action<int> OnStarGained;

        private void OnEnable() => _game.EndingGame += PostScore;
        private void OnDisable() => _game.EndingGame -= PostScore;

        public void Add()
        {
            ++_stars;
            OnStarGained?.Invoke(_stars);
        }

        private void PostScore() => _leaderboard.SetLeaderboardEntry(_stars);
    }
}