using UnityEngine;
using UnityEngine.InputSystem;

namespace _src.Scripts
{
    [DefaultExecutionOrder(-1)]
    public class InputManager : Singleton<InputManager>
    {
        #region Events
        public delegate void StartTouch(Vector2 position, float time);
        public event StartTouch OnStartTouch;
        public delegate void EndTouch(Vector2 position, float time);
        public event EndTouch OnEndTouch;
        #endregion
        
        private PlayerControls _playerControls;
        private Camera _camera;

        // Awake is called when object is initialized
        private void Awake()
        {
            _playerControls = new PlayerControls();
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }

        // Start is called before the first frame update
        private void Start()
        {
            _playerControls.PlayerInput.PrimaryContact.started += ctx => StartPrimaryTouch(ctx);
            _playerControls.PlayerInput.PrimaryContact.canceled += ctx => EndPrimaryTouch(ctx);
        }

        private void StartPrimaryTouch(InputAction.CallbackContext ctx)
        {
            OnStartTouch?.Invoke(Utils.ScreenToViewport(_camera, _playerControls.PlayerInput.PrimaryPosition.ReadValue<Vector2>()), (float) ctx.startTime);
        }

        private void EndPrimaryTouch(InputAction.CallbackContext ctx)
        {
            OnEndTouch?.Invoke(Utils.ScreenToViewport(_camera, _playerControls.PlayerInput.PrimaryPosition.ReadValue<Vector2>()), (float) ctx.time);
        }

        public Vector2 PrimaryPosition()
        {
            return Utils.ViewportToScreen(_camera, _playerControls.PlayerInput.PrimaryPosition.ReadValue<Vector2>());
        }
    }
}
