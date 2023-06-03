using UnityEngine;

namespace Pathmaker.Core
{
    public class Line : MonoBehaviour
    {
        [SerializeField] private LineRenderer _renderer;

        public void CreateNewVertex(Vector2 position)
        {
            ++_renderer.positionCount;
            _renderer.SetPosition(_renderer.positionCount - 1, position);
        }
    }
}