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
using WebDemoApi.DataAccessLayer;
using System.Data.Entity;

namespace WebDemoApi.Controllers
{
    public class JapaneseWordController : ApiController
    {
        DbContext _context = WebDemoEntities;
        // GET: api/JapaneseWord
        public IEnumerable<DataAccessLayer.JapaneseWordEntry> Get()
        {
            var jprepository = new MockableWordRepository();

            return jprepository.GetAllWords();
        }

        // GET: api/JapaneseWord/5
        public JapaneseWord Get(int id)
        {
            var jprepository = new JapaneseWordRepository();
            return jprepository.GetEntry(id);
        }

        // POST: api/JapaneseWord
        public HttpResponseMessage Post(JapaneseWord model)
        {
            
            var jprepository = new JapaneseWordRepository();
            jprepository.AddEntry(model);

            var response = Request.CreateResponse<JapaneseWord>(HttpStatusCode.Created, model);

            string uri = Url.Link("DefaultApi", new { id = model.EntryID });
            response.Headers.Location = new Uri(uri);
            return response;

        }

        // PUT: api/JapaneseWord/5
        public void Put(int id, JapaneseWord model)
        {
            var jprepository = new JapaneseWordRepository();
            try 
            {
                jprepository.EditEntry(model);
            }
            catch 
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
        }

        // DELETE: api/JapaneseWord/5
        public void Delete(int id)
        {
            var jprepository = new JapaneseWordRepository();
            if (jprepository.GetEntry(id) == null) 
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            jprepository.DeleteEntry(id);
        }
    }
}
