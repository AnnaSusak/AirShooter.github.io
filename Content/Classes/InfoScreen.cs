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
    class InfoScreen
    {
        private string text;
        private Vector2 position;
        private Color color;
        private SpriteFont spriteFont;

        public bool IsVisible{get; set;}
        public InfoScreen(string text, Vector2 position, Color color)
        {
            this.text = text;
            IsVisible = false;
            this.position = position;
            this.color = color;
        }
        public void LoadContent(ContentManager content)
        {
            spriteFont=content.Load<SpriteFont>("File");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                spriteBatch.DrawString(spriteFont, text, position, color);
            }
        }
        public void Update()
        {
            // проверка
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Game1.gameState = GameState.Menu;
            }
        }
    }
}
