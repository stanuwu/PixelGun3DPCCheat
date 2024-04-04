using UnityEngine;

namespace PixelGunCheat.util
{
    public static class PlayerUtil
    {
        public static Vector3 WorldToScreenPoint(Camera camera, Vector3 worldPoint)
        {
            Vector3 screenPoint = camera.WorldToScreenPoint(worldPoint);
            screenPoint.y = Screen.height - screenPoint.y;
            return screenPoint;
        }
        
        public static bool IsVisible(Vector3 screenPoint)
        {
            return screenPoint.z > 0.01f && screenPoint.x > -100f && screenPoint.y > -100f && screenPoint.x < Screen.width + 100 && screenPoint.y < Screen.height + 100;
        }
    }
}