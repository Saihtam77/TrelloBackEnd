using Microsoft.AspNetCore.Mvc;
using TrelloBack.Models;
using TrelloBack.Models.DAO;

namespace TrelloBack.Controllers
{
    public class ListesController : Controller
    {

        private readonly IListeDAO _listeDAO;

        public ListesController(IListeDAO listeDAO)
        {
            _listeDAO = listeDAO;
        }
        
        [HttpGet("Listes")]
        public IActionResult Get()
        {
            try
            {
                List<Liste> listes = _listeDAO.GetListes();
                if (listes == null)
                {
                    return NotFound("No listes found.");
                }
                return Json(listes);
            }
            catch
            {
                return NotFound("Error while getting listes.");
            }
        }
        [HttpGet("Listes/{id?}")]
        public IActionResult Get(int id)
        {
            try
            {
                Liste liste = _listeDAO.GetListeById(id);
                if (liste == null)
                {
                    return NotFound("No liste found.");
                }
                return Json(liste);
            }
            catch
            {
                return NotFound("Error while getting liste.");
            }
        }


        [HttpGet("Listes/GetListesByProjetId/{id?}")]
        public IActionResult GetListesByProjetId(int id)
        {
            try
            {
                List<Liste> listes = _listeDAO.GetListesByProjetId(id);
                if (listes == null)
                {
                    return NotFound("No listes found.");
                }
                return Json(listes);
            }
            catch
            {
                return NotFound("Error while getting listes.");
            }

        }

        [HttpPost("Listes")]
        public IActionResult Post([FromBody] Liste liste)
        {
            // Add liste to database
            try
            {
                if(liste==null)
                {
                    return BadRequest("Liste is null.");
                }
                _listeDAO.AddListe(liste);
                return Ok();
            }
            catch
            {
                return BadRequest("Error while adding liste.");
            }
        }

        [HttpPut("Listes/{id}")]
        public IActionResult Put(int id, [FromBody] Liste liste)
        {
            // Update liste in database
            try
            {
                if (liste == null)
                {
                    return BadRequest("Liste is null");
                }
                
                liste.Id = id;
                _listeDAO.UpdateListe(liste);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("Listes/{id}")]
        public IActionResult Delete(int id)
        {
            // Delete liste from database
            try
            {
                Liste liste = _listeDAO.GetListeById(id);
                _listeDAO.DeleteListe(liste);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

    }
}
