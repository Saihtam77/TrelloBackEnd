using Microsoft.AspNetCore.Mvc;
using TrelloBack.Models;

namespace TrelloBack.Controllers
{
    public class ProjetsController : Controller
    {

        private readonly DatabaseContext _db;

        public ProjetsController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet("Projets")]
        public IActionResult GetProjets()
        {
            // Get projets from database
            try
            {
                if (_db.Projets == null)
                {
                    return NotFound();
                }
                return Json(_db.Projets);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
        [HttpGet("Projets/{id}")]
        public IActionResult GetProjets(int id)
        {
            // Get projet from database
            try
            {
                if (_db.Projets == null)
                {
                    return NotFound("No projets found");
                }

                Projet? toGet = _db.Projets.Find(id);
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

        [HttpPost("Projets")]
        public IActionResult CreateProjet([FromBody] Projet toCreate)
        {
            // Create projet in database
            try
            {
                if (toCreate == null)
                {
                    return BadRequest("Projet is null");
                }
                _db.Projets.Add(toCreate);
                _db.SaveChanges();
                return Json(toCreate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Projets/{id}")]
        public IActionResult UpdateProjet([FromBody] Projet projet, int id)
        {
            // Update projet in database
            try
            {
                if (projet == null)
                {
                    return BadRequest("Projet is null or projet id doesn't match");
                }

                Projet? toUpdate = _db.Projets.Find(id);
                if (toUpdate == null)
                {
                    return NotFound();
                }
                toUpdate.Nom = projet.Nom;

                _db.Projets.Update(toUpdate);
                _db.SaveChanges();
                return Json(toUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Projets/{id}")]
        public IActionResult DeleteProjet(int id)
        {
            // Delete projet from database
            try
            {
                Projet? toDelete = _db.Projets.Find(id);
                if (toDelete == null)
                {
                    return NotFound();
                }
                _db.Projets.Remove(toDelete);
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
