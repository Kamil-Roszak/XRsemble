using System;

namespace XRsemble.MVVM.Disposables
{
    /// <summary>
    /// Empty disposable that does nothing when disposed.
    /// </summary>
    public class EmptyDisposable: IDisposable
    {
        public void Dispose() { }
    }

}
