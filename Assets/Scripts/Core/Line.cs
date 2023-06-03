using UnityEngine;
using System.Collections.Generic;

namespace Pathmaker.Core
{
    public class Line : MonoBehaviour
    {
        [SerializeField] private LineRenderer _renderer;
        [SerializeField] private EdgeCollider2D _collider;

        private readonly List<Vector2> _colliderPoints = new List<Vector2>();

        private void Awake() => _collider.transform.position -= transform.position;

        public void CreateNewVertex(Vector2 position)
        {
            _colliderPoints.Add(position);
            _collider.points = _colliderPoints.ToArray();

            ++_renderer.positionCount;
            _renderer.SetPosition(_renderer.positionCount - 1, position);
        }
    }
}