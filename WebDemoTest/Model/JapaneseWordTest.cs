using System;
using WebDemo.Models;
using WebDemo.CustumExtensions;
using WebDemo.DataAccessLayer;
using NUnit.Framework;


namespace WebDemoTest
{
    [TestFixture]
    public class JapaneseWordsTest
    {
        private const string NOTNULLOREMPTY = "not null or empty ";

        /// <summary>
        /// When creating a new entry ,the model needs to be instanciated and requires some fields to not be null or else
        /// the view will complain of null reference. This is also testing the (first) constructor.
        /// </summary>
        [Test]
        public void EmptyModel_ConstructorDefault()
        {
            JapaneseWord jpw = new JapaneseWord();
            Assert.AreEqual(0,jpw.EntryID,"Entry ID" +NOTNULLOREMPTY);
            Assert.AreEqual("",jpw.Hiragana, "Hiragana "+NOTNULLOREMPTY );
            Assert.AreEqual("", jpw.Kanji, "Kanji "+NOTNULLOREMPTY);
            Assert.AreEqual("", jpw.Romaji, "Romaji "+NOTNULLOREMPTY);
            Assert.AreEqual("", jpw.AdditionalText, "Additional Text "+ NOTNULLOREMPTY);
            Assert.AreEqual("",jpw.MotherTongueTranslation,"Mother Tongue Translation "+ NOTNULLOREMPTY);
            Assert.AreEqual("",jpw.MotherTongueTranslationLabel,"Mother Tongue Translation Label"+NOTNULLOREMPTY);

        }

        /// <summary>
        /// Testing second constructor, but the data comes from the database?
        /// </summary>
        [Test]
        public void EditModel_SecondConstructor() 
        {
            JapaneseWord jpw = new JapaneseWord();
            JapaneseWordEntry jpwe = new JapaneseWordEntry();

        }
    }
}
