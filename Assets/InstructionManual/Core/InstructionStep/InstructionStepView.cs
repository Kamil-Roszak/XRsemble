using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace XRsemble.Core
{
    public class InstructionStepView : MVVM.View.View
    {

        [field: SerializeField] public GameObject Root { get; private set; }
        [field: SerializeField] public TextMeshPro NameText { get; private set; }

        [field: SerializeField] public List<VisualizationElementView> VisualizationElementsViews { get; private set; }

        public override void Dispose()
        {
            Destroy(gameObject);
        }
    }
}