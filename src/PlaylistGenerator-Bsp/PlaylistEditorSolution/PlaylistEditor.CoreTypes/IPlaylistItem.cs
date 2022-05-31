using System;
using System.Drawing;

namespace PlaylistEditor.CoreTypes
{
    public interface IPlaylistItem : IFileInfo
    {
        string Title { get; }

        string Artist { get; }

        string FilePath { get; }

        TimeSpan Duration { get; }

        Image Thumbnail { get; }
    }
}