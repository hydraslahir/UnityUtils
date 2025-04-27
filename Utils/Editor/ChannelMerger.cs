using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

using static HYDRA.EditorUtils;

namespace HYDRA
{
    /// <summary>
    /// Takes up to 4 maps, reads a <see cref="Mapping"/> Channel and writes it to an output.
    /// Allows to create MaskMaps <see cref="https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@13.1/manual/Mask-Map-and-Detail-Map.html"/>
    /// 
    /// R : Metallic
    /// G : AO
    /// B : Detail
    /// A : Smoothness
    /// </summary>
    public class ChannelMerger : EditorWindow
    {
        [MenuItem("Utils/ChannelMerger")]
        public static void ShowExample()
        {
            ChannelMerger wnd = GetWindow<ChannelMerger>();
            wnd.titleContent = new GUIContent("ChannelMerger");
        }

        TextureData red;
        public TextureData Red
        {
            get
            {
                red ??= new TextureData() { mapping = Mapping.R };
                return red;
            }
        }

        TextureData green;
        public TextureData Green
        {
            get
            {
                green ??= new TextureData() { mapping = Mapping.G };
                return green;
            }
        }

        TextureData blue;
        public TextureData Blue
        {
            get
            {
                blue ??= new TextureData() { mapping = Mapping.B };
                return blue;
            }
        }

        TextureData alpha;
        public TextureData Alpha
        {
            get
            {
                alpha ??= new TextureData() { mapping = Mapping.A };
                return alpha;
            }
        }

        private void OnGUI()
        {
            GUILayout.Label("Channel Merger");

            DrawTextureField("Red", Red);
            DrawTextureField("Green", Green);
            DrawTextureField("Blue", Blue);
            DrawTextureField("Alpha", Alpha);

            if (GUILayout.Button("Generate Texture"))
            {
                var textures = new Texture2D[] { Red.Texture, Green.Texture, Blue.Texture, Alpha.Texture, };
                var first = textures.First(c => c != null);
                if (!first)
                {
                    Debug.LogError("Requires at least 1 image");
                    return;
                }

                var outputName = EditorUtility.SaveFilePanel("Output texture", ".", $"{first.name}", "image");
                if (string.IsNullOrEmpty(outputName))
                    return;

                Texture2D outputText = new Texture2D(first.width, first.height, TextureFormat.RGBA32, false);

                var hasRed = Red.Texture != null;
                var hasGreen = Green.Texture != null;
                var hasBlue = Blue.Texture != null;
                var hasAlpha = Alpha.Texture != null;

                for (int i = 0; i < first.width; i++)
                {
                    for (int j = 0; j < first.height; j++)
                    {
                        var color = new Color(
                            Red.GetPixelChanelData(i, j),
                            Green.GetPixelChanelData(i, j),
                            Blue.GetPixelChanelData(i, j),
                            Alpha.GetPixelChanelData(i, j));
                        outputText.SetPixel(i, j, color);
                    }
                }

                outputText.Apply();
                var folder = Path.GetDirectoryName(outputName);
                var name = Path.GetFileNameWithoutExtension(outputName);
                if (hasAlpha)
                {
                    var bytes = outputText.EncodeToPNG();
                    File.WriteAllBytes($"{Path.Combine(folder, name)}.png", bytes);
                }
                else
                {
                    var bytes = outputText.EncodeToJPG();
                    File.WriteAllBytes($"{Path.Combine(folder, name)}.jpg", bytes);
                }

                AssetDatabase.Refresh();
            }
        }
    }
}