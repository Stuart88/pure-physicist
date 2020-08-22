using System.Collections.Generic;

namespace PurePhysicist.Models
{
    public interface IItemRepository
    {
        #region Public Methods

        void Add(Item item);

        Item Get(string id);

        IEnumerable<Item> GetAll();

        Item Remove(string key);

        void Update(Item item);

        #endregion Public Methods
    }
}