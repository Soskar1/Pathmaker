using UnityEngine;
using System.Collections.Generic;

namespace Pathmaker.Core
{
    public class Spawner : MonoBehaviour, IInitializable
    {
        [SerializeField] private List<GameObject> _structures;
        [SerializeField] private Ball _ball;
        [SerializeField] private float _spawnRate;
        [SerializeField] private float _velocityThreshold;
        [SerializeField] private float _offset;

        private bool _canSpawn;
        private float _timer;

        private void Awake() => _timer = _spawnRate;

        public void Initialize() => _canSpawn = true;

        private void Update()
        {
            if (!_canSpawn)
                return;

            if (_timer <= 0)
            {
                _timer = _spawnRate;

                GameObject structure = _structures[Random.Range(0, _structures.Count)];
                Vector2 position = CalculatePosition();

                if (position == Vector2.zero)
                    return;

                Instantiate(structure, position, Quaternion.identity);
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }

        private Vector2 CalculatePosition()
        {
            Vector2 velocity = _ball.GetComponent<Rigidbody2D>().velocity;

            if (velocity.x > _velocityThreshold)
            {
                return (Vector2)_ball.transform.position + velocity.normalized * _offset;
            }

            return Vector2.zero;
        }
    }
}