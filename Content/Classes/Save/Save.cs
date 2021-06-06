using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml.Serialization;
using System.IO;
namespace AirShooter.Content.Classes.Save
{
    ///<summary>
    ///Класс для сохранения и загрузки данных
    /// </summary>
    public class Save
    {
        
        private Container container;
        public Save(Container container)
        {
            this.container = container;
        }
        public Save() { }
        public void Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Container));
            FileStream stream = new FileStream("save.txt", FileMode.Create);
            serializer.Serialize(stream, container);
            stream.Close();
        }
        public Container Deserialize()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Container));
            FileStream stream = new FileStream("save.txt", FileMode.Open);
            container = (Container)deserializer.Deserialize(stream);
            stream.Close();
            return container;
        }
    }
}
