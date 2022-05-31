using PlaylistEditor.CoreTypes;
using PlaylistEditor.Factories;
using PlaylistEditor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaylistEditor
{
    public partial class frmMainApp : Form
    {
        private IPlaylist _playlist;
        private readonly IPlaylistItemFactory _playlistItemFactory;
        private readonly IRepositoryFactory _repositoryFactory;

        public frmMainApp()
        {
            InitializeComponent();

            _playlistItemFactory = new PlaylistItemFactory();
            _repositoryFactory = new RepositoryFactory(_playlistItemFactory);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newDialog = new NewPlaylistForm();

            if (newDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _playlist = PlaylistFactory.Create(newDialog.Author, newDialog.Title, DateTime.Now);

            UpdateTitleArea();
            UpdateItemsArea();
        }

        private void UpdateItemsArea()
        {
            int index = 0;

            listView.Items.Clear();
            imageList.Images.Clear();

            foreach (var playlistItem in _playlist.Items)
            {
                var listViewItem = new ListViewItem(playlistItem.Title);
                listViewItem.ImageIndex = index++;
                listViewItem.Tag = playlistItem;

                if (playlistItem.Thumbnail != null)
                {
                    imageList.Images.Add(playlistItem.Thumbnail);
                }
                else
                {
                    imageList.Images.Add(Resources.no_image);
                }

                listView.Items.Add(listViewItem);
            }

            listView.LargeImageList = imageList;
        }

        private void UpdateTitleArea()
        {
            lbl_title.Text = $"{_playlist.Description} - {_playlist.Author} [{_playlist.Duration}]";
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var item = _playlistItemFactory.Create(openFileDialog.FileName);
            if (item != null)
            {
                _playlist.Add(item);

                UpdateTitleArea();
                UpdateItemsArea();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems == null || listView.SelectedItems.Count <= 0)
            {
                return;
            }

            foreach (ListViewItem selectedItem in listView.SelectedItems)
            {
                var playlistItem = selectedItem.Tag as IPlaylistItem;
                if (playlistItem != null)
                {
                    _playlist.Remove(playlistItem);
                }
            }

            UpdateTitleArea();
            UpdateItemsArea();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _playlist.Clear();

            UpdateTitleArea();
            UpdateItemsArea();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var repository = _repositoryFactory.Create(saveFileDialog.FileName);
            if(repository != null)
            {
                repository.Save(saveFileDialog.FileName, _playlist);
            }
        }
    }
}
