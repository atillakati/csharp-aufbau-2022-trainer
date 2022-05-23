using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistEditor.CoreTypes.Test
{
    [TestFixture]
    public class PlaylistTests
    {
        private Playlist _fixture;

        //[Test]
        //public void EinEinfacherTest()
        //{
        //    int zahl1 = 0;
        //    int zahl2 = 5;

        //    var erg = zahl1 + zahl2;

        //    Assert.That(erg, Is.EqualTo(5));
        //}

        [SetUp]
        public void Init()
        {
            var testDateTime = new DateTime(1980, 4, 1);
            _fixture = new Playlist("Gandalf", "TopHits 2022", testDateTime);
        }

        [Test]
        public void Items_InitalCheck()
        {
            //Act
            var erg = _fixture.Items;

            //Assert
            Assert.That(erg, Is.Not.Null);
            Assert.That(erg.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Duration_Get()
        {
            //Arrange
            var mockedPlaylistItem1 = new Mock<IPlaylistItem>();
            var mockedPlaylistItem2 = new Mock<IPlaylistItem>();

            mockedPlaylistItem1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(10.0));
            mockedPlaylistItem2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(15.0));

            _fixture.Add(mockedPlaylistItem1.Object);
            _fixture.Add(mockedPlaylistItem2.Object);

            //Act
            var res = _fixture.Duration;

            //Assert
            Assert.That(res, Is.EqualTo(TimeSpan.FromSeconds(25)));
        }

        [Test]
        public void Items_AddOneItem()
        {
            //Arrange
            var mockedPlaylistItem = new Mock<IPlaylistItem>();
            _fixture.Add(mockedPlaylistItem.Object);

            //Act
            var erg = _fixture.Items;

            //Assert            
            Assert.That(erg.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Description_Get()
        {
            //Arrange
            
            //Act
            var erg = _fixture.Description;

            //Assert
            Assert.That(erg, Is.EqualTo("TopHits 2022"));
        }

        [Test]
        public void Author_Get()
        {
            //Arrange
            
            //Act
            var erg = _fixture.Author;

            //Assert
            Assert.That(erg, Is.EqualTo("Gandalf"));
        }

        [Test]
        public void CreateDate_Get()
        {
            //Arrange
            var testDateTime = new DateTime(1980, 4, 1);            

            //Act
            var erg = _fixture.CreateDate;

            //Assert
            Assert.That(erg, Is.EqualTo(testDateTime));
        }

        [Test]
        public void Add()
        {
            //Arrange
            var mockedItem = new Mock<IPlaylistItem>();
            var erg = _fixture.Items.Count();

            //Act
            _fixture.Add(mockedItem.Object);

            //Assert
            Assert.That(_fixture.Items.Count(), Is.EqualTo(erg+1));
        }

        [Test]
        public void Add_ItemIsNull()
        {
            //Arrange            
            var erg = _fixture.Items.Count();

            //Act
            _fixture.Add(null);

            //Assert
            Assert.That(_fixture.Items.Count(), Is.EqualTo(erg));
        }

        [Test]
        public void Remove()
        {
            //Arrange
            var mockedItem = new Mock<IPlaylistItem>();
            _fixture.Add(mockedItem.Object);
            var erg = _fixture.Items.Count();

            //Act
            _fixture.Remove(mockedItem.Object);

            //Assert
            Assert.That(_fixture.Items.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Remove_ItemIsNull()
        {
            //Arrange
            var mockedItem = new Mock<IPlaylistItem>();
            _fixture.Add(mockedItem.Object);
            var erg = _fixture.Items.Count();

            //Act
            _fixture.Remove(null);

            //Assert
            Assert.That(_fixture.Items.Count(), Is.EqualTo(1));
        }


        [Test]
        public void Clear()
        {
            //Arrange
            var mockedItem = new Mock<IPlaylistItem>();
            _fixture.Add(mockedItem.Object);            

            //Act
            _fixture.Clear();

            //Assert
            Assert.That(_fixture.Items.Count(), Is.EqualTo(0));
        }
    }
}

