using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AirShooter.Content.Classes
{
    class Explosion
    {
        //поля
        private Texture2D texture;
        private Vector2 position;
        private float timer; // накапливает время
        private float interval; // время между кадрами
        private Vector2 origin;
        private int currentFrame;
        private int spriteWidth;
        private int spriteHeight;
        private Rectangle sourceRectangle;
        private bool isVisible;

        // свойства
        public bool IsVisible{ get { return isVisible; } }
        //конструктор
        public Explosion(Vector2 position)
        {
            this.position = position;
            texture = null;
            timer = 0;
            interval = 20;
            currentFrame = 1;
            spriteHeight = 117;
            spriteWidth = 130;
            isVisible = true;
            origin = Vector2.Zero;
        }
        //методы
        public void LoadContent(ContentManager content) 
        {
           texture= content.Load<Texture2D>("explosion");
        }
        public void Update(GameTime gameTime) 
        {
            //время кадра в милисек
            float t = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            timer += t/10;
            if(timer > interval)//таймер переполнился
            {
                currentFrame++;
                timer = 0;
            }
            //если дошли до 11 кадра включить нулевой=LOOP
            if (currentFrame == 11)
            {
                currentFrame = 0;
                isVisible = false;
            }
            sourceRectangle = new Rectangle(spriteWidth*currentFrame, 0, spriteWidth, spriteHeight);
        }
        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, 0, origin, 1, SpriteEffects.None, 0);
        }
    }
}
