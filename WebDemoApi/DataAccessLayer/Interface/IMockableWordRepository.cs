using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemoApi.DataAccessLayer.Interface
{
    interface IMockableWordRepository
    {
        void AddWord(JapaneseWordEntry model);
        List<JapaneseWordEntry> GetAllWords();
        List<JapaneseWordEntry> GetWord(int id);
        void DeleteWord(int id);
        void UpdateWord(JapaneseWordEntry model);
    }
}
