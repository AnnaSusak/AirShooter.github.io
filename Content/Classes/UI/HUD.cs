using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AirShooter.Content.Classes.UI
{
    class HUD
    {
        // score
        private Label lblScore;
        private Label lblRecord;

        //healthBar
        private Bar healthBar;

        // HUD
        private bool isVisible;
        public HUD()
        {
            isVisible = true;
            lblScore = new Label("100", new Vector2(100,50),Color.Azure);
            healthBar = new Bar(null, new Vector2(0,0), Color.White, 10, 10, 2);
            lblRecord = new Label("1", new Vector2(100, 65), Color.White);
        }
        public void Update(int score, int health, int record)
        {
            lblScore.Text = score.ToString();
            lblRecord.Text = record.ToString();
           healthBar.Update(health);
        }
        public void LoadContent(ContentManager content) 
        {
            healthBar.LoadContent(content);
            lblRecord.LoadContent(content);
            lblScore.LoadContent(content);
        }
        public void Draw(SpriteBatch spriteBatch) 
        {
            if (isVisible)
            {
                lblScore.Draw(spriteBatch);
                lblRecord.Draw(spriteBatch);
                healthBar.Draw(spriteBatch);
            }
        }
    }
}
