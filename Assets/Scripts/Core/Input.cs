using UnityEngine;

namespace Pathmaker.Core
{
    public class Input : MonoBehaviour
    {
        public Controls Controls { get; private set; }

        public void Initialize() => Controls = new Controls();
        public void Enable() => Controls.Enable();
        public void Disable() => Controls.Disable();

        public Vector2 GetMousePosition() => Controls.Brush.MousePosition.ReadValue<Vector2>();
    }
}