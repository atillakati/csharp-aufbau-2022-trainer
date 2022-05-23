
namespace PlaylistEditor.CoreTypes
{
    public interface IRepository : IFileInfo
    {
        IPlaylist Load(string filePath);

        void Save(string filePath, IPlaylist playlist);
    }
}
