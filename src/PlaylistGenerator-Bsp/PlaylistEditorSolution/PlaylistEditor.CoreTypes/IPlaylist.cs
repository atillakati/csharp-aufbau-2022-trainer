using System;
using System.Collections.Generic;

namespace PlaylistEditor.CoreTypes
{
    public interface IPlaylist
    {
        string Author { get; }
        DateTime CreateDate { get; }
        string Description { get; }
        TimeSpan Duration { get; }
        IEnumerable<IPlaylistItem> Items { get; }

        void Add(IPlaylistItem newItem);
        void Clear();
        void Remove(IPlaylistItem itemToRemove);
    }
}