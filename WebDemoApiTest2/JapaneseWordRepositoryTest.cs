using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebDemoApi.Models;
using Moq;
using WebDemoApi.Repository;
using WebDemoApi.DataAccessLayer;
using WebDemoApi.Interfaces;

namespace WebDemoApiTest2
{
    [TestClass]
    public class JapaneseWordRepositoryTest
    {
        [TestMethod]
        public void ShouldReturnList()
        {
            //arrancge
            var list = new List<JapaneseWord>();

            var word1 = new JapaneseWord();
            var word2 = new JapaneseWord();
            var word3 = new JapaneseWord();

            word1.EntryID = 1;
            word1.Hiragana = "おおきい";
            word1.Kanji = "大きい";
            word1.Romaji = "O Ki I";
            word1.MotherTongueTranslation = "water";

            word1.EntryID = 2;
            word1.Hiragana = "はな";
            word1.Kanji = "花";
            word1.Romaji = "Ha Na";
            word2.MotherTongueTranslation = "Flower";

            word1.EntryID = 3;
            word1.Hiragana = "みず";
            word1.Kanji = "水";
            word1.Romaji = "Mi Zu";
            word3.MotherTongueTranslation = "water";

            list.Add(word1);
            list.Add(word2);
            list.Add(word3);


            //var context = new Mock<WebDemoEntities>();
            var repository = new Mock<IJapaneseWordRepository>();
            repository.Setup(x => x.GetAllEntries()).Returns(list);
           // context.Setup(x => x.JapaneseWordEntries).Returns(list);

            //var repo = new JapaneseWordRepository(context.Object);

            //act
            var result = repository.Object.GetAllEntries();

            //assert
            Assert.IsTrue(result.Count>0);
        }
    }
}
