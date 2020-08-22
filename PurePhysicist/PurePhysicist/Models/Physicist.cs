namespace PurePhysicist.Models
{
    public class Physicist
    {
        #region Public Properties

        public string FamousFor { get; set; }

        public string ImageFileName { get; set; }

        public string Name { get; set; }

        public TopicsEnum Topics { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public Physicist(string name, string img, string famousFor, TopicsEnum topics)
        {
            this.Name = name;
            this.ImageFileName = img;
            this.FamousFor = famousFor;
            this.Topics = topics;
        }

        #endregion Public Constructors
    }
}