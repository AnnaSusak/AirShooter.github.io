using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AirShooter.Content.Classes.UI
{
    class Bar
    {
        private Texture2D texture;
        private Color color;
        private Vector2 position;
        private int size;   //кол во ячеек
        private int width;  //ширина
        private int height;
        private int widthSection;
        private Rectangle sourceRectangle;
        public Bar(Texture2D texture,  Vector2 position, Color color, int num_sections, int widthSection, int height) 
        {
            this.texture = texture;
            this.color = color;
            this.position = position;
            this.size = num_sections;
            this.width = widthSection;
            this.height = height * num_sections;
            this.widthSection = widthSection;
        }
        public void LoadContent(ContentManager content) 
        {
            texture = content.Load<Texture2D>("healthbar");
        }
        public void Draw(SpriteBatch spriteBatch) 
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            sourceRectangle = new Rectangle(0,0, texture.Width, texture.Height);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
        public void Update(int numScores) 
        {
            width = widthSection * numScores;
            size = numScores;
            return;
        }
    }
}
