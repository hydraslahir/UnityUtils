using UnityEngine;

namespace HYDRA
{
    public class TextureData
    {
        public Texture2D Texture;
        public bool Inverse;
        public Mapping mapping;

        public float GetPixelChanelData(int x, int y)
        {
            if (!Texture)
                return 0;
            switch (mapping)
            {
                case Mapping.R:
                    return Texture.GetPixel(x, y).r;
                case Mapping.G:
                    return Texture.GetPixel(x, y).g;
                case Mapping.B:
                    return Texture.GetPixel(x, y).b;
                case Mapping.A:
                    return Texture.GetPixel(x, y).a;
            }
            return 0;
        }
    }
}