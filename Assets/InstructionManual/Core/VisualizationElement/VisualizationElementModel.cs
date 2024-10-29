using UnityEngine;
using XRsemble.MVVM.Observables;

namespace XRsemble.Core
{
    public class VisualizationElementModel : MVVM.Model.Model
    {
        public IObservableValue<string> Name => _name;
        private readonly ObservableValue<string> _name;

        public IObservableValue<bool> IsVisible => _isVisible;
        private readonly ObservableValue<bool> _isVisible;

        public VisualizationElementModel(ObservableValue<string> name, ObservableValue<bool> isVisible)
        {
            _name = name;
            _isVisible = isVisible;
        }
    }

}
