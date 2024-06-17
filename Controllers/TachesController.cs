using Microsoft.AspNetCore.Mvc;
using TrelloBack.Models;

namespace TrelloBack.Controllers
{
    public class TachesController : Controller
    {
        private readonly DatabaseContext _db;

        public TachesController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet("Taches")]
        public IActionResult GetTaches()
        {
            // Get taches from database
            try
            {
                if (_db.Taches == null)
                {
                    return NotFound();
                }
                return Json(_db.Taches);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Taches/{id?}")]
        public IActionResult GetTaches(int id)
        {
            // Get tache from database
            try
            {
                if (_db.Taches == null)
                {
                    return NotFound("No taches found");
                }

                Tache? toGet = _db.Taches.Find(id);
                if (toGet == null)
                {
                    return NotFound();
                }
                return Json(toGet);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("Taches")]
        public IActionResult CreateTache([FromBody] Tache tache)
        {
            // Add tache to database
            try
            {
                _db.Taches.Add(tache);
                _db.SaveChanges();
                return Json(tache);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Taches/{id}")]
        public IActionResult UpdateTache(int id, [FromBody] Tache tache)
        {
            // Update tache in database
            try
            {
                Tache? toUpdate = _db.Taches.Find(id);
                if (toUpdate == null)
                {
                    return NotFound();
                }
                toUpdate.Nom = tache.Nom;

                _db.SaveChanges();
                return Json(toUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Taches/{id}")]
        public IActionResult DeleteTache(int id)
        {
            // Delete tache from database
            try
            {
                Tache? toDelete = _db.Taches.Find(id);
                if (toDelete == null)
                {
                    return NotFound();
                }
                _db.Taches.Remove(toDelete);
                _db.SaveChanges();
                return Json(toDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
