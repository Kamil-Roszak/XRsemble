using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XRsemble.Core
{
    public class Step : MonoBehaviour
    {
        public List<IStepVisualizationComponent> visualizationComponents;

        private void Awake()
        {
            visualizationComponents = new List<IStepVisualizationComponent>(GetComponentsInChildren<IStepVisualizationComponent>(true));
            visualizationComponents.ForEach((x) => x.Init());
            visualizationComponents.ForEach((x) => x.Hide());
        }

        /// <summary>
        /// Method that is called when step is going to be shown
        /// </summary>
        public void OnEnter()
        {
            foreach (var component in visualizationComponents)
            {
                component.Show();
            }
        }
        
        /// <summary>
        /// Method that is called when step is going to be hidden
        /// </summary>
        public void OnExit()
        {
            foreach(var component in visualizationComponents)
            {
                component.Hide();
            }

        }    
    }
}

