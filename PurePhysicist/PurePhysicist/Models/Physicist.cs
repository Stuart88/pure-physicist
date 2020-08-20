using System;
using System.Collections.Generic;
using System.Text;

namespace PurePhysicist.Models
{
    public class Physicist
    {
        public Physicist(string name, string img, string famousFor, TopicsEnum topics)
        {
            this.Name = name;
            this.ImageFileName = img;
            this.FamousFor = famousFor;
            this.Topics = topics;
        }

        public string Name { get; set; }
        public string ImageFileName { get; set; }
        public string FamousFor { get; set; }
        public TopicsEnum Topics { get; set; }
    }
}
