using UnityEngine;

namespace Pathmaker.Core
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private float _distance;
        [SerializeField] private LayerMask _groundLayers;

        public bool CheckForGround(Vector2 direction)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, _distance, _groundLayers);

            if (hitInfo.collider != null)
                return true;

            return false;
        }
    }
}