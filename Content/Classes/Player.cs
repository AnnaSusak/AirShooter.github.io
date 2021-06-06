using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml.Serialization;
namespace AirShooter.Content.Classes
{
    [Serializable]
    public class Player
    {
        // fields
        int speed;
        private Texture2D texture;
        private Vector2 position;
        private float timer;
        private float interval;
        private Vector2 origin;
        private int currentFrame;
        private int spriteWidth;
        private int spriteHeight;
        private Rectangle sourceRectangle;
        private float bulletDelay; // задержка
        

        //data
        private int score;
        private int health;
        private int record;
        
        //weapon
        Texture2D textureBullet;
        // bullets shop
        private List<Bullet> bulletlist = new List<Bullet>();
        // свойства
        public int Record { get { return record; } set { record = value; } }
        public int Score { get { return score; } set { score = value; } }
        public int Health { get { return health; } set { health = value; } }
        public List<Bullet> BulletList { get { return bulletlist; } }
        public Rectangle BoundingBox { get; set; }
        // конструктор
        public Player()
        {
            score = 0;
            health = 30;
            timer = 0;
            interval = 10;
            currentFrame = 1;
            spriteHeight = 90;
            spriteWidth = 230;
            origin = Vector2.Zero;
            position = new Vector2(0, 0);
            texture = null;
            speed = 5;
            bulletDelay = 10;
        }
        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("player");
            textureBullet = manager.Load<Texture2D>("laser");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            for (int i = 0; i < bulletlist.Count; i++)
            {
                bulletlist[i].Draw(spriteBatch);
            }
        }
        public void Reset()
        {
            score = 0;
            health = 30;
            timer = 0;
            interval = 10;
            currentFrame = 1;
            spriteHeight = 90;
            spriteWidth = 230;
            origin = Vector2.Zero;
            position = new Vector2(100, 200);
            speed = 5;
            bulletDelay = 10;
        }
        public void Update()
        {
            BoundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            KeyboardState keyState = Keyboard.GetState();
            Vector2 pos = new Vector2(position.X + 95, position.Y + 25);
            if (score > record)
            {
                record = score;
            }
            if (keyState.IsKeyDown(Keys.Space))
            {
                PlayerShoot();
            }
            if (keyState.IsKeyDown(Keys.Q))
            {
                position.Y += speed;
            }
            if (keyState.IsKeyDown(Keys.W))
            {
                position.Y -= speed;
            }
            if (keyState.IsKeyDown(Keys.E))
            {
                position.X -= speed;
            }
            if (keyState.IsKeyDown(Keys.R))
            {
                position.X += speed;
            }
            // Стенки
            if (position.X <= 0)
            {
                position.X = 0;
            }
            if (position.Y <= 0)
            {
                position.Y = 0;
            }
            if (position.X + texture.Width >= 800)
            {
                position.X = 800 - texture.Width;
            }
            if (position.Y + texture.Height >= 480)
            {
                position.Y = 480 - texture.Height;
            }
            UpdateBullets();
   /*         float t = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            timer += t / 0;
            if (timer>interval)
            {
                currentFrame++;
                Console.WriteLine("djfhfhfkdfkjhgnvndkdkjfdnkffkhfsvfsdlhd");
                timer = 0;
            }
            if (currentFrame==8)
            {
                currentFrame = 0;
                Console.WriteLine("djfhfhfkdfkjhgnvndkdkjfdnkffkhfsvfsdlhd");
            }
            sourceRectangle = new Rectangle(spriteWidth*currentFrame, 0 , spriteWidth, spriteHeight);*/
        }
        public void UpdateBullets()
        {
            //оружка сдвиг патронов
            for (int i = 0; i < bulletlist.Count; i++)
            {
                bulletlist[i].Update();
            }
            //очистка листа
            for (int i = 0; i < bulletlist.Count; i++)
            {
                if (!bulletlist[i].IsVisible)
                {
                    bulletlist.RemoveAt(i);
                    i--;
                }
            }
        }
        public void PlayerShoot()
        {
            //Имитация задержки
            if (bulletDelay>=0)
            {
                bulletDelay--;
            }
            //стрельба
            if (bulletDelay<=0)
            {
                if (bulletlist.Count<20)//сколько есть патронов
                {
                    // выстрел
                    Vector2 bullet_pos = new Vector2(position.X + texture.Width / 2 - 4, position.Y);
                    Bullet bullet = new Bullet(textureBullet, bullet_pos);
                    bullet.Speed = 10;
                    bulletlist.Add(bullet);
                }
            }

            //сброс данных
            if (bulletDelay==0)
            {
                bulletDelay = 10;
            }
        }
        public void AddScores(int scores) 
        {
            if (scores >  0)
            {
                Score += scores;
            }
        }
        public void GetDamage(int damage) 
        {
            Health -= damage;
        }

    }
}
