using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AirShooter.Content.Classes
{
    class Laser
    {
        private int speed;
        private Texture2D texture;
        private Vector2 position;
        
        public Laser()
        {
            speed = 5;
            texture = null;
            position = new Vector2(200, 300);
        }
        public void LoadContent(ContentManager content)
        {
           texture = content.Load<Texture2D>("laser");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
