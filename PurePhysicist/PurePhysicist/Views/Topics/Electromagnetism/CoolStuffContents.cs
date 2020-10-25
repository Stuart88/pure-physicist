using PurePhysicist.Views.Topics.Electromagnetism.CoolStuffItems;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System.Collections.Generic;

namespace PurePhysicist.Views.Topics.Electromagnetism
{
    public class CoolStuffContents
    {
        #region Public Fields

        public static readonly List<CoolStuffView.CoolStuffListItem> Items = new List<CoolStuffView.CoolStuffListItem>
        {
            new CoolStuffView.CoolStuffListItem("Mass Spectrometer", new MassSpectrometer()),
        };

        #endregion Public Fields
    }
}