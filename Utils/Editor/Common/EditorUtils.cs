using UnityEditor;
using UnityEngine;

namespace HYDRA
{
    public static class EditorUtils
    {
        static GUIStyle textureStyle;
        static GUIStyle TextureStyle
        {
            get
            {
                if (textureStyle == null)
                    textureStyle = new GUIStyle(GUI.skin.label)
                    {
                        alignment = TextAnchor.UpperCenter,
                        fixedWidth = 70
                    };
                return textureStyle;
            }
        }

        public static void DrawTextureField(string name, TextureData data)
        {
            GUILayout.Label(name, TextureStyle);

            GUILayout.BeginHorizontal();
            data.Texture = (Texture2D)EditorGUILayout.ObjectField(data.Texture, typeof(Texture2D), false, GUILayout.Width(70), GUILayout.Height(70));

            GUILayout.BeginVertical();
            data.Inverse = GUILayout.Toggle(data.Inverse, "Inverse");
            data.mapping = (Mapping)EditorGUILayout.EnumPopup("Mapping", data.mapping);
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            GUILayout.Space(15);
        }
    }
}