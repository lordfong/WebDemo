using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebDemoApi.DataAccessLayer;

namespace WebDemoApi.Models
{
    /// <summary>
    /// Model for a japanese word,
    /// contains an ID for searching puroses
    /// Kanji Entry
    /// Hiragana entry
    /// Romaji entry
    /// Addtional text entry (ex of use)
    /// photo entry? ( implemented at later intervals)
    /// Mother tongue translation entry
    /// Mother tongue lable (english/dutch/french etc)
    /// 
    /// Annotations are being used on model level to keep the view simple
    /// </summary>
    public class JapaneseWord
    {
        public long EntryID { get; set; }
        
        [Display(Name = "Word(s)/Phrase/Kanji")]
        public string Kanji { get; set; }
       
        [Display(Name = "Hiragana")]
        public string Hiragana { get; set; }
       
        [Display(Name = "Romaji")]
        public string Romaji { get; set; }
       
        [Display(Name = "Additional Text")]
        [DataType(DataType.MultilineText)]
        public string AdditionalText { get; set; }
       
        [Display(Name = "Mother Tongue Translation")]
        public string MotherTongueTranslation { get; set; }
       
        [Display(Name = "Mother Tongue")]
        public string MotherTongueTranslationLabel { get; set; }

        /// <summary>
        /// Model with empty fields
        /// </summary>
        public JapaneseWord() 
        {
            Kanji = "";
            Hiragana = "";
            Romaji = "";
            AdditionalText = "";
            MotherTongueTranslation = "";
            MotherTongueTranslationLabel = "";
        }

        public JapaneseWord(long id, string kanji, string hiragana,string romaji, string additionalText,string motherTongueTranslation, string mothertongueTranslationLabel )
        {
            EntryID = Convert.ToInt64(id);
            Kanji = kanji;
            Hiragana = hiragana;
            Romaji = romaji;
            AdditionalText = additionalText;
            MotherTongueTranslation = motherTongueTranslation;
            MotherTongueTranslationLabel = MotherTongueTranslationLabel;
        }

        /// <summary>
        /// Model used for editing via the repository class
        /// 
        /// Not very well thought out when the sql db field is a bigint and here is an int.
        /// </summary>
        /// <param name="source"></param>
        public JapaneseWord(JapaneseWordEntry source) 
        {
            EntryID = Convert.ToInt32(source.EntryId);
            Kanji = source.Kanji;
            Hiragana = source.Hiragana;
            Romaji = source.Romaji;
            AdditionalText = source.AdditionalText;
            MotherTongueTranslation = source.MotherTongueTranslation;
            MotherTongueTranslationLabel = source.MotherTongueTranslationLabel;
        }
                
    }
}