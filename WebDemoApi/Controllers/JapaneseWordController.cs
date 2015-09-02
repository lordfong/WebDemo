
using System;
using System.Collections.Generic;

using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebDemoApi.Repository;
using WebDemoApi.DataAccessLayer;

using WebDemoApi.DataAccessLayer.Interface;
using WebDemoApi.Models;

namespace WebDemoApi.Controllers
{
    public class JapaneseWordController : ApiController
    {
        private IMockableWordRepository _japaneseWordRepository;

        public JapaneseWordController()
        {
            _japaneseWordRepository = new JapaneseWordRepository(new WebDemoEntities());
        }

        // GET: api/JapaneseWord
        public IEnumerable<JapaneseWord> Get()
        {
            return _japaneseWordRepository.GetAllWords();
        }

        // GET: api/JapaneseWord/5
        public JapaneseWordEntry Get(int id)
        {

            return _japaneseWordRepository.GetWord(id);
        }

        // POST: api/JapaneseWord
        public HttpResponseMessage Post(JapaneseWord model)
        {

            //var jprepository = new JapaneseWordRepository();
            //jprepository.AddEntry(model);
            _japaneseWordRepository.AddWord(model);

            var response = Request.CreateResponse<JapaneseWord>(HttpStatusCode.Created, model);

            string uri = Url.Link("DefaultApi", new { id = model.EntryID});
            response.Headers.Location = new Uri(uri);
            return response;

        }

        // PUT: api/JapaneseWord/5
        public void Put(JapaneseWordEntry model)
        {
            
            try
            {
                _japaneseWordRepository.UpdateWord(model);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

        }

        // DELETE: api/JapaneseWord/5
        public void Delete(int id)
        {
           
            if (_japaneseWordRepository.GetWord(id) == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _japaneseWordRepository.DeleteWord(id);
        }
    }
}
