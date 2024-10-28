using System;
using System.Collections.Generic;

namespace XRsemble.MVVM.Disposables
{
    /// <summary>
    /// DisposableList is a list of disposables that can be disposed all at once.
    /// </summary>
    public class DisposableList : IDisposable
    {
        private readonly List<IDisposable> _disposables;

        public DisposableList()
        {
            _disposables = new List<IDisposable>();
        }

        public DisposableList(int count)
        {
            _disposables = new List<IDisposable>(count);
        }

        public IDisposable Add(IDisposable disposable)
        {
            _disposables.Add(disposable);
            return disposable;
        }

        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}