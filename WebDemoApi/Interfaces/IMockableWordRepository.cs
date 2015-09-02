using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemoApi.Models;

namespace WebDemoApi.DataAccessLayer.Interface
{
    interface IMockableWordRepository
    {
        void AddWord(JapaneseWord model);
        List<JapaneseWord> GetAllWords();
        JapaneseWordEntry GetWord(int id);
        void DeleteWord(int id);
        void UpdateWord(JapaneseWordEntry model);
    }
}
