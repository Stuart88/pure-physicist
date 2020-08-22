using System.ComponentModel.DataAnnotations;

namespace PurePhysicist.Models
{
    public class Item
    {
        #region Public Properties

        [Required]
        public string Description { get; set; }

        public string Id { get; set; }

        [Required]
        public string Text { get; set; }

        #endregion Public Properties
    }
}