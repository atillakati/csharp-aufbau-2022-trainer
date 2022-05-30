using PlaylistEditor.CoreTypes;
using PlaylistEditor.Items;
using System.Collections.Generic;
using System.IO;


namespace PlaylistEditor.Factories
{
    public class PlaylistItemFactory : IPlaylistItemFactory
    {
        public IEnumerable<IFileInfo> AvailableTypes => new IPlaylistItem[]
        {
            new Mp3Item(null),
        };

        public IPlaylistItem Create(string itemPath)
        {
            IPlaylistItem playlistItem = null;

            if (string.IsNullOrEmpty(itemPath) || !File.Exists(itemPath))
            {
                return playlistItem;
            }

            var extension = Path.GetExtension(itemPath);
            switch (extension)
            {
                case ".mp3":
                    playlistItem = new Mp3Item(itemPath);
                    break;

                case ".jpg":
                    break;

                default:
                    break;
            }

            return playlistItem;
        }
    }
}
