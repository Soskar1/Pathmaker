using UnityEngine;

namespace Pathmaker.Core
{
    public class Drawing : MonoBehaviour
    {
        [SerializeField] private Line _linePrefab;
        [SerializeField] private float _updateDistance;
        private Camera _camera;

        private Line _currentLine;
        private Vector2 _lastPoint;

        private bool _isDrawing = false;

        private void Awake() => _camera = Camera.main;

        private void Update()
        {
            if (!_isDrawing)
                return;

            Debug.Log("Drawing");
        }

        public void StartDrawing(Vector2 startPoint)
        {
            //_currentLine = Instantiate(_linePrefab, startPoint, Quaternion.identity);
            _isDrawing = true;
        }

        public void StopDrawing()
        {
            _currentLine = null;
            _isDrawing = false;

            Debug.Log("Stop");
        }
    }
}