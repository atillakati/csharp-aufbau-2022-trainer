using PlaylistEditor.CoreTypes;
using PlaylistEditor.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistEditor.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public RepositoryFactory(IPlaylistItemFactory playlistItemFactory)
        {
            _playlistItemFactory = playlistItemFactory;
        }

        public IEnumerable<IFileInfo> AvailableTypes => new IRepository[]
        {
            new M3uRepository(_playlistItemFactory),
        };

        public IRepository Create(string filePath)
        {
            IRepository repository = null;

            if(string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return repository;
            }

            var extension = Path.GetExtension(filePath);
            switch (extension)
            {
                case ".m3u":
                    repository = new M3uRepository(_playlistItemFactory);
                    break;

                case ".pls":
                case ".json":
                case ".wlp":
                    repository = null;
                    break;  
            }

            return repository;
        }
    }
}
