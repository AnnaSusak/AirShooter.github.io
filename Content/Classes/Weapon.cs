using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AirShooter.Content.Classes
{
    class Weapon
    {
        //поля
        protected List<Bullet> bulletList=new List<Bullet>();
        protected int bulletSpeed;
        protected Texture2D texture;
        private Vector2 position;
        private bool isVisible;
        private int delay;
        private int bulletDamage;
        protected Texture2D textureBullet;
        public Vector2 Position { get { return position; } set { position = value; } }
        public bool IsVisible { get { return isVisible; } set { isVisible = value; } }
        public List<Bullet> BulletList { get { return bulletList; } }
        //конструктор
        public Weapon(Vector2 position)
        {
            this.position = position;
            delay = 20;
        }
        //методы
        public void LoadContent(ContentManager content)
        {
            textureBullet = content.Load<Texture2D>("laser");
           /* for (int i = 0; i < 20; i++)
            {
                Bullet bullet = new Bullet(textureBullet, position);
                bullet.Speed = 3;
                bulletList.Add(bullet);
            }*/
            
        }
        public void Update()
        {
            Shoot();
            foreach (var bullet in bulletList)
            {
                bullet.Update();
            }
            // cleaning the list
            for (int i = 0; i < bulletList.Count; i++)
            {
                if (!bulletList[i].IsVisible)
                {
                    bulletList.RemoveAt(i);
                    i--;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in bulletList)
            {
                bullet.IsVisible = true;
                bullet.Draw(spriteBatch);
            }
        }
        public void Shoot()
        {
            //Имитация задержки
            if (delay>=0)
            {
                delay--;
            }
            //стрельба
            if (delay<=0)
            {
                if (bulletList.Count<20)//сколько есть патронов
                {
                    //выстрел
                    Vector2 bullet_pos = new Vector2(position.X-60, position.Y-30);
                    Bullet bullet = new Bullet(textureBullet, bullet_pos);
                    bullet.Speed = -9;
                    bulletList.Add(bullet);
                }
            }
            //сброс данных
            if (delay==0)
            {
                delay = 20;
            }
        }
    }
}
