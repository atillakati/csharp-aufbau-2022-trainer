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
            SetEditingModeActive(true);
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
            lbl_title.Text = $"{_playlist.Description} - {_playlist.Author} [{_playlist.Duration.ToFriendlyText()}]";
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitFileDialog(openFileDialog, _playlistItemFactory.AvailableTypes, "Select playlist items");
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            foreach (var filePath in openFileDialog.FileNames)
            {
                var item = _playlistItemFactory.Create(filePath);
                if (item != null)
                {
                    _playlist.Add(item);
                }
            }

            UpdateTitleArea();
            UpdateItemsArea();
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
            InitFileDialog(saveFileDialog, _repositoryFactory.AvailableTypes, "Save playlist as file");
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var repository = _repositoryFactory.Create(saveFileDialog.FileName);
            if (repository != null)
            {
                repository.Save(saveFileDialog.FileName, _playlist);
            }
        }

        private void InitFileDialog(FileDialog fileDialog, IEnumerable<IFileInfo> availableTypes, string dialogTitle)
        {
            if(fileDialog == null || availableTypes == null || string.IsNullOrEmpty(dialogTitle))
            {
                return;
            }

            fileDialog.Title = dialogTitle;
            var filterString = availableTypes.Aggregate(string.Empty, (a,b) => a + b.Description + "|*" + b.Extension+ "|");
            filterString = filterString.Remove(filterString.Length - 1, 1);   

            fileDialog.Filter = filterString;            
        }

        private void frmMainApp_Load(object sender, EventArgs e)
        {
            lbl_title.Text = string.Empty;
            lbl_itemDetails.Text = string.Empty;

            SetEditingModeActive(false);
        }

        private void SetEditingModeActive(bool isActive)
        {
            saveToolStripMenuItem.Enabled = isActive;
            addToolStripMenuItem.Enabled = isActive;
            removeToolStripMenuItem.Enabled = isActive;
            clearToolStripMenuItem.Enabled = isActive;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitFileDialog(openFileDialog, _repositoryFactory.AvailableTypes, "Select playlist to load");
            openFileDialog.Multiselect = false;
            if(openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var repository = _repositoryFactory.Create(openFileDialog.FileName);
            if(repository != null)
            {
                _playlist = repository.Load(openFileDialog.FileName);

                UpdateTitleArea();
                UpdateItemsArea();
                SetEditingModeActive(true);
            }
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {            
            if(e.Item.Tag is IPlaylistItem playlistItem)
            {
                lbl_itemDetails.Text = $"{playlistItem.FilePath}\n\rDuration: {playlistItem.Duration.ToFriendlyText()}";
            }
        }
    }
}
