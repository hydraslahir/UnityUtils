using System;
using UnityEditor;
using UnityEngine;

namespace HYDRA
{
    public static class EditorUtils
    {
        public static void DrawTextureField(string name, TextureData data)
        {
            GUILayout.Label(name);

            GUILayout.BeginHorizontal();
            data.Texture = (Texture2D)EditorGUILayout.ObjectField(data.Texture, typeof(Texture2D), false, GUILayout.Width(70), GUILayout.Height(70));

            GUILayout.BeginVertical();
            DrawToggleFor(ref data.Inverse, "Inverse");
            data.mapping = (Mapping)EditorGUILayout.EnumPopup("Mapping", data.mapping);
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            GUILayout.Space(15);
        }

        public static readonly float HORIZONTAL_INDENT = 10F;
        /// <summary>
        /// Indents whatever GUI within.
        /// 
        /// Indent(()=>
        /// { 
        ///     GUILayout.Label("...")
        /// });
        /// </summary>
        public static void Indent(Action action)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(HORIZONTAL_INDENT);
            GUILayout.BeginVertical();
            action();
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }

        public static void DrawToggleFor(ref bool toggle, string name)
        {
            toggle = GUILayout.Toggle(toggle, name);
        }

        public static void DrawInformationFor(GameObject go)
        {
            GUILayout.Label(go.name);
            if (GUILayout.Button("Select"))
                Selection.activeGameObject = go;
        }
    }
}