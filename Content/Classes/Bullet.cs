using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AirShooter.Content.Classes
{
    [Serializable]
    public class Bullet
    {
        // fields
        private Vector2 position;
        private Texture2D texture;
        private int speed;
        private bool isVisible;
        private Rectangle rectangle;
        // Колизия
        private Rectangle boundingBox;
        private Vector2 size; // size of bullet
        //свойства
        public Rectangle BoundingBox { get { return boundingBox; } }
        public int Speed{ set{ speed = value; } }
        public bool IsVisible { get { return isVisible; } set { isVisible = value; } }
        //Конструктор
        public Bullet(Texture2D texture, Vector2 position)
        {
            speed = 0;
            this.texture = texture;
            isVisible = true;
            this.position = position;
            size = new Vector2(10, 10);
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }
        public Bullet() { }
        //методы
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("laser");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(texture, rectangle, Color.White);
            }
        }
        public void Update()
        {
            position.X += speed;
            rectangle = new Rectangle((int) position.X, (int) position.Y, 30, 30);
            if (position.X >= 800 || position.X<= texture.Width-10)
            {
                isVisible = false;
            }
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
    }
}
