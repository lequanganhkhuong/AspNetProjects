using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelpDeskAPI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HelpDeskAPI.Controllers
{
    public class HelpDeskAgentController : Controller
    {
        private HelpDeskSystemEntities db = new HelpDeskSystemEntities();
        
        //// GET: HelpDeskAgent
        //public ActionResult Index()
        //{
        //    IEnumerable<WorkItem> workitem = null;

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:61758/api/workitems/");

        //        var responseTask = client.GetAsync("workitem");
        //        responseTask.Wait();  
        //        var result = responseTask.Result;  
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<IList<WorkItem>>();
        //            readTask.Wait();

        //            workitem = readTask.Result;
        //        }
        //        else
        //        {
        //            //Error 
        //        }
        //    }
        //    return View(workitem);
        //}
        public ActionResult Index()
        {
            return View(db.WorkItems.ToList());
        }


        // GET: HelpDeskAgent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HelpDeskAgent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Status,CreateDate,CompletedDate")] WorkItem workItem)
        {
            if (ModelState.IsValid)
            {
                db.WorkItems.Add(workItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workItem);
        }
        
        // GET: HelpDeskAgent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workItem = db.WorkItems.Find(id);
            if (workItem == null)
            {
                return HttpNotFound();
            }
            return View(workItem);
        }

        // POST: HelpDeskAgent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkItem workItem = db.WorkItems.Find(id);
            db.WorkItems.Remove(workItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
