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


        [Test]
        public void ShouldThrowWithInValidEntryId()
        {


        }

        [Test]
        public void WhenCreatingWordsSaveShouldBeCalledOnce()
        {




        }

        [Test]
        public void WhenUpdatingWordSaveShouldBeCalledOnce()
        {

        }

        [Test]
        public void ShouldReturnJapaneseWords()
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


            var context = new Mock<WebDemoEntities>();

            var repo = new JapaneseWordRepository(context.Object);

            //act
            var result = repo.GetAllEntries();

            //assert
            Assert.IsNotEmpty(result);

            //List<string> testProjectNames = new List<string> { "Rizigo" };
            //Mock<ITeamCityApi> api = new Mock<ITeamCityApi>();

            //List<ITeamCityProject> testProjects = new List<ITeamCityProject>();

            //Mock<ITeamCityProject> someProject = new Mock<ITeamCityProject>();
            //someProject.Setup(x => x.Name).Returns("Rizigo");

            //testProjects.Add(someProject.Object);

            //api.Setup(x => x.GetProjects()).Returns(testProjects);

            //TeamCityRepository repository = new TeamCityRepository(api.Object);

            //IEnumerable<string> result = repository.GetProjectNames().Select(x => x.Name);

            //Assert.True(Enumerable.SequenceEqual(result, testProjectNames));


        }
    }


}
