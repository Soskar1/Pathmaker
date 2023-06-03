using UnityEngine;
using System;
using System.Collections;

namespace Pathmaker.Core
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private float _updateRate;
        [SerializeField] private Transform _ball;

        private int _score = 0;
        private Vector2 _previousPosition;

        public Action<int> OnGainedPoints;

        private void Awake() => StartCoroutine(GetPositionDifference());

        private IEnumerator GetPositionDifference()
        {
            _previousPosition = _ball.position;

            yield return new WaitForSeconds(_updateRate);

            Add((int)Mathf.Abs(_ball.position.x - _previousPosition.x));
            StartCoroutine(GetPositionDifference());
        }

        private void Add(int points)
        {
            _score += points;
            OnGainedPoints?.Invoke(_score);
        }
    }
}