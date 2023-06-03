using UnityEngine;

namespace Pathmaker.Core
{
    public class Drawing : MonoBehaviour
    {
        [SerializeField] private Input _input;
        [SerializeField] private Line _linePrefab;
        [SerializeField] private float _updateDistance;
        [SerializeField] private LayerMask _ballLayer;

        private Camera _camera;
        private Line _currentLine;
        private Vector2 _lastPoint;

        private bool _isDrawing = false;

        private void Awake() => _camera = Camera.main;

        private void Update()
        {
            if (!_isDrawing)
                return;

            Vector2 mousePosition = _input.GetMousePosition();
            Vector2 worldPosition = _camera.ScreenToWorldPoint(mousePosition);

            if (CheckForBall(worldPosition))
            {
                StopDrawing();
                return;
            }

            if (Vector2.Distance(worldPosition, _lastPoint) >= _updateDistance)
            {
                _lastPoint = worldPosition;
                _currentLine.CreateNewVertex(worldPosition);
            }
        }

        public void StartDrawing(Vector2 startPoint)
        {
            Vector2 worldPosition = _camera.ScreenToWorldPoint(startPoint);

            _currentLine = Instantiate(_linePrefab, worldPosition, Quaternion.identity);
            _currentLine.CreateNewVertex(worldPosition);

            _lastPoint = worldPosition;
            _isDrawing = true;
        }

        public void StopDrawing()
        {
            _currentLine = null;
            _isDrawing = false;
        }

        private bool CheckForBall(Vector2 pos)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(pos, Vector2.right, 0.1f, _ballLayer);

            if (hitInfo.collider != null)
                return true;

            return false;
        }
    }
}