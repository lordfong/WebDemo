using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WebDemoApi.Interfaces;
using System.Data.Entity;
using WebDemoApi.Models;
using WebDemoApi.DataAccessLayer;
using WebDemoApi.DataAccessLayer.Interface;
using WebDemoApi.Repository;


namespace WebDemoApiTest
{
    [TestFixture]
    public class JapaneseWordRepositoryTest
    {
        private List<JapaneseWord> _list = new List<JapaneseWord>();
        private WebDemoEntities _context = new WebDemoEntities();
        private JapaneseWord _word1 = new JapaneseWord();
        private JapaneseWord _word2 = new JapaneseWord();
        private JapaneseWord _word3 = new JapaneseWord();
        private int InvalidEntryId = 0;



        public void Setup()
        {
            _word1.EntryID = 1;
            _word1.Hiragana = "おおきい";
            _word1.Kanji = "大きい";
            _word1.Romaji = "O Ki I";
            _word1.MotherTongueTranslation = "water";

            _word1.EntryID = 2;
            _word1.Hiragana = "はな";
            _word1.Kanji = "花";
            _word1.Romaji = "Ha Na";
            _word2.MotherTongueTranslation = "Flower";

            _word1.EntryID = 3;
            _word1.Hiragana = "みず";
            _word1.Kanji = "水";
            _word1.Romaji = "Mi Zu";
            _word3.MotherTongueTranslation = "water";

            _list.Add(_word1);
            _list.Add(_word2);
            _list.Add(_word3);
        }

        [Test]
        public void ShouldThrowWithInValidEntryId()
        {


        }

        [Test]
        public void WhenCreatingWordsSaveShouldBeCalledOnce()
        {
            //arrange
            var mockRepo = new Mock<IJapaneseWordRepository>();
            mockRepo.Setup(x => x.AddEntry(It.IsAny<JapaneseWord>()));
            var lol = _context;

            //act
            // mockRepo.Object.AddEntry
            var pop = lol.JapaneseWordEntries.Count();

            //assery
            // mockRepo.VerifyAll();
        }

        [Test]
        public void WhenUpdatingWordSaveShouldBeCalledOnce()
        {

        }

        [Test]
        public void ThrowExceptionWhenModelHasInvalidForRepositoryEdit()
        {
            //arrange
            var mockRepo = new Mock<IJapaneseWordRepository>();

            //act
            

            //assert


        }

        [Test]
        public void ShouldReturnJapaneseWords()
        {

            //arrancge
            Setup();


            var repository = new Mock<IJapaneseWordRepository>();
            repository.Setup(x => x.GetAllEntries()).Returns(_list);


            //act
            var result = repository.Object.GetAllEntries();

            //assert
            Assert.IsNotEmpty(result);



        }
    }


}
