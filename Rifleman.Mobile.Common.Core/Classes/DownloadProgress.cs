using System;

namespace Rifleman.Mobile.Common.Core.Classes
{
    public class DownloadProgress
    {
        public DownloadProgress( string fileName, int bytesReceived, int totalBytes )
        {
            Filename = fileName;
            BytesReceived = bytesReceived;
            TotalBytes = totalBytes;
        }

        public int TotalBytes { get; }

        public int BytesReceived { get; }

        public decimal PercentComplete => BytesReceived / TotalBytes * 100;

        public int PercentCompleteAsInteger => ( int )Math.Truncate( PercentComplete );

        public string Filename { get; private set; }

        public bool IsFinished => BytesReceived == TotalBytes;
    }
}
