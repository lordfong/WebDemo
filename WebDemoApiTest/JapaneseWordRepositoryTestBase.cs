using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebDemoApi.DataAccessLayer;
using WebDemoApi.Models;
using WebDemoApi.Repository;

namespace WebDemoApiTest
{
    /// <summary>
    /// Base clase with base members properties
    /// </summary>
    public class JapaneseWordRepositoryTestBase
    {
        public List<JapaneseWord> _list = new List<JapaneseWord>();

        public JapaneseWord _word1 = new JapaneseWord();
        public JapaneseWord _word2 = new JapaneseWord();
        public JapaneseWord _word3 = new JapaneseWord();
        public int _invalidEntryId = 0;
        public Mock<DbSet<JapaneseWordEntry>> mockSet = new Mock<DbSet<JapaneseWordEntry>>();
        public Mock<WebDemoEntities> mockContext = new Mock<WebDemoEntities>();
        public MockableWordRepository _repository;

        [SetUp]
        public void Setup()
        {
            _word1.EntryID = 1;
            _word1.Hiragana = "おおきい";
            _word1.Kanji = "大きい";
            _word1.Romaji = "O Ki I";
            _word1.MotherTongueTranslation = "water";

            _word2.EntryID = 2;
            _word2.Hiragana = "はな";
            _word2.Kanji = "花";
            _word2.Romaji = "Ha Na";
            _word2.MotherTongueTranslation = "Flower";

            _word3.EntryID = 3;
            _word3.Hiragana = "みず";
            _word3.Kanji = "水";
            _word3.Romaji = "Mi Zu";
            _word3.MotherTongueTranslation = "water";

            _list.Add(_word1);
            _list.Add(_word2);
            _list.Add(_word3);

            var queryableList = _list.AsQueryable();
            mockSet.As<IQueryable<JapaneseWord>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            mockSet.As<IQueryable<JapaneseWord>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            mockSet.As<IQueryable<JapaneseWord>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            mockSet.As<IQueryable<JapaneseWord>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());
            mockContext.Setup(m => m.JapaneseWordEntries).Returns(mockSet.Object);
            _repository = new MockableWordRepository(mockContext.Object);
        }
    }
}
