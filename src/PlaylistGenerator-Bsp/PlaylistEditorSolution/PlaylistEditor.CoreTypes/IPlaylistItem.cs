using System;

namespace PlaylistEditor.CoreTypes
{
    public interface IPlaylistItem
    {
        TimeSpan Duration { get; }
    }
}