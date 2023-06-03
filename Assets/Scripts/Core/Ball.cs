using Pathmaker.Core.TriggerableObjects;
using UnityEngine;

namespace Pathmaker.Core
{
    public class Ball : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Trigerrable triggerableObject))
                triggerableObject.Trigger();
        }
    }
}