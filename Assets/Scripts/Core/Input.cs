using UnityEngine;

namespace Pathmaker.Core
{
    public class Input : MonoBehaviour
    {
        private Controls _controls;

        private void OnEnable() => _controls.Enable();
        private void OnDisable() => _controls.Disable();
        private void Awake() => _controls = new Controls();
    }
}