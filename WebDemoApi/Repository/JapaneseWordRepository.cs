using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemoApi.DataAccessLayer;
using WebDemoApi.Models;
using System.Diagnostics;
using WebDemoApi.Interfaces;

namespace WebDemoApi.Repository
{
    /// <summary>
    /// I recall that repositories are usually static, but after researching why,
    /// I decided to make it none static so it can be tested in integration/unit test.
    /// 
    /// The feature to search by symbol or word isn't implemented yet, I am not sure how i would implement this yet on the front-end
    /// </summary>
    public class JapaneseWordRepository : IJapaneseWordRepository
    {
        //private Web context;
        WebDemoEntities _context;
        private EventLog appLog;
        private DataAccessLayer.Interface.IDbContext dbContext;
        


        public JapaneseWordRepository()
        {
            //Data context is by default initialized
            _context = new WebDemoEntities();

            EventLog appLog = new EventLog();
            appLog.Source = "WebDemoApi";

        }

        public JapaneseWordRepository(WebDemoEntities context) 
        {
            _context = context;
        }
               

        /// <summary>
        /// Get all entries from the table
        /// </summary>
        /// <returns></returns>
        public List<JapaneseWord> GetAllEntries()
        {
            List<JapaneseWord> query = new List<JapaneseWord>();
            try
            {

                query = (from jwords in _context.JapaneseWordEntries
                         select new JapaneseWord
                         {
                             EntryID = jwords.EntryId,
                             Hiragana = jwords.Hiragana,
                             Romaji = jwords.Romaji,
                             AdditionalText = jwords.AdditionalText,
                             Kanji = jwords.Kanji,
                             MotherTongueTranslation = jwords.MotherTongueTranslation,
                             MotherTongueTranslationLabel = jwords.MotherTongueTranslationLabel
                         }).ToList();

            }
            catch (Exception ex)
            {
                appLog.WriteEntry(ex.Message);
            }
            return query;
        }

        /// <summary>
        /// Get one entry from the table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JapaneseWord GetEntry(int id)
        {

            JapaneseWord emptyModel = new JapaneseWord();

            try
            {

                var query = (from entry in _context.JapaneseWordEntries
                             where entry.EntryId == id
                             select entry).FirstOrDefault();
                JapaneseWord model = new JapaneseWord(query);

                return model;
            }
            catch (Exception ex)
            {
                appLog.WriteEntry(ex.Message);
            }

            return emptyModel;
        }

        /// <summary>
        /// Delete 1 entry from the table
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEntry(int id)
        {
            try
            {
                var jpword = (from words in _context.JapaneseWordEntries
                              where words.EntryId.Equals(id)
                              select words).Single();

                _context.JapaneseWordEntries.Remove(jpword);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                appLog.WriteEntry(ex.Message);
            }
        }

        /// <summary>
        /// Add 1 entry to the table
        /// </summary>
        public void AddEntry(JapaneseWord model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            try
            {
                JapaneseWordEntry jpwe = new JapaneseWordEntry
                {
                    Hiragana = model.Hiragana,
                    Kanji = model.Kanji,
                    Romaji = model.Romaji,
                    AdditionalText = model.AdditionalText,
                    MotherTongueTranslation = model.MotherTongueTranslation,
                    MotherTongueTranslationLabel = model.MotherTongueTranslationLabel
                };
                _context.JapaneseWordEntries.Add(jpwe);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                appLog.WriteEntry(ex.Message);
            }

        }

        /// <summary>
        /// Edit entry
        /// Retrieve model from database, overwrite the properties if the query if found
        /// </summary>
        public void EditEntry(JapaneseWord model)
        {
            try
            {
                var query = (from entry in _context.JapaneseWordEntries
                             where entry.EntryId == model.EntryID
                             select entry).FirstOrDefault();
                if (query != null)
                {

                    query.Romaji = model.Romaji;
                    query.Hiragana = model.Hiragana;
                    query.Kanji = model.Kanji;
                    query.AdditionalText = model.AdditionalText;
                    query.MotherTongueTranslation = model.MotherTongueTranslation;
                    query.MotherTongueTranslationLabel = model.MotherTongueTranslationLabel;

                    _context.SaveChanges();
                }
                else
                {
                    throw new NullReferenceException("Entry model is null");
                }

            }
            catch (Exception ex)
            {
                appLog.WriteEntry(ex.Message);
            }

        }


    }
}