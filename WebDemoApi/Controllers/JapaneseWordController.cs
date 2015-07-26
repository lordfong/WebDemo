using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebDemo.Models;
using WebDemoApi.Repository;

namespace WebDemoApi.Controllers
{
    public class JapaneseWordController : ApiController
    {
        // GET: api/JapaneseWord
        public string Get()
        {
            var jprepository = new JapaneseWordRepository();
            var getAllWords = jprepository.GetAllEntries();

            return JsonConvert.SerializeObject(jprepository.GetAllEntries());
        }

        // GET: api/JapaneseWord/5
        public string Get(int id)
        {
            string lol = "lol";
            var entryModel = new JapaneseWord();
            entryModel.AdditionalText = lol;
            entryModel.Hiragana = lol;
            entryModel.EntryID = 3;
            entryModel.Romaji = lol;
            return JsonConvert.SerializeObject(entryModel);
        }

        // POST: api/JapaneseWord
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/JapaneseWord/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JapaneseWord/5
        public void Delete(int id)
        {
        }
    }
}
