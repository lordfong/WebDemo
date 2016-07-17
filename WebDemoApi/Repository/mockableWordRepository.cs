namespace WebDemoApi.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using WebDemoApi.DataAccessLayer;
    using WebDemoApi.DataAccessLayer.Interface;
    using WebDemoApi.Models;

    public class JapaneseWordRepository // : IMockableWordRepository
    {
    //    private MySQLDbContext _context;
        
    //    public JapaneseWordRepository(MySQLDbContext context)
    //    {
    //        _context = context;
    //        _context.Database.CreateIfNotExists();
    //    }

    //    public void AddWord(JapaneseWord model)
    //    {

    //        using (var dbcontext = _context)
    //        {
    //            var entityModel = new JapaneseWordEntry(model);
    //           dbcontext.Database.
    //            dbcontext.SaveChanges();
    //        }
    //    }

    //    public List<JapaneseWord> GetAllWords()
    //    {
    //        using (var dbcontext = _context)
    //        {
    //            var results = dbcontext.JapaneseWordEntries.Select(x => new JapaneseWord(x.EntryId, x.Kanji, x.Hiragana, x.Romaji, x.AdditionalText, x.MotherTongueTranslation, x.MotherTongueTranslationLabel)).ToList();
    //            return results;
    //        }
    //    }

    //    public JapaneseWordEntry GetWord(int id)
    //    {
    //        using (var dbcontext = _context)
    //        {
    //            var result = dbcontext.JapaneseWordEntries.Where(x => x.EntryId == id).Select(x => x).FirstOrDefault();

    //            return result;
    //        }

    //    }

    //    public void DeleteWord(int id)
    //    {
    //        if (id <= 0)
    //        {
    //            throw new ArgumentOutOfRangeException("id");
    //        }

    //        using (var dbcontext = _context)
    //        {
    //            var result = dbcontext.JapaneseWordEntries.Where(x => x.EntryId == id).Select(x => x).FirstOrDefault();

    //            if (result == null)
    //            {
    //                throw new ArgumentOutOfRangeException("id");
    //            }

    //            dbcontext.JapaneseWordEntries.Remove(result);
    //            dbcontext.SaveChanges();
    //        }
    //    }

    //    public void UpdateWord(JapaneseWordEntry model)
    //    {
    //        using (var dbcontext = _context)
    //        {
    //            var result = dbcontext.JapaneseWordEntries.Where(x => x.EntryId == model.EntryId).Select(x => x).Single();
    //            result = model;
    //            dbcontext.SaveChanges();
    //        }
    //    }
    }
}