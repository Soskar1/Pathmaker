using Pathmaker.Core.TriggerableObjects;
using UnityEngine;
using System.Collections;

namespace Pathmaker.Core
{
    public class Ball : MonoBehaviour, IInitializable
    {
        [SerializeField] private Game _game;
        [SerializeField] private Rigidbody2D _rb2d;
        [SerializeField] private float _velocityThreshold;
        [SerializeField] private TrailRenderer _trail;
        [SerializeField] private float _velocityTrailThreshold;

        [SerializeField] private SpriteRenderer _faceRenderer;
        [SerializeField] private Sprite _happyFace;
        [SerializeField] private Sprite _notSatisfiedFace;
        [SerializeField] private Sprite _deadFace;

        [SerializeField] private GroundCheck _groundCheck;

        [SerializeField] private float _dieTime;

        private bool _gameOver = true;

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
                {
                    _trail.enabled = true;
                    _faceRenderer.sprite = _happyFace;
                }
            }
            else
            {
                if (_trail.enabled)
                {
                    _trail.enabled = false;
                    _faceRenderer.sprite = _notSatisfiedFace;
                }
            }

            if (_rb2d.velocity.magnitude <= _velocityThreshold &&
                (_groundCheck.CheckForGround(Vector2.up) ||
                _groundCheck.CheckForGround(Vector2.right) ||
                _groundCheck.CheckForGround(Vector2.down) ||
                _groundCheck.CheckForGround(Vector2.left)))
                    StartCoroutine(DeathTimer());
        }

        private IEnumerator DeathTimer()
        {
            yield return new WaitForSeconds(_dieTime);

            if (_rb2d.velocity.magnitude <= _velocityThreshold)
                _game.GameOver();
        }

        private void Deactivate()
        {
            _rb2d.velocity = Vector2.zero;
            _rb2d.isKinematic = true;

            _gameOver = true;
            _faceRenderer.sprite = _deadFace;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Triggerrable triggerableObject))
                triggerableObject.Trigger();
        }
    }
}