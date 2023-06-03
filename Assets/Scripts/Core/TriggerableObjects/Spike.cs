using UnityEngine;

namespace Pathmaker.Core.TriggerableObjects
{
    public class Spike : MonoBehaviour, Triggerrable
    {
        public void Trigger() => ServiceLocator.Instance.Game.GameOver();
    }
}