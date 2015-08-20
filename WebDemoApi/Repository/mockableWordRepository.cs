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

        public void AddWord(JapaneseWordEntry model)
        {
            _context.JapaneseWordEntries.Add(model);
            _context.SaveChanges();
                                 
        }

        public List<JapaneseWordEntry> GetAllWords()
        {
           var results = _context.JapaneseWordEntries.Select(x => x).ToList();
           

            return results;
        }

        public List<JapaneseWordEntry> GetWord(int id)
        {
            var results = _context.JapaneseWordEntries.Where(x=>x.EntryId == id).Select(x => x).ToList();

            return results;
        }

        public void DeleteWord(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            var result = _context.JapaneseWordEntries.Where(x => x.EntryId == id).Select(x => x).FirstOrDefault();

            if (result == null)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            _context.JapaneseWordEntries.Remove(result);
            _context.SaveChanges();

            
        }

        public void UpdateWord(JapaneseWordEntry model)
        {
            var result = _context.JapaneseWordEntries.Where(x => x.EntryId == model.EntryId).Select(x => x).Single();
            result = model;
            _context.SaveChanges();
        }

    }
}