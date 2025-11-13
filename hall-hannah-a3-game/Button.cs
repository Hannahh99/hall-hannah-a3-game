using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    internal class Button
    {
        Vector2 position;
        Vector2 size;
        string text;
        public Button(Vector2 position, Vector2 size, string text) 
        {
            this.position = position;
            this.size = size;
            this.text = text;
        }

        public void Update()
        {
            ButtonGraphics();
        }
        public void ButtonGraphics()
        {
            Draw.FillColor = Color.Gray;
            Draw.Rectangle(position, size);
            Draw.FillColor = Color.Black;
            Text.Size = 20;
            Text.Draw(text, position.X + 10, position.Y + 10);
        }
        public bool ButtonPressed()
        {
            Vector2 mousePosition = Input.GetMousePosition();
            if (mousePosition.X >= position.X && mousePosition.X <= position.X + size.X && mousePosition.Y >= position.Y && mousePosition.Y <= position.Y + size.Y)
            {
                if (Input.IsMouseButtonPressed(0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
