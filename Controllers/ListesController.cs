using Microsoft.AspNetCore.Mvc;
using TrelloBack.Models;

namespace TrelloBack.Controllers
{
    public class ListesController : Controller
    {

        private readonly DatabaseContext _db;

        public ListesController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet("Listes")]
        public IActionResult GetListes()
        {
            // Get listes from database
            try
            {
                if (_db.Listes == null)
                {
                    return NotFound();
                }
                return Json(_db.Listes);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Listes/{id?}")]
        public IActionResult GetListes(int id)
        {
            // Get liste from database
            try
            {
                if (_db.Listes == null)
                {
                    return NotFound("No listes found");
                }

                Liste? toGet = _db.Listes.Find(id);
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

         [HttpGet("Listes/GetListesByProjetId/{id?}")]
        public IActionResult GetListesByProjetId(int id)
        {
            // Get liste from database
            try
            {
                if (_db.Listes == null)
                {
                    return NotFound("No listes found");
                }

                List<Liste> toGet = _db.Listes.Where(l => l.ProjetId == id).ToList();
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

        [HttpPost("Listes")]
        public IActionResult CreateListes([FromBody] Liste liste)
        {
            // Add liste to database
            try
            {
                if (liste == null)
                {
                    return BadRequest("Liste is null");
                }
                _db.Listes.Add(liste);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Listes/{id}")]
        public IActionResult UpdateListes(int id, [FromBody] Liste liste)
        {
            // Update liste in database
            try
            {
                if (liste == null)
                {
                    return BadRequest("Liste is null");
                }
                Liste? toUpdate = _db.Listes.Find(id);
                if (toUpdate == null)
                {
                    return NotFound();
                }
                toUpdate.Nom = liste.Nom;
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Listes/{id}")]
        public IActionResult DeleteListes(int id)
        {
            // Delete liste from database
            try
            {
                Liste? toDelete = _db.Listes.Find(id);
                if (toDelete == null)
                {
                    return NotFound();
                }
                _db.Listes.Remove(toDelete);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}
