using Moq;
using NUnit.Framework;
using PlaylistEditor.CoreTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistEditor.Repositories.Test
{
    [TestFixture]
    public class M3uRepositoryTests
    {
        [Test]
        public void Save()
        {
            //Arrange
            var mockedPlaylistItemFactory = new Mock<IPlaylistItemFactory>();
            IPlaylist playlist = CreateDummyPlaylist();
            var fixture = new M3uRepository(mockedPlaylistItemFactory.Object);

            //Act
            fixture.Save("dummyPlaylist.m3u", playlist);

            //Assert
        }

        [Test]
        public void Load()
        {
            //Arrange
            var mockedPlaylistItemFactory = new Mock<IPlaylistItemFactory>();  
            mockedPlaylistItemFactory.Setup(x => x.Create(It.IsAny<string>())).Returns(new Mock<IPlaylistItem>().Object);
            var fixture = new M3uRepository(mockedPlaylistItemFactory.Object);

            //Act
            var playlist = fixture.Load("dummyPlaylist.m3u");

            //Assert
            Assert.That(playlist.Author, Is.EqualTo("DJ Gandalf"));
            Assert.That(playlist.Description, Is.EqualTo("Dummy Top Charts 2022"));
            Assert.That(playlist.CreateDate, Is.EqualTo(new DateTime(2020, 4, 1)));
            Assert.That(playlist.Items.Count(), Is.EqualTo(2));
        }

        private IPlaylist CreateDummyPlaylist()
        {
            var mockedPlaylist = new Mock<IPlaylist>();
                      
            //prepare item list(!)
            var mockedPlaylistItem = new Mock<IPlaylistItem>();
            mockedPlaylistItem.Setup(x => x.FilePath).Returns(@"c:\music\song1.mp3");
            mockedPlaylistItem.Setup(x => x.Title).Returns(@"Super Song 1");
            mockedPlaylistItem.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(200));

            var mockedPlaylistItem2 = new Mock<IPlaylistItem>();
            mockedPlaylistItem2.Setup(x => x.FilePath).Returns(@"c:\music\song2.mp3");
            mockedPlaylistItem2.Setup(x => x.Title).Returns(@"Super Song 2");
            mockedPlaylistItem2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(210));

            var listOfMockedItems = new IPlaylistItem[]
            {
                mockedPlaylistItem.Object,
                mockedPlaylistItem2.Object,
            };

            mockedPlaylist.Setup(x => x.Author).Returns("DJ Gandalf");
            mockedPlaylist.Setup(x => x.Description).Returns("Dummy Top Charts 2022");
            mockedPlaylist.Setup(x => x.CreateDate).Returns(new DateTime(2020, 4, 1));
            mockedPlaylist.Setup(x => x.Items).Returns(listOfMockedItems);

            return mockedPlaylist.Object;
        }
    }
}
