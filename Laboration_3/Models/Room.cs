using System;
using System.IO;
using System.Xml.Serialization;


namespace Laboration_3.Models
{
    [System.Serializable]
    public class Room 
    {
        //TODO: ID count. Where is it supposed to be?

        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public int Size { get; set; }

        public double[] Coordinates { get; set; }

        public Wall NorthWall { get; set; }

        public Wall SouthWall { get; set; }

        public Wall WestWall { get; set; }

        public Wall EastWall { get; set; }

        public Wall Roof { get; set; }

        public Wall Floor { get; set; }

    }
}