using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaylistEditor.CoreTypes
{
    public class Playlist : IPlaylist
    {
        private string _description;
        private string _author;
        private DateTime _createDate;
        private List<IPlaylistItem> _items;

        public Playlist(string author, string description)
        {
            _author = author;
            _description = description;
            _createDate = DateTime.Now;

            _items = new List<IPlaylistItem>();
        }

        public Playlist(string author, string description, DateTime createDate)
        {
            _author = author;
            _description = description;
            _createDate = createDate;

            _items = new List<IPlaylistItem>();
        }


        public TimeSpan Duration
        {
            get
            {
                if (_items == null || _items.Count == 0)
                {
                    return TimeSpan.Zero;
                }

                var mainDuration = _items.Aggregate(TimeSpan.Zero, (sum, val) => sum.Add(val.Duration));

                return mainDuration;
            }
        }

        public IEnumerable<IPlaylistItem> Items => _items;

        public DateTime CreateDate => _createDate;

        public string Author => _author;

        public string Description => _description;


        public void Add(IPlaylistItem newItem)
        {
            if (newItem == null)
            {
                return;
            }

            _items.Add(newItem);
        }

        public void Remove(IPlaylistItem itemToRemove)
        {
            if (itemToRemove == null)
            {
                return;
            }

            _items.Remove(itemToRemove);
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}
