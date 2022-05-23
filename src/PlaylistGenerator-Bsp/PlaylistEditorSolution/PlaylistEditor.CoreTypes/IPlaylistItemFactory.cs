namespace PlaylistEditor.CoreTypes
{
    public interface IPlaylistItemFactory
    {
        IPlaylistItem Create(string itemPath);
    }
}