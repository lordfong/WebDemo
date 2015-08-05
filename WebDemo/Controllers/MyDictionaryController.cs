using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using WebDemo.Repository;

namespace WebDemo.Controllers
{
    public class MyDictionaryController : Controller
    {
        /// <summary>
        /// Goes to the main screen of DictionaryList
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            try
            {
                return RedirectToAction("DictionaryLists", "Home");
            }
            catch (Exception ex)
            {
                //something went wrong, record error and send user home
                // however displayerrors can't be recorded
                throw;
            }

            //return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Get 1 dictionary entry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                //something went wrong, record error and send user home
                // however displayerrors can't be recorded
            }

            return View();
        }

        /// <summary>
        /// Add new entry screen
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyDictionary/Create
        /// <summary>
        /// Sumbits form
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(JapaneseWord model)
        {
            JapaneseWordRepository jpwrep = new JapaneseWordRepository();
            try
            {
                if (ModelState.IsValid)
                {
                    TryUpdateModel(model);
                    jpwrep.AddEntry(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyDictionary/Edit/5
        /// <summary>
        /// Retrieves model for the edit page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            JapaneseWordRepository jpwrep = new JapaneseWordRepository();
            JapaneseWord jpword = jpwrep.GetEntry(id);

            return View(jpword);
        }

        // POST: MyDictionary/Edit/5
        /// <summary>
        /// When it is posted via forms
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(JapaneseWord model)
        {
            try
            {
                TryUpdateModel(model); //ensuring it is the current model
                JapaneseWordRepository jpwrep = new JapaneseWordRepository();
                jpwrep.EditEntry(model);

                //redirect to main dictionary page when done
                return RedirectToAction("Index");
            }
            catch 
            {
                //Bounce them home
                return RedirectToAction("Index");
            }
        }

        // GET: MyDictionary/Delete/5
        public ActionResult Delete(int id)
        {
            JapaneseWordRepository jpwrep = new JapaneseWordRepository();
            jpwrep.DeleteEntry(id);
            return RedirectToAction("Index");
        }

        // POST: MyDictionary/Delete/5
        /// <summary>
        /// Currently not used
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
