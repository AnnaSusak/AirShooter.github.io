using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AirShooter.Content.Classes
{
    class Enemy
    {
        // fields
        protected Texture2D texture;
        private Vector2 position;
        protected int speed;
        private bool isVisible;
        private Rectangle boundingBox;
        private Rectangle destinationRectangle;
        protected float rotation;
        private Weapon weapon;
        public bool IsVisible { get { return isVisible; } set { isVisible = value; } }
        public Weapon Weapon { get { return weapon; } set { weapon = value; } }
        public Rectangle BoundingBox { get { return boundingBox; } }
        // конструктор
        public Enemy(Vector2 position)
        {
            this.position = position;
            texture = null;
            speed = 3;
            rotation = 0;
            weapon = new Weapon(position);
            isVisible = true;
        }
        // Методы
        public virtual void LoadContent(ContentManager content)
        {

            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width - 0, texture.Height - 0);
            boundingBox = destinationRectangle;
            weapon.LoadContent(content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // spriteBatch.Draw(texture, position, Color.White);
            weapon.IsVisible = isVisible;
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width - 20, texture.Height - 30);
            Vector2 origin = new Vector2(destinationRectangle.Width / 2, destinationRectangle.Height / 2);
            spriteBatch.Draw(texture, destinationRectangle, null, Color.White, rotation, origin, SpriteEffects.None, 1);
            weapon.Draw(spriteBatch);
        }
        public virtual void Update(GameTime gameTime) { 
            boundingBox = destinationRectangle;
            position.X -= speed;

            if (position.X <= 0)
            {
                isVisible = false;
            }
            weapon.Position = position;
            weapon.Update();
        }
    }
}
