using PurePhysicist.Helpers;

namespace PurePhysicist.Models
{
    public interface IPhysicistFetcher
    {
        #region Public Properties

        public bool IsShowing { get; set; }
        public RandomPhysicistFetcher PhysicistFetcher { get; }

        #endregion Public Properties

        #region Public Methods

        public void SetIsShowing(bool isShowing);
        public void SetPhysicistView();

        #endregion Public Methods
    }
}