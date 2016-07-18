namespace WebDemoApi.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using WebDemoApi.Repository;
    using WebDemoApi.DataAccessLayer;
    using WebDemoApi.DataAccessLayer.Interface;
    using WebDemoApi.Models;

    public class JapaneseWordController : ApiController
    {
        private JapaneseWordRepository _japaneseWordRepository;
        private MySQLDbContext _context = new MySQLDbContext();

        public JapaneseWordController()
        {
            _japaneseWordRepository = new JapaneseWordRepository(_context);
        }

        // GET: api/JapaneseWord
        public IEnumerable<JapaneseWord> Get()
        {
            return _japaneseWordRepository.GetAllWords();
        }

        // GET: api/JapaneseWord/5
        public DataModel.JapaneseWord Get(int id)
        {

            return _japaneseWordRepository.GetWord(id);
        }

        // POST: api/JapaneseWord
        public HttpResponseMessage Post(JapaneseWord model)
        {

            var m = new DataModel.JapaneseWord();
            // Write model mapper!!!
            _japaneseWordRepository.AddWord(m);

            var response = Request.CreateResponse<JapaneseWord>(HttpStatusCode.Created, model);

            string uri = Url.Link("DefaultApi", new { id = model.EntryID});
            response.Headers.Location = new Uri(uri);
            return response;

        }

        // PUT: api/JapaneseWord/5
        public void Put(JapaneseWord model)
        {
            //write model mapper!!
            var m = new DataModel.JapaneseWord();
            try
            {
                _japaneseWordRepository.UpdateWord(m);
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
