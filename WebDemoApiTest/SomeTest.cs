using NUnit.Framework;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemoApi.DataAccessLayer;
using WebDemoApi.Models;
using Moq;
using WebDemoApi.Repository;
using System;

namespace WebDemoApiTest
{
    [TestFixture]
    public class SomeTest
    {
        private List<JapaneseWordEntry> _list = new List<JapaneseWordEntry>();

        private JapaneseWordEntry _word1 = new JapaneseWordEntry();
        private JapaneseWordEntry _word2 = new JapaneseWordEntry();
        private JapaneseWordEntry _word3 = new JapaneseWordEntry();
        private int _invalidEntryId = 0;

        private Mock<DbSet<JapaneseWordEntry>> mockSet = new Mock<DbSet<JapaneseWordEntry>>();
        private Mock<WebDemoEntities> mockContext = new Mock<WebDemoEntities>();
        private Mock<WebDemoEntities> mockEmptyContext = new Mock<WebDemoEntities>();
        private Mock<DbSet<JapaneseWordEntry>> mockEmptySet = new Mock<DbSet<JapaneseWordEntry>>();
        private MockableWordRepository _repository;


        [SetUp]
        public void Setup()
        {
            _word1.EntryId = 1;
            _word1.Hiragana = "おおきい";
            _word1.Kanji = "大きい";
            _word1.Romaji = "O Ki I";
            _word1.MotherTongueTranslation = "water";

            _word2.EntryId = 2;
            _word2.Hiragana = "はな";
            _word2.Kanji = "花";
            _word2.Romaji = "Ha Na";
            _word2.MotherTongueTranslation = "Flower";

            _word3.EntryId = 3;
            _word3.Hiragana = "みず";
            _word3.Kanji = "水";
            _word3.Romaji = "Mi Zu";
            _word3.MotherTongueTranslation = "water";

            _list.Add(_word1);
            _list.Add(_word2);
            _list.Add(_word3);

            var queryableList = _list.AsQueryable();
            mockSet.As<IQueryable<JapaneseWordEntry>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            mockSet.As<IQueryable<JapaneseWordEntry>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            mockSet.As<IQueryable<JapaneseWordEntry>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            mockSet.As<IQueryable<JapaneseWordEntry>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());
            mockContext.Setup(m => m.JapaneseWordEntries).Returns(mockSet.Object);
            mockEmptyContext.Setup(m => m.JapaneseWordEntries).Returns(mockEmptySet.Object);
            _repository = new MockableWordRepository(mockContext.Object);
        }

        [Test]
        public void TestingSomeThing()
        {
            var repo = new MockableWordRepository(mockEmptyContext.Object);
            repo.AddWord(_word1);

            //context.add is called
            mockEmptySet.Verify(m => m.Add(It.IsAny<JapaneseWordEntry>()), Times.Once());
            //savechanges is called
            mockEmptyContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void WhenAddingANewWordContextSaveIsCalledOnce()
        {
            var repo = new MockableWordRepository(mockEmptyContext.Object);
            repo.AddWord(_word1);

            mockEmptyContext.Verify(m => m.SaveChanges(), Times.Once);

        }

        [Test]
        public void WhenAddingANewWordContextAddisCalledOnce()
        {
            var repo = new MockableWordRepository(mockEmptyContext.Object);
            
            var ExpectedWord = _word2;

            repo.AddWord(_word2);

            mockEmptyContext.Verify(m => m.JapaneseWordEntries.Add(It.IsAny<JapaneseWordEntry>()), Times.Once);
        }

        [Test]
        public void GetAllWordsReturnAllWords()
        {
            int expectedCount = _list.Count;

            var actCount = _repository.GetAllWords().Count;

            Assert.AreEqual(expectedCount, actCount);
        }

        [Test]
        public void WhenDeletingWordContextRemoveIsCalledOnce()
        {
            var id = 1;
            _repository.DeleteWord(id);

            mockSet.Verify(m => m.Remove(It.IsAny<JapaneseWordEntry>()), Times.Once);
        }

        [Test]
        public void ShouldThrowArgumentOutOfRangeExceptionWhenRemovingInValidId()
        {
            var action = new TestDelegate(() => _repository.DeleteWord(_invalidEntryId));

            Assert.Throws(Is.InstanceOf<ArgumentOutOfRangeException>(), action);
        }

    }
}
