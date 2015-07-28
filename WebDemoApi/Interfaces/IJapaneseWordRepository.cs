using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemoApi.Models;

namespace WebDemoApi.Interfaces
{
   public interface IJapaneseWordRepository
    {
        List<JapaneseWord> GetAllEntries();
        JapaneseWord GetEntry(int id);
        void DeleteEntry(int id);
        void AddEntry(JapaneseWord model);
        void EditEntry(JapaneseWord model);
        
    }
}
