using System;
using UnityEngine;
using TMPro;

namespace XRsemble.Core
{
    public class VisualizationElementView : MVVM.View.View
    {
        [field: SerializeField] public TextMeshPro NameText { get; private set; }

        public override void Dispose()
        {
            Destroy(gameObject);
        }
    }
}