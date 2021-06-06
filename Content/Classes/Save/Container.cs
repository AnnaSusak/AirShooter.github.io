using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml.Serialization;
namespace AirShooter.Content.Classes.Save
{
    [Serializable]
    ///<summary>
    ///Значение для сериализации
    /// </summary>
    public class Container
    {
        public int Score { get; set; }
        public int Health { get; set; }
        public int Record { get; set; }
        public Container(Player player)
        {
            Score = player.Score;
            Health = player.Health;
            Record = player.Record;
        }
        public Container() { Score = 0; Health = 0; Record = 0; }
    }
}
