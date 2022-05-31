using System.Collections.Generic;

namespace PlaylistEditor.CoreTypes
{
    public interface IPlaylistItemFactory
    {
        IEnumerable<IFileInfo> AvailableTypes { get; }

        IPlaylistItem Create(string itemPath);
    }
}