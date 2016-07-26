using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;

namespace WebDemoApi.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using WebDemoApi.DataAccessLayer;
    using WebDemoApi.DataAccessLayer.Interface;
    using WebDemoApi.Models;

    public class JapaneseWordRepository
    {
        private MySqlDbContext _context;
        
        //public JapaneseWordRepository(MySqlDbContext context)
        //{
        //    _context = context;
        //    _context.Database.CreateIfNotExists();


        //}

        public JapaneseWordRepository()
        {
            _context = new MySqlDbContext();
            if (!_context.Database.Exists())
            {
                _context.Database.Create();
                _context.Word.Add(new DataModel.JapaneseWord { EntryId = 1, Hiragana = "愛", Kanji = "愛", Romaji = "ai", AdditionalText = string.Empty, MotherTongueTranslation = "love", MotherTongueTranslationLabel = "English" });
                _context.SaveChanges();
            }
        }
        
        public void AddWord(DataModel.JapaneseWord model)
        {

            using (var dbcontext = _context)
            {
                dbcontext.Word.Add(model);
                dbcontext.SaveChanges();
            }
        }

        public List<JapaneseWord> GetAllWords()
        {
            using (var dbcontext = _context)
            {
                var results = dbcontext.Word.FirstOrDefault(); //dbcontext.Word.Select(x => new JapaneseWord(x.EntryId, x.Kanji, x.Hiragana, x.Romaji, x.AdditionalText, x.MotherTongueTranslation, x.MotherTongueTranslationLabel)).ToList();
                return null;
            }
        }

        public DataModel.JapaneseWord GetWord(int id)
        {
            using (var dbcontext = _context)
            {
                var result = dbcontext.Word.Where(x => x.EntryId == id).Select(x => x).FirstOrDefault();

                return result;
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
                var result = dbcontext.Word.Where(x => x.EntryId == id).Select(x => x).FirstOrDefault();

                if (result == null)
                {
                    throw new ArgumentOutOfRangeException("id");
                }

                dbcontext.Word.Remove(result);
                dbcontext.SaveChanges();
            }
        }

        public void UpdateWord(DataModel.JapaneseWord model)
        {
            using (var dbcontext = _context)
            {
                var result = dbcontext.Word.Where(x => x.EntryId == model.EntryId).Select(x => x).Single();
                result = model;
                dbcontext.SaveChanges();
            }
        }
    }
}