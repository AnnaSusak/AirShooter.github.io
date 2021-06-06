using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AirShooter.Content.Classes.UI
{
    class Menu
    {
        private List<Label> items;
        private string[] texts = { "Play", "Info", "Exit" };
        private int selected = 0;
        private KeyboardState keyboard;
        private KeyboardState prevKeyboard;
        public Vector2 Position { get; set; }

        public Menu()
        {
            items = new List<Label>();
            Vector2 position = Position;
            for (int i = 0; i < texts.Length; i++)
            {
                Label label = new Label( texts[i], position, Color.Red);
                items.Add(label);
                position.Y += 30;
            }
        }
        public void SetMenuPosition(Vector2 Position)
        {
            this.Position = Position;
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Position = Position;
                Position.Y += 30;
            }
        }
        public void LoadContent(ContentManager content)
        {
            foreach (Label item in items)
            {
                item.LoadContent(content);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            items[selected].Color = Color.Yellow;
            foreach (var item in items)
            {
                item.Draw(spriteBatch);
            }
        }
        public void Update()
        {
            keyboard = Keyboard.GetState();
            // проверка
            if (keyboard.IsKeyDown(Keys.S) && keyboard!=prevKeyboard)
            {
                if (selected<items.Count-1)
                {
                    items[selected].ResetColor();
                    selected++;
                }
            }
            //Up
            if (keyboard.IsKeyDown(Keys.W)&& keyboard != prevKeyboard)
            {
                if (selected>0)
                {
                    items[selected].ResetColor();
                    selected--;
                }
            }
            //Enter
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                switch (selected)
                {
                    //Play
                    case 0:
                        Game1.gameState = GameState.Game;
                        break;
                    //Info
                    case 1:
                        Game1.gameState = GameState.Info;
                        break;
                    //Exit
                    case 2:
                        Game1.gameState = GameState.Exit;
                        break;
                    default:
                        break;
                }
            }
            prevKeyboard = keyboard;
        }
    }
}
