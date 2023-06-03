using Pathmaker.Core.TriggerableObjects;
using UnityEngine;

namespace Pathmaker.Core
{
    public class Star : MonoBehaviour, Triggerrable
    {
        public void Trigger()
        {
            ServiceLocator.Instance.StarCounter.Add();
            Destroy(gameObject);
        }
    }
}