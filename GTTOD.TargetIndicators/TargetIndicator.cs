using UnityEngine;

namespace GTTOD.TargetIndicators
{
    public class TargetIndicator : MonoBehaviour
    {
        private Camera MainCamera { get; set; }

        public void Start()
        {
            MainCamera = Camera.main;
        }

        // fixme: this sucks dick
        public void OnGUI()
        {
            var guiPoint = WorldToGuiPoint(transform.position);
            var textureToDraw = Textures.OnScreen;

            var targetX = guiPoint.x;
            var targetY = guiPoint.y;

            if (targetX > Screen.width)
            {
                targetX = Screen.width - 42;
                textureToDraw = Textures.OffScreenRight;
            }

            if (targetX < 0)
            {
                targetX = 10;
                textureToDraw = Textures.OffScreenLeft;
            }

            if (targetY > Screen.height || guiPoint.z < 0)
            {
                targetY = Screen.height - 42;
                textureToDraw = Textures.OffScreenBottom;
            }

            if (targetY < 0)
            {
                targetY = 10;
                textureToDraw = Textures.OffScreenTop;
            }

            GUI.DrawTexture(
                new Rect(targetX, targetY, 32, 32),
                textureToDraw,
                ScaleMode.ScaleToFit,
                true,
                1f,
                Color.green,
                0, 0
            );
        }

        private Vector3 WorldToGuiPoint(Vector3 position)
        {
            var guiPosition = MainCamera.WorldToScreenPoint(position);
            guiPosition.y = Screen.height - guiPosition.y;

            return guiPosition;
        }
    }
}
