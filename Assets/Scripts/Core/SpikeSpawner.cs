using Pathmaker.Core.TriggerableObjects;
using UnityEngine;

namespace Pathmaker.Core
{
    public class SpikeSpawner : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private Spike _prefab;
        [SerializeField] private float _spawnRate;
        [SerializeField] private Vector2 _offset;
        [SerializeField] private float _velocityThreshold;
        [SerializeField] private int _size;

        private bool _canSpawn = false;

        private float _timer;

        private void Awake() => _timer = _spawnRate;

        private void Update()
        {
            //if (!_canSpawn)
            //    return;

            if (_timer <= 0)
            {
                for (int i = 0; i < _size; i++)
                {
                    Vector2 spawnPosition = CalculateSpawnPosition();

                    if (spawnPosition == Vector2.zero)
                        continue;

                    Instantiate(_prefab, spawnPosition, Quaternion.identity);
                }
                
                _timer = _spawnRate;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }

        private Vector2 CalculateSpawnPosition()
        {
            Vector2 velocity = _ball.GetComponent<Rigidbody2D>().velocity;

            if (Mathf.Abs(velocity.x) > _velocityThreshold)
                return (Vector2)_ball.transform.position + new Vector2(velocity.normalized.x * _offset.x, velocity.normalized.y * _offset.y + Random.Range(-_offset.y, _offset.y));

            return Vector2.zero;
        }
    }
}