using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SFML.Graphics;
using SFML.System;

namespace shugiiQOverlay
{
    public static class CreateItems
    {
        public static readonly Font _font = new Font(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Resources",
            "Exo2-SemiBoldItalic.ttf")));
        public static RectangleShape CreateBar(RectangleShape square, int outlineThickness, float barSpeed)
        {
            var rect = new RectangleShape(new Vector2f(square.Size.X + outlineThickness, barSpeed));
            rect.Position = new Vector2f(square.Position.X - outlineThickness,
                square.Position.Y - square.Size.Y - square.OutlineThickness);
            rect.FillColor = square.FillColor;
            return rect;
        }

        public static List<RectangleShape> CreateKeys(int keyAmount, int outlineThickness, float size, float ratioX, float ratioY,
            int margin, RenderWindow window, Color backgroundColor, Color outlineColor)
        {
            //var yPos = 180;
            var width = size;
            var keyList = new List<RectangleShape>();
            var spacing = (window.Size.X - margin * 2 - width * 1);
            for (int i = 0; i < keyAmount; i++)
            {
                var square = new RectangleShape(new Vector2f(size, size));

                square.FillColor = backgroundColor;
                square.OutlineColor = outlineColor;
                square.OutlineThickness = 0;
                square.Origin = new Vector2f(-60, 120);
                square.Position = new Vector2f(margin + outlineThickness + (width + spacing) * i, size);
                keyList.Add(square);
            }
            return keyList;
        }

        public static Text CreateText(string key, RectangleShape square, Color color, bool counter)
        {
            var text = new Text(key, _font);
            if (counter)
                text.CharacterSize = text.CharacterSize = (uint)(23 * square.Size.X / 140);
            else
                text.CharacterSize = (uint)(50 * square.Size.X / 140);
            text.Style = Text.Styles.Bold;
            text.FillColor = color;
            text.Origin = new Vector2f(text.GetLocalBounds().Width / 2f, 32 * square.Size.X / 140f);
            if (counter)
                text.Position = new Vector2f(square.GetGlobalBounds().Left + square.OutlineThickness + square.Size.X / 2f,
                    square.GetGlobalBounds().Top + square.OutlineThickness + square.Size.Y + text.CharacterSize / 3f - 20);
            else
                text.Position = new Vector2f(square.GetGlobalBounds().Left + square.OutlineThickness + square.Size.X / 2f,
                    square.GetGlobalBounds().Top + square.OutlineThickness + square.Size.Y / 3f + 5);

            return text;
        }

        public static Color CreateColor(string s)
        {
            var bytes = s.Split(',').Select(int.Parse).Select(Convert.ToByte).ToArray();
            return new Color(bytes[0], bytes[1], bytes[2], bytes[3]);
        }
    }
}
