using Pathmaker.Core.TriggerableObjects;
using UnityEngine;

namespace Pathmaker.Core
{
    public class Ball : MonoBehaviour, IInitializable
    {
        [SerializeField] private Game _game;
        [SerializeField] private Rigidbody2D _rb2d;
        [SerializeField] private float _velocityThreshold;
        [SerializeField] private TrailRenderer _trail;
        [SerializeField] private float _velocityTrailThreshold;

        private bool _gameOver = true;

        private float _timer = 2f;

        private void OnEnable() => _game.EndingGame += Deactivate;
        private void OnDisable() => _game.EndingGame -= Deactivate;

        public void Initialize() => _gameOver = false;

        private void Update()
        {
            if (_gameOver)
                return;

            if (_rb2d.velocity.magnitude >= _velocityTrailThreshold)
            {
                if (!_trail.enabled)
                    _trail.enabled = true;
            }
            else
            {
                if (_trail.enabled)
                    _trail.enabled = false;
            }

            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                return;
            }

            if (_rb2d.velocity.magnitude <= _velocityThreshold)
                _game.GameOver();
        }

        private void Deactivate()
        {
            _rb2d.velocity = Vector2.zero;
            _rb2d.isKinematic = true;

            _gameOver = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Triggerrable triggerableObject))
                triggerableObject.Trigger();
        }
    }
}