using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

        public JapaneseWordEntry()
        { }

    }

   

}
