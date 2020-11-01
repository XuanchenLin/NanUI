using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
    internal sealed class WinFormiumDownloadHandler : CefDownloadHandler
    {
        private readonly Formium _owner;

        public WinFormiumDownloadHandler(Formium owner)
        {
            _owner = owner;
        }

        protected override void OnBeforeDownload(CefBrowser browser, CefDownloadItem downloadItem, string suggestedName, CefBeforeDownloadCallback callback)
        {
            var e = new BeforeDownloadEventArgs(downloadItem, suggestedName, callback);

            _owner.InvokeIfRequired(() => _owner.OnBeforeDownload(e));


        }

        protected override void OnDownloadUpdated(CefBrowser browser, CefDownloadItem downloadItem, CefDownloadItemCallback callback)
        {
            var e = new DownloadUpdatedEventArgs(downloadItem, callback);

            _owner.InvokeIfRequired(() => _owner.OnDownloadUpdated(e));
        }
    }

    public sealed class DownloadUpdatedEventArgs: EventArgs
    {
        private readonly CefDownloadItem _downloadItem;
        private readonly CefDownloadItemCallback _callback;

        internal DownloadUpdatedEventArgs(CefDownloadItem downloadItem, CefDownloadItemCallback callback)
        {
            _downloadItem = downloadItem;
            _callback = callback;


            DownloadFileId = (int)_downloadItem.Id;
            CurrentSpeed = _downloadItem.CurrentSpeed;
            StartTime = _downloadItem.StartTime;
            EndTime = _downloadItem.EndTime;
            FullPath =_downloadItem.FullPath;
            IsCanceled = _downloadItem.IsCanceled;
            IsComplete= _downloadItem.IsComplete;
            IsInProgress= _downloadItem.IsInProgress;
            PercentComplete =_downloadItem.PercentComplete;
            ReceivedBytes = _downloadItem.ReceivedBytes;
            ContentDisposition = _downloadItem.ContentDisposition;
            IsValid = _downloadItem.IsValid;
            MimeType = _downloadItem.MimeType;
            OriginalUrl = _downloadItem.OriginalUrl;
            TotalBytes = _downloadItem.TotalBytes;
            Url = _downloadItem.Url;
        }

        public int DownloadFileId { get; }
        public long CurrentSpeed { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public string FullPath { get; }
        public bool IsCanceled { get; }
        public bool IsComplete { get; }
        public bool IsInProgress { get; }
        public int PercentComplete { get; }
        public long ReceivedBytes { get; }
        public string ContentDisposition { get; }

        public bool IsValid { get; }
        public string MimeType { get; }
        public string OriginalUrl { get; }
        public long TotalBytes { get; }
        public string Url { get; }
        public string SuggestedName { get; }

        public void Pause() => _callback.Pause();
        public void Cancel() => _callback.Cancel();
        public void Resume() => _callback.Resume();
    }

    public sealed class BeforeDownloadEventArgs: EventArgs
    {
        private readonly CefDownloadItem _downloadItem;
        private readonly CefBeforeDownloadCallback _callback;

        internal BeforeDownloadEventArgs(CefDownloadItem downloadItem, string suggestedName, CefBeforeDownloadCallback callback)
        {
            _downloadItem = downloadItem;
            SuggestedName = suggestedName;
            _callback = callback;


            DownloadFileId = (int)_downloadItem.Id;
            ContentDisposition = _downloadItem.ContentDisposition;
            IsValid = _downloadItem.IsValid;
            MimeType = _downloadItem.MimeType;
            OriginalUrl = _downloadItem.OriginalUrl;
            TotalBytes = _downloadItem.TotalBytes;
            Url = _downloadItem.Url;
        }

        public int DownloadFileId { get; }
        public string ContentDisposition { get; }

        public bool IsValid { get; }
        public string MimeType { get; }
        public string OriginalUrl { get; }
        public long TotalBytes { get; }
        public string Url { get; }

        public void Continue(string path, bool showDialog = true) => _callback?.Continue(path, showDialog);
        public string SuggestedName { get; }
    }


}
