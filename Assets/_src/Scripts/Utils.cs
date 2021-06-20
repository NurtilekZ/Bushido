using UnityEngine;
using UnityEngine.InputSystem;

namespace _src.Scripts
{
    public class Utils : MonoBehaviour
    {
        public static Vector3 ScreenToViewport(Camera camera, Vector3 position)
        {
            return camera.ScreenToViewportPoint(position);
        }
        
        public static Vector3 ViewportToScreen(Camera camera, Vector3 position)
        {
            return camera.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        }
    }
}