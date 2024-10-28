using System;
using UnityEngine;

namespace XRsemble.MVVM.View
{
    /// <summary>
    /// Base class for MVVM views.
    /// </summary>
    public abstract class View : MonoBehaviour, IDisposable
    {
        public abstract void Dispose();
    }
}

