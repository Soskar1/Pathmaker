using UnityEngine;

namespace Pathmaker.Core.TriggerableObjects
{
    public class Spike : MonoBehaviour, Trigerrable
    {
        public void Trigger() => ServiceLocator.Instance.Game.GameOver();
    }
}