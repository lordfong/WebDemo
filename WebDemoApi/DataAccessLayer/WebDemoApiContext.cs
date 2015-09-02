using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebDemoApi.Models;

namespace WebDemoApi.DataAccessLayer
{
    /// <summary>
    /// Extending functionality of the JapaneseWordEntry class by creating a partial class
    /// </summary>
    public partial class JapaneseWordEntry
    {
        public JapaneseWordEntry(string hirigana, string romaji, string kanji)
        {
            Hiragana = hirigana;
            Romaji = romaji;
            Kanji = kanji;
        }

        public JapaneseWordEntry(JapaneseWord model)
        {
            Hiragana = model.Hiragana;
            Romaji = model.Romaji;
            Kanji = model.Kanji;
            MotherTongueTranslation = model.MotherTongueTranslation;
            MotherTongueTranslationLabel = model.MotherTongueTranslationLabel;
            AdditionalText = model.AdditionalText;
        }

        public JapaneseWordEntry() { }

    }

   

}
