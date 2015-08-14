using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemoApi.DataAccessLayer;

namespace WebDemoApi.Repository
{
    public class MockableWordRepository
    {

        private WebDemoEntities _context;

        public MockableWordRepository(WebDemoEntities context)
        {
            _context = context;
        }

        public JapaneseWordEntry AddWord(string hiragana, string romaji, string kanji)
        {
            var word = _context.JapaneseWordEntries.Add(new JapaneseWordEntry(hiragana, romaji, kanji));
            _context.SaveChanges();

            return word;
        }

        public List<JapaneseWordEntry> GetAllWords()
        {
            var results = _context.JapaneseWordEntries.Select(x => x).ToList();

            return results;
        }


    }
}