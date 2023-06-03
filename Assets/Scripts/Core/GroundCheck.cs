using UnityEngine;

namespace Pathmaker.Core
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private float _distance;
        [SerializeField] private LayerMask _groundLayers;

        public bool CheckForGround()
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _distance, _groundLayers);

            if (hitInfo.collider != null)
                return true;

            return false;
        }
    }
}