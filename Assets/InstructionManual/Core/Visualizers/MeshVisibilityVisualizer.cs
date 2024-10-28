using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace XRsemble.Core
{
    /// <summary>
    /// Mesh Visilibilty Visualizer is a component that control visibility of MeshRenderers and SkinMeshRenderers
    /// </summary>
    public class MeshVisibilityVisualizer : MonoBehaviour, IStepVisualizationComponent
    {
        [Header("Parameters")]
        bool controlChildtren = true;

        private List<MeshRenderer> _meshRenderes;
        private List<SkinnedMeshRenderer> _skinnedMeshRenderers;

        public void Init() {
            _meshRenderes = new List<MeshRenderer>();
            _skinnedMeshRenderers = new List<SkinnedMeshRenderer>();

            if (controlChildtren)
                _meshRenderes.AddRange(GetComponentsInChildren<MeshRenderer>(true));
            if (GetComponent<MeshRenderer>() != null)
                _meshRenderes.Add(GetComponent<MeshRenderer>());

            if (controlChildtren)
                _skinnedMeshRenderers.AddRange(GetComponentsInChildren<SkinnedMeshRenderer>(true));
            if (GetComponent<SkinnedMeshRenderer>() != null)
                _skinnedMeshRenderers.Add(GetComponent<SkinnedMeshRenderer>());
        }

        public void Hide()
        {
            SetAllRenderersState(false);
        }

        public void Show()
        {
            SetAllRenderersState(true);
        }

        /// <summary>
        /// Method that set enabled state of all meshRenderers and skinnedMeshRenderers in gameobject and its children
        /// </summary>
        /// <param name="state"></param>
        private void SetAllRenderersState(bool state)
        {
            foreach (var renderer in _meshRenderes)
            {
                renderer.enabled = state;
            }
            foreach (var renderer in _skinnedMeshRenderers)
            {
                renderer.enabled = state;
            }
        }
    }
}

