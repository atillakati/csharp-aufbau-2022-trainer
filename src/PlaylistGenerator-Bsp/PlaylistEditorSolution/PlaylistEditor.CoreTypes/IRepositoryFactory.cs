using System.Collections.Generic;

namespace PlaylistEditor.CoreTypes
{
    public interface IRepositoryFactory
    {
        IEnumerable<IFileInfo> AvailableTypes { get; }

        IRepository Create(string filePath);
    }
}