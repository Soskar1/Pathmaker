using UnityEngine;
using UnityEngine.InputSystem;

namespace Pathmaker.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Input _input;
        [SerializeField] private Drawing _drawing;

        private void OnEnable()
        {
            if (_input.Controls == null)
                _input.Initialize();

            _input.Controls.Brush.Draw.performed += Draw;
            _input.Controls.Brush.Draw.canceled += Draw;

            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Controls.Brush.Draw.performed -= Draw;
            _input.Controls.Brush.Draw.canceled -= Draw;

            _input.Disable();
        }

        private void Draw(InputAction.CallbackContext ctx) {
            if (ctx.performed)
                _drawing.StartDrawing(_input.GetMousePosition());
            else if (ctx.canceled)
                _drawing.StopDrawing();
        }
    }
}