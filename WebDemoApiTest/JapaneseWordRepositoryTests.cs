using NUnit.Framework;
using WebDemoApi.DataAccessLayer;
using Moq;
using WebDemoApi.Repository;
using System;

namespace WebDemoApiTest
{

    [TestFixture]
    public class JapaneseRepositoryAddTests : JapaneseWordRepositoryTestBase
    {
        [Test]
        public void WhenAddingANewWordContextSaveIsCalledOnce()
        {
            Setup();
            //var repo = new MockableWordRepository(mockContext.Object);
            // repo.AddWord(_word1);
            _repository.AddWord(_word1);

            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void WhenAddingANewWordContextAddisCalledOnce()
        {
            Setup();
            var repo = new MockableWordRepository(mockContext.Object);
            var ExpectedWord = _word2;

            repo.AddWord(_word2);

            mockSet.Verify(m => m.Add(It.IsAny<JapaneseWordEntry>()), Times.Once);
        }


    }

    [TestFixture]
    public class JapaenseRepositoryGetWordsTest : JapaneseWordRepositoryTestBase
    {
        [Test]
        public void GetAllWordsReturnAllWords()
        {
            Setup();
            int expectedCount = _list.Count;

            var actCount = _repository.GetAllWords().Count;

            Assert.AreEqual(expectedCount, actCount);
        }
    }

    [TestFixture]
    public class JapaneseRepositoryDeketeTest : JapaneseWordRepositoryTestBase
    {
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
            Setup();
            var action = new TestDelegate(() => _repository.DeleteWord(_invalidEntryId));

            Assert.Throws(Is.InstanceOf<ArgumentOutOfRangeException>(), action);
        }

    }
}
