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

namespace WebDemoApiTest
{
    [TestFixture]
   public class SomeTest
    {
        private List<JapaneseWordEntry> _list = new List<JapaneseWordEntry>();
        private JapaneseWordEntry _word1 = new JapaneseWordEntry();
        private JapaneseWordEntry _word2 = new JapaneseWordEntry();
        private JapaneseWordEntry _word3 = new JapaneseWordEntry();
        private int InvalidEntryId = 0;

        public void Setup()
        {
            _word1.EntryId = 1;
            _word1.Hiragana = "おおきい";
            _word1.Kanji = "大きい";
            _word1.Romaji = "O Ki I";
            _word1.MotherTongueTranslation = "water";

            _word1.EntryId = 2;
            _word1.Hiragana = "はな";
            _word1.Kanji = "花";
            _word1.Romaji = "Ha Na";
            _word2.MotherTongueTranslation = "Flower";

            _word1.EntryId = 3;
            _word1.Hiragana = "みず";
            _word1.Kanji = "水";
            _word1.Romaji = "Mi Zu";
            _word3.MotherTongueTranslation = "water";

            _list.Add(_word1);
            _list.Add(_word2);
            _list.Add(_word3);
        }

        [Test]
        public void TestinfSomeThing()
        {
            Setup();
            var mockSet = new Mock<DbSet<JapaneseWordEntry>>();
            var mockContext = new Mock<WebDemoEntities>();

            mockContext.Setup(m => m.JapaneseWordEntries).Returns(mockSet.Object);
            var repo = new MockableWordRepository(mockContext.Object);
            repo.AddWord(_word1.Hiragana, _word1.Romaji, _word1.Kanji);
                     

            mockSet.Verify(m => m.Add(It.IsAny<JapaneseWordEntry>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        
    }
}
