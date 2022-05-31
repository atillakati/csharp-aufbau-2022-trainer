using PlaylistEditor.CoreTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistEditor.Items
{
    public class Mp3Item : IPlaylistItem
    {
        private readonly TagLib.Tag _tags;
        private readonly TimeSpan _duration;
        private readonly string _filePath;
        private readonly Image _image;

        public Mp3Item(string filePath)
        {
            if(filePath == null)
            {
                return;
            }

            var tags = TagLib.File.Create(filePath);
            _tags = tags.Tag;
            
            _duration = tags.Properties.Duration;
            _filePath = filePath;

            _image = GetImage();
        }

        private Image GetImage()
        {
            Image image = null;

            if (_tags.Pictures != null && _tags.Pictures.Length > 0)
            {
                //https://stackoverflow.com/questions/10247216/c-sharp-mp3-id-tags-with-taglib-album-art
                image = Image.FromStream(new MemoryStream(_tags.Pictures[0].Data.Data));
            }

            return image;
        }

        public string Title => _tags.Title;

        public string Artist => _tags.FirstPerformer;

        public string FilePath => _filePath;

        public TimeSpan Duration => _duration;

        public Image Thumbnail => _image;

        public string Description => "MP3 Audio File";

        public string Extension => ".mp3";
    }
}
