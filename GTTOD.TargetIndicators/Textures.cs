using Reactor.API.Storage;
using UnityEngine;

namespace GTTOD.TargetIndicators
{
    internal class Textures
    {
        internal static Texture2D OffScreenLeft { get; private set; }
        internal static Texture2D OffScreenRight { get; private set; }
        internal static Texture2D OffScreenTop { get; private set; }
        internal static Texture2D OffScreenBottom { get; private set; }
        internal static Texture2D OnScreen { get; private set; }

        internal static void Initialize(FileSystem fs)
        {
                OffScreenLeft = new Texture2D(1, 1);
                OffScreenRight = new Texture2D(1, 1);
                OffScreenTop = new Texture2D(1, 1);
                OffScreenBottom = new Texture2D(1, 1);
                OnScreen = new Texture2D(1, 1);

                ImageConversion.LoadImage(OffScreenLeft, fs.ReadAllBytes("offscreen_left.png"));
                ImageConversion.LoadImage(OffScreenRight, fs.ReadAllBytes("offscreen_right.png"));
                ImageConversion.LoadImage(OffScreenTop, fs.ReadAllBytes("offscreen_top.png"));
                ImageConversion.LoadImage(OffScreenBottom, fs.ReadAllBytes("offscreen_bottom.png"));
                ImageConversion.LoadImage(OnScreen, fs.ReadAllBytes("onscreen.png"));
        }
    }
}
