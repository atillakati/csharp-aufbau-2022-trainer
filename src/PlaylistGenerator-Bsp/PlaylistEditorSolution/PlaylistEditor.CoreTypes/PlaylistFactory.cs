using System;

namespace PlaylistEditor.CoreTypes
{
    /// <summary>
    /// Factory Method implementation
    /// </summary>
    public abstract class PlaylistFactory
    {
        public static IPlaylist Create(string author, string description, DateTime dateOfCreation)
        {
            if (string.IsNullOrEmpty(author) || string.IsNullOrEmpty(description))
            {
                return null;
            }

            return new Playlist(author, description, dateOfCreation);
        }
    }
}
