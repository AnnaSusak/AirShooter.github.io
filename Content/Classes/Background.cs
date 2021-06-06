using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AirShooter.Content.Classes
{
    class Background
    {
        int speed;
        Texture2D texture;
        Vector2 position;
        Vector2 position2;
        public Background()
        {
            speed = 3;
            texture = null;
            position = new Vector2(0, 0);
            position2 = new Vector2(-800, 0);
        }
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("mainbackground");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(texture, position2, Color.White);
        }
        public void Update() 
        {
            position.X += speed;
            position2.X += speed;
            if (position.X>=800)
            {
                position.X = 0;
                position2.X = -800;
            }
        }
    }
}
