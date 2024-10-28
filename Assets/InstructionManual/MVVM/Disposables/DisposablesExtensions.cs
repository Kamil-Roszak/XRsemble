using System;

namespace XRsemble.MVVM.Disposables
{
    /// <summary>
    /// Extension methods for IDisposable.
    /// </summary>
    public static class DisposablesExtensions
    {
        public static IDisposable AddTo(this IDisposable disposable, DisposableList disposableList)
        {
            return disposableList.Add(disposable);
        }

        public static T AddTo<T>(this T disposable, DisposableList disposableList) where T : IDisposable
        {
            disposableList.Add(disposable);
            return disposable;
        }
    }
}