using Microsoft.AspNetCore.Mvc;
using TrelloBack.Models;
using TrelloBack.Models.DAO;

namespace TrelloBack.Controllers
{
    public class TachesController : Controller
    {
        private readonly ITacheDAO _tacheDAO;

        public TachesController(ITacheDAO tacheDAO)
        {
            _tacheDAO = tacheDAO;
        }


        [HttpGet("Taches")]
        public IActionResult GetTaches()
        {
            // Get all taches from database
            try
            {
                return Json(_tacheDAO.GetTaches());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Taches/{id?}")]
        public IActionResult GetTaches(int id)
        {
            // Get tache from database by id
            try
            {
                Tache tache = _tacheDAO.GetTacheById(id);
                if (tache == null)
                {
                    return NotFound();
                }
                return Json(tache);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("Taches/GetTachesByListeId/{id?}")]
        public IActionResult GetTachesByListeId(int id)
        {
            // Get taches from database by liste id
            try
            {
                return Json(_tacheDAO.GetTachesByListeId(id));
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
                _tacheDAO.AddTache(tache);
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
                Tache? toUpdate = _tacheDAO.GetTacheById(id);
                if (toUpdate == null)
                {
                    return NotFound();
                }
                toUpdate.Nom = tache.Nom;

                _tacheDAO.UpdateTache(toUpdate);
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
                Tache? toDelete = _tacheDAO.GetTacheById(id);
                if (toDelete == null)
                {
                    return NotFound();
                }
                _tacheDAO.DeleteTache(toDelete);
                return Json(toDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
