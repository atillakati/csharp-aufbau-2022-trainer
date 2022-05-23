using PlaylistEditor.CoreTypes;
using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistEditor.Repositories
{
    public class M3uRepository : IRepository
    {
        private readonly IPlaylistItemFactory _playlistItemFactory;        

        public M3uRepository(IPlaylistItemFactory playlistItemFactory)
        {
            _playlistItemFactory = playlistItemFactory;            
        }

        public string Description => "m3u Playlist";

        public string Extension => ".m3u";

        public IPlaylist Load(string filePath)
        {

            M3uPlaylist m3UPlaylist = null;

            using (var stream = new StreamReader(filePath))
            {
                var content = new M3uContent();
                m3UPlaylist = content.GetFromStream(stream.BaseStream);

                //var parser = PlaylistParserFactory.GetPlaylistParser(Extension);
                //m3UPlaylist = parser.GetFromStream(stream.BaseStream);
            }

            var paths = m3UPlaylist.GetTracksPaths();


            //#*Autor*:Gandalf
            //#*Description*:TopCharts 2022
            //#*CreateDate*:20220523
            var comments = m3UPlaylist.PlaylistEntries.SelectMany(x => x.Comments);
            
            var autor = comments.FirstOrDefault(x => x.StartsWith("#*Author*:")).Replace("#*Author*:", string.Empty);
            var description = comments.FirstOrDefault(x => x.StartsWith("#*Description*:")).Replace("#*Description*:", string.Empty);
            var createDate = comments.FirstOrDefault(x => x.StartsWith("#*CreateDate*:")).Replace("#*CreateDate*:", string.Empty);

            var myPlaylist = new Playlist(autor, description, 
                                          DateTime.ParseExact(createDate,"yyyyMMdd", CultureInfo.InvariantCulture));
            
            foreach (var itemPath in paths)
            {                             
                var playlistItem = _playlistItemFactory.Create(itemPath);
                if(playlistItem != null)
                {
                    myPlaylist.Add(playlistItem);
                }
            }

            return myPlaylist;
        }

        public void Save(string filePath, IPlaylist playlist)
        {
            var m3uPlaylist = new M3uPlaylist
            {
                IsExtended = true
            };

            m3uPlaylist.Comments.Add($"*Author*:{playlist.Author}");
            m3uPlaylist.Comments.Add($"*Description*:{playlist.Description}");
            m3uPlaylist.Comments.Add($"*CreateDate*:{playlist.CreateDate.ToString("yyyyMMdd")}");

            foreach (var item in playlist.Items)
            {
                var m3uItem = new M3uPlaylistEntry
                {
                    Path = item.FilePath,
                    Title = item.Title, 
                    Duration = item.Duration,
                };

                m3uPlaylist.PlaylistEntries.Add(m3uItem);
            }            
           
            var text = PlaylistToTextHelper.ToText(m3uPlaylist);

            //Daten in Datei schreiben
            using(var sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(text);
            }
        }
    }
}
