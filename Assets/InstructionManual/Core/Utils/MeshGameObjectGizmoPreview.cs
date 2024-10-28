using System;
using System.Collections.Generic;
using UnityEngine;

namespace XRsemble.Core
{
    [ExecuteInEditMode]
    /// <summary>
    /// Component that previews the Meshes of a GameObject in the Scene view as if they were at the target Transform position
    /// </summary>
    public class MeshGameObjectGizmoPreview : MonoBehaviour
    {
        public GameObject targetObject;
        public List<Tuple<Transform, Color>> targetTransforms;

        private void OnDrawGizmos()
        {
            if (targetObject == null || targetTransforms == null)
                return;

            Color originalGizmoColor = Gizmos.color;
            Matrix4x4 originalGizmosMatrix = Gizmos.matrix;

            MeshFilter[] meshFilters = targetObject.GetComponentsInChildren<MeshFilter>(true);
            SkinnedMeshRenderer[] skinnedMeshRenderers = targetObject.GetComponentsInChildren<SkinnedMeshRenderer>(true);

            foreach (MeshFilter meshFilter in meshFilters)
            {
                if (meshFilter.sharedMesh == null)
                    continue;

                // Compute the relative transformation matrix from targetObject to mesh
                Matrix4x4 relativeMatrix = GetRelativeMatrix(targetObject.transform, meshFilter.transform);

                // Compute the final transformation matrix
                foreach(var transformToShow in targetTransforms)
                {
                    Matrix4x4 finalMatrix = transformToShow.Item1.localToWorldMatrix * relativeMatrix;

                    // Set the Gizmos matrix to the final transformation matrix
                    Gizmos.matrix = finalMatrix;

                    Gizmos.color = transformToShow.Item2;
                    // Draw the mesh at the target position
                    Gizmos.DrawMesh(meshFilter.sharedMesh);
                }
                
            }

            foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
            {
                if (skinnedMeshRenderer.sharedMesh == null)
                    continue;

                // Compute the relative transformation matrix from targetObject to skinned mesh
                Matrix4x4 relativeMatrix = GetRelativeMatrix(targetObject.transform, skinnedMeshRenderer.transform);
                
                foreach(var transformToShow in targetTransforms)
                {
                    // Compute the final transformation matrix
                    Matrix4x4 finalMatrix = transformToShow.Item1.localToWorldMatrix * relativeMatrix;

                    // Set the Gizmos matrix to the final transformation matrix
                    Gizmos.matrix = finalMatrix;

                    Gizmos.color = transformToShow.Item2;
                    // Draw the skinned mesh at the target position
                    Gizmos.DrawMesh(skinnedMeshRenderer.sharedMesh);
                }
            }

            // Restore the original Gizmos color and matrix
            Gizmos.color = originalGizmoColor;
            Gizmos.matrix = originalGizmosMatrix;
        }

        // Helper method to compute the relative transformation matrix between two Transforms
        private Matrix4x4 GetRelativeMatrix(Transform fromTransform, Transform toTransform)
        {
            return fromTransform.worldToLocalMatrix * toTransform.localToWorldMatrix;
        }
    }
}