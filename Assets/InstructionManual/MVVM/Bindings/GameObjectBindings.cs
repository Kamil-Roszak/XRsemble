using System;
using UnityEngine;
using XRsemble.MVVM.Observables;

namespace XRsemble.MVVM.Bindings
{
    public static class GameObjectBindings
    {
        public static IDisposable Bind(this GameObject gameObject, IObservableValue<bool> observable)
        {
            return observable.InvokeAndSubscribe(gameObject.SetActive);
        }
    }
}