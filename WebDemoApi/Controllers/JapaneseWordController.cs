using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebDemoApi.Models;
using WebDemoApi.Repository;

namespace WebDemoApi.Controllers
{
    public class JapaneseWordController : ApiController
    {
        // GET: api/JapaneseWord
        public string Get()
        {
            var jprepository = new JapaneseWordRepository();

            return JsonConvert.SerializeObject(jprepository.GetAllEntries());
        }

        // GET: api/JapaneseWord/5
        public string Get(int id)
        {
            var jprepository = new JapaneseWordRepository();
            return JsonConvert.SerializeObject(jprepository.GetEntry(id));
        }

        // POST: api/JapaneseWord
        public void Post([FromBody]string value)
        {
            var model = new JapaneseWord();
            // fill model??
            var jprepository = new JapaneseWordRepository();
            jprepository.AddEntry(model);

        }

        // PUT: api/JapaneseWord/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JapaneseWord/5
        public void Delete(int id)
        {
            var jprepository = new JapaneseWordRepository();
            jprepository.DeleteEntry(id);
        }
    }
}
