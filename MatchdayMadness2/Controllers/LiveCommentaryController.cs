using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchdayMadness2.Controllers
{
    public class LiveCommentaryController : Controller
    {
        private static DB _db;
        public LiveCommentaryController(DB db)
        {
            _db = db;
        }
        private static List<LiveCommentary> commentaries = new List<LiveCommentary>();
        // GET: LiveCommentaryController
        public ActionResult Index()
        {
            commentaries = _db.LiveCommentary.ToList();
            return View(commentaries);
        }

        // GET: LiveCommentaryController/Details/5
        public ActionResult Details(int id)
        {
            var comment = _db.LiveCommentary.Where(x=>x.id.Equals(id)).SingleOrDefault();
            return View(comment);
        }

        // GET: LiveCommentaryController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: LiveCommentaryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LiveCommentary commentary)
        {
            {
                _db.LiveCommentary.Add(commentary);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: LiveCommentaryController/Edit/5
        public ActionResult Edit(int id)
        {
            var comment = _db.LiveCommentary.Find(id);
            return View(comment);
        }

        // POST: LiveCommentaryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LiveCommentary commentaryNewData)
        {
            try
            {
                var comment = _db.LiveCommentary.Find( commentaryNewData.id);
                if (comment != null)
                {
                    comment.Commentator = commentaryNewData.Commentator;
                    comment.DescriptiveText = commentaryNewData.DescriptiveText;
                    comment.RealTimeUpdates = commentaryNewData.RealTimeUpdates;
                    _db.SaveChanges();
                }
                else
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LiveCommentaryController/Delete/5
        public ActionResult Delete(int id)
        {
            var comment = _db.LiveCommentary.Find(id);
            return View(comment);
        }

        // POST: LiveCommentaryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var comment = _db.LiveCommentary.Find(id);
                if (comment != null)
                    commentaries.Remove(comment);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
