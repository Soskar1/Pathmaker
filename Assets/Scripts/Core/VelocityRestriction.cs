using UnityEngine;

namespace Pathmaker.Core
{
    public class VelocityRestriction : MonoBehaviour
    {
        [SerializeField] private float _maxVelocity;
        [SerializeField] private Rigidbody2D _rigidbody;

        private void Update()
        {
            if (_rigidbody.velocity.x > _maxVelocity)
                _rigidbody.velocity = new Vector2(_maxVelocity, _rigidbody.velocity.y);
        }
    }
}