using System;
using UnityEngine;

namespace PixelGunCheat.util
{
    public static class Renderer
    {
        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);
        public static Material Mat;
        public static Color Color
        {
            get { return GUI.color; }
            set { GUI.color = value; }
        }

        public static void DrawLine(Vector2 from, Vector2 to, float thickness, Color color)
        {
            Color = color;
            DrawLine(from, to, thickness);
        }

        public static void DrawLine(Vector2 from, Vector2 to, float thickness)
        {
            var delta = (to - from).normalized;
            var angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
            GUIUtility.RotateAroundPivot(angle, from);
            DrawBox(from, Vector2.right * (from - to).magnitude, thickness);
            GUIUtility.RotateAroundPivot(-angle, from);
        }

        public static void DrawSquare(Vector2 position, Vector2 size, Color color)
        {
            Color = color;
            GUI.DrawTexture(new Rect(position.x, position.y, size.x, size.y), Texture2D.whiteTexture);
        }

        public static void DrawCenteredSquare(Vector2 position, Vector2 size, Color color)
        {
            Color = color;
            GUI.DrawTexture(new Rect(position.x - (size.x / 2), position.y - (size.y / 2), size.x, size.y), Texture2D.whiteTexture);
        }

        public static void DrawCenteredBoxShadow(Vector2 position, Vector2 size, Color color, float thickness)
        {
            DrawCenteredBox(new Vector2(position.x + 2, position.y + 2), size, Color.black, thickness);
            DrawCenteredBox(position, size, color, thickness);
        }
        
        public static void DrawCenteredBox(Vector2 position, Vector2 size, Color color, float thickness)
        {
            Color = color;
            DrawBox(new Vector2(position.x - size.x / 2, position.y - size.y / 2), size, thickness);
        }
        
        public static void DrawBox(Vector2 position, Vector2 size, float thickness)
        {
            GUI.DrawTexture(new Rect(position.x, position.y, size.x, thickness), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y, thickness, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x + size.x, position.y, thickness, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y + size.y, size.x + thickness, thickness), Texture2D.whiteTexture);
        }

        public static void DrawStringShadow(Vector2 position, string label, Color color, bool centered = true)
        {
            DrawString(new Vector2(position.x + 2, position.y + 2), label, Color.black, centered);
            DrawString(position, label, color, centered);
        }
        
        public static void DrawString(Vector2 position, string label, Color color, bool centered = true)
        {
            Color = color;
            DrawString(position, label, centered);
        }

        public static void DrawString(Vector2 position, string label, bool centered = true)
        {
            var content = new GUIContent(label);
            var size = StringStyle.CalcSize(content);
            var upperLeft = centered ? position - size / 2f : position;
            GUI.Label(new Rect(upperLeft, size), content);
        }

        public static void InitMat()
        {
            Material mat = new Material(Shader.Find("Hidden/Internal-Colored"));
            mat.hideFlags = HideFlags.HideAndDontSave;
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            mat.SetInt("_ZWrite", 0);
            Mat = mat;
            GUI.skin.label.fontSize = 48;
            StringStyle.fontSize = 48;
        }

        public static float GetScaleFactor()
        {
            return (Screen.width / 1920f + Screen.height / 1080f) / 2f;
        }
        
        public static int ScaleValInt(int val)
        {
            return Mathf.RoundToInt(val * GetScaleFactor());
        }
        
        public static float ScaleValFloat(float val)
        {
            return val * GetScaleFactor();
        }

        public static void SetFontSize(int size)
        {
            GUI.skin.label.fontSize = size;
            StringStyle.fontSize = size;
        }
    }
}