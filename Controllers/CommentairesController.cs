using Microsoft.AspNetCore.Mvc;
using TrelloBack.Models;
using TrelloBack.Models.DAO;

namespace TrelloBack.Controllers
{
    public class CommentairesController : Controller
    {

        private readonly ICommentaireDAO _commentaireDAO;

        public CommentairesController(ICommentaireDAO commentaireDAO)
        {
            _commentaireDAO = commentaireDAO;
        }
       


        [HttpGet("Commentaires")]
        public IActionResult Get()
        {
            try
            {
                List<Commentaire> commentaires = _commentaireDAO.GetCommentaires();
                if (commentaires == null)
                {
                    return NotFound("No commentaires found.");
                }
                return Json(commentaires);
            }
            catch
            {
                return NotFound("Error while getting commentaires.");
            }
        }

        [HttpGet("Commentaires/{id?}")]
        public IActionResult Get(int id)
        {
            try
            {
                Commentaire commentaire = _commentaireDAO.GetCommentaireById(id);
                if (commentaire == null)
                {
                    return NotFound("No commentaire found.");
                }
                return Json(commentaire);
            }
            catch
            {
                return NotFound("Error while getting commentaire.");
            }

        }


        [HttpGet("Commentaires/GetCommentairesByTacheId/{id?}")]
        public IActionResult GetCommentairesByTacheId(int id)
        {
            try
            {
                List<Commentaire> commentaires = _commentaireDAO.GetCommentairesByTacheId(id);
                if (commentaires == null)
                {
                    return NotFound("No commentaires found.");
                }
                return Json(commentaires);
            }
            catch
            {
                return NotFound("Error while getting commentaires.");
            }
        }

        //Post
        [HttpPost("Commentaires")]
        public IActionResult Post([FromBody] Commentaire commentaire)
        {
            try
            {
                if (commentaire == null)
                {
                    return BadRequest("Commentaire is null.");
                }
                _commentaireDAO.AddCommentaire(commentaire);
                return Ok();
            }
            catch
            {
                return BadRequest("Error while adding commentaire.");
            }
        }

        //Put
        [HttpPut("Commentaires/{id}")]
        public IActionResult Put(int id, [FromBody] Commentaire commentaire)
        {
            try
            {
                if (commentaire == null)
                {
                    return BadRequest("Commentaire is null.");
                }
                Commentaire commentaireToUpdate = _commentaireDAO.GetCommentaireById(id);
                if (commentaireToUpdate == null)
                {
                    return NotFound("No commentaire found.");
                }
                commentaireToUpdate.Contenu = commentaire.Contenu;
                _commentaireDAO.UpdateCommentaire(commentaireToUpdate);
                return Ok();
            }
            catch
            {
                return NotFound("Error while updating commentaire.");
            }

        }
        //Delete
        [HttpDelete("Commentaires/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Commentaire commentaire = _commentaireDAO.GetCommentaireById(id);
                if (commentaire == null)
                {
                    return NotFound("No commentaire found.");
                }
                _commentaireDAO.DeleteCommentaire(commentaire);
                return Ok();
            }
            catch
            {
                return NotFound("Error while deleting commentaire.");
            }
        }


    }
}
