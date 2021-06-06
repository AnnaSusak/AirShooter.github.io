using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AirShooter.Content.Classes
{
    class Mine
    {
        // fields

        int speed;
        Texture2D texture;
        Vector2 position;
        private bool isVisible;
        //колизия
        private Rectangle boundingBox;
        //свойства
        public Rectangle BoundingBox{get{ return boundingBox; } }
        public bool IsVisible { get { return isVisible; } }
        // конструктор
        public Mine()
        {
            texture = null;
            isVisible = true;
            position = new Vector2(200, 300);
            speed = 5;
        }
        public Mine(Vector2 position, int speed)
        {
            this.speed = speed;
            texture = null;
            this.position =position;
            isVisible = true;
        }
        // methods
        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("mine");
        }
        public void Update() 
        {
            position.X -= speed;
            if (position.X<=0)
            {
                position.X = 900;
                isVisible = false;
            }
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
