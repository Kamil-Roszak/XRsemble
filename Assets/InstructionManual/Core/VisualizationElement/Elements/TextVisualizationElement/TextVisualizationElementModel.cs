using UnityEngine;
using XRsemble.MVVM.Observables;

namespace XRsemble.Core
{
    public class TextVisualizationElementModel : VisualizationElementModel
    {
        public IObservableValue<string> DisplayedText => _displayedText;
        private readonly ObservableValue<string> _displayedText;

    }

}
