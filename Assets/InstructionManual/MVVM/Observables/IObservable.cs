using System;

namespace XRsemble.MVVM.Observables
{
    public interface IObservable<out T> : IObservable
    {
        IDisposable Subscribe(Action<T> observer);
        IDisposable InvokeAndSubscribe(Action<T> observer);
    }

    public interface IObservable
    {
        IDisposable Subscribe(Action observer);
        IDisposable InvokeAndSubscribe(Action observer);
    }
}
