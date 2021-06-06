using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AirShooter.Content.Classes.UI
{
    class EnemyParty
    {
        private List<Enemy> enemies = new List<Enemy>();
        private ContentManager manager;
        public List<Enemy> Enemies { get { return enemies; } set { enemies = value; } }
        public EnemyParty()
        {
            for (int i = 0; i < 10; i++)
            {
                Vector2 pos = new Vector2( new Random().Next(800, 4000), new Random().Next(0, 570));
                Enemy enemy = new EnemyShip(pos);
                enemies.Add(enemy);
            }
        }
        public void LoadContent(ContentManager content)
        {
            foreach(var e in enemies)
            {
                e.LoadContent(content);
                
            }
            manager = content;
        }
        public void Update(GameTime gameTime)
        {
            foreach (var e in enemies)
            {
                e.Update(gameTime);
            }
            //cleaning the list
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].IsVisible)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }
            if (enemies.Count<10)
            {
                Vector2 pos = new Vector2(new Random().Next(800, 4000), new Random().Next(0, 570));
                Enemy enemy = new EnemyShip(pos);
                enemy.LoadContent(manager);
                enemies.Add(enemy);
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var e in enemies)
            {
                e.Draw(spriteBatch);
            }
        }
    }
}
