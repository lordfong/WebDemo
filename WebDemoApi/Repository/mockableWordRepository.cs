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
            using (var dbcontext = _context)
            {
                dbcontext.JapaneseWordEntries.Add(model);
                dbcontext.SaveChanges();
            }
        }

        public List<JapaneseWordEntry> GetAllWords()
        {
            using (var dbcontext = _context)
            {
                var results = dbcontext.JapaneseWordEntries.Select(x => x).ToList();
                return results;
            }
        }

        public List<JapaneseWordEntry> GetWord(int id)
        {
            using (var dbcontext = _context)
            {
                var results = dbcontext.JapaneseWordEntries.Where(x => x.EntryId == id).Select(x => x).ToList();

                return results;
            }

        }

        public void DeleteWord(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            using (var dbcontext = _context)
            {
                var result = dbcontext.JapaneseWordEntries.Where(x => x.EntryId == id).Select(x => x).FirstOrDefault();

                if (result == null)
                {
                    throw new ArgumentOutOfRangeException("id");
                }

                dbcontext.JapaneseWordEntries.Remove(result);
                dbcontext.SaveChanges();
            }




        }

        public void UpdateWord(JapaneseWordEntry model)
        {
            using (var dbcontext = _context)
            {
                var result = dbcontext.JapaneseWordEntries.Where(x => x.EntryId == model.EntryId).Select(x => x).Single();
                result = model;
                dbcontext.SaveChanges();
            }

        }

    }
}