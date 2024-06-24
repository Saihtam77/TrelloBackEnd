using Microsoft.AspNetCore.Mvc;
using TrelloBack.Models;
using TrelloBack.Models.DAO;

namespace TrelloBack.Controllers
{
    public class ProjetsController : Controller
    {

        private readonly IProjetDAO _projetDAO;

        public ProjetsController(IProjetDAO projetDAO)
        {
            _projetDAO = projetDAO;
        }

        [HttpGet("Projets")]
        public IActionResult Get()
        {
            // Get all projets from database
            try
            {
                return Json(_projetDAO.GetProjets());
            }
            catch
            {
                return NotFound("No projets found.");
            }


        }
        [HttpGet("Projets/{id}")]
        public IActionResult Get(int id)
        {
            // Get projet by id from database
            try
            {
                Projet projet = _projetDAO.GetProjetById(id);
                if (projet == null)
                {
                    return NotFound("No projet found.");
                }
                return Json(projet);
            }
            catch
            {
                return NotFound("Error while getting projet.");
            }

        }

        [HttpPost("Projets")]
        public IActionResult Post([FromBody] Projet toCreate)
        {
            // Add projet to database
            try
            {
                if (toCreate == null)
                {
                    return BadRequest("Projet is null");
                }
                _projetDAO.AddProjet(toCreate);
                return Json(toCreate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Projets/{id}")]
        public IActionResult Put([FromBody] Projet projet, int id)
        {
            // Update projet in database
            try
            {
                if (projet == null)
                {
                    return BadRequest("Projet is null");
                }
                Projet? toUpdate = _projetDAO.GetProjetById(id);
                if (toUpdate == null)
                {
                    return NotFound();
                }
                toUpdate.Nom = projet.Nom;
                _projetDAO.UpdateProjet(toUpdate);
                return Json(toUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Projets/{id}")]
        public IActionResult Delete(int id)
        {
            // Delete projet from database
            try
            {
                Projet? toDelete = _projetDAO.GetProjetById(id);
                if (toDelete == null)
                {
                    return NotFound();
                }
                _projetDAO.DeleteProjet(toDelete);
                return Json(toDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
