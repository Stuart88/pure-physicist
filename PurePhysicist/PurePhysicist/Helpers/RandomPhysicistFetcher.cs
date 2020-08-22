using PurePhysicist.Extensions;
using PurePhysicist.Models;
using System.Collections.Generic;
using System.Linq;

namespace PurePhysicist.Helpers
{
    public class RandomPhysicistFetcher
    {
        #region Private Properties

        private List<int> AvailableIndexes { get; }
        private TopicsEnum Topics { get; }

        #endregion Private Properties

        #region Public Constructors

        /// <summary>
        /// A class for preparing and returning physicists in a random order, where no entry is repeated until the full set has been cycled over
        /// </summary>
        public RandomPhysicistFetcher(TopicsEnum topics)
        {
            this.AvailableIndexes = new List<int>();

            this.Topics = topics;

            this.GetAndShuffleIndexes();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the next random physicist from the collection, ensuring to not repeat any until the full collectoin has been cycled over
        /// </summary>
        /// <returns></returns>
        public Physicist GetNextPhysicist()
        {
            if (this.AvailableIndexes.Count == 0)
            {
                this.GetAndShuffleIndexes();
            }

            int physicistIndex = this.AvailableIndexes.Last();

            //Remove last as it should be more efficient to remove last item of array.
            this.AvailableIndexes.Remove(physicistIndex);

            return PhyscistsCollection.Physicists[physicistIndex];
        }

        #endregion Public Methods

        #region Private Methods

        private void GetAndShuffleIndexes()
        {
            for (int i = 0; i < PhyscistsCollection.Physicists.Count; i++)
            {
                if ((PhyscistsCollection.Physicists[i].Topics & this.Topics) > 0)
                    this.AvailableIndexes.Add(i);
            }

            this.AvailableIndexes.Shuffle();
        }

        #endregion Private Methods
    }
}