using Microsoft.AspNetCore.Mvc;
using TrelloBack.Models;

namespace TrelloBack.Controllers
{
    public class CommentairesController : Controller
    {

        private readonly DatabaseContext _db;

        public CommentairesController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet("Commentaires")]
        public IActionResult GetCommentaires()
        {
            // Get commentaires from database
            try
            {
                if (_db.Commentaires == null)
                {
                    return NotFound();
                }
                return Json(_db.Commentaires);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Commentaires/{id?}")]
        public IActionResult GetCommentaires(int id)
        {
            // Get commentaire from database
            try
            {
                if (_db.Commentaires == null)
                {
                    return NotFound("No commentaires found");
                }

                Commentaire? toGet = _db.Commentaires.Find(id);
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


        [HttpGet("Commentaires/GetCommentairesByTacheId/{id?}")]
        public IActionResult GetCommentairesByTacheId(int id)
        {
            // Get commentaires from database by tache id
            try
            {
                if (_db.Commentaires == null)
                {
                    return NotFound("No commentaires found");
                }

                var commentaires = _db.Commentaires.Where(c => c.TacheId == id);
                return Json(commentaires);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        
        //Post
        [HttpPost("Commentaires")]
        public IActionResult CreateCommentaire([FromBody] Commentaire commentaire)
        {
            // Add a new commentaire to the database
            try
            {
                _db.Commentaires.Add(commentaire);
                _db.SaveChanges();
                return Json(commentaire);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Delete
        [HttpDelete("Commentaires/{id}")]
        public IActionResult DeleteCommentaire(int id)
        {
            // Delete a commentaire from the database
            try
            {
                Commentaire? toDelete = _db.Commentaires.Find(id);
                if (toDelete == null)
                {
                    return NotFound();
                }
                _db.Commentaires.Remove(toDelete);
                _db.SaveChanges();
                return Json(toDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Put
        [HttpPut("Commentaires/{id}")]
        public IActionResult UpdateCommentaire(int id, [FromBody] Commentaire commentaire)
        {
            // Update a commentaire in the database
            try
            {
                Commentaire? toUpdate = _db.Commentaires.Find(id);
                if (toUpdate == null)
                {
                    return NotFound();
                }
                toUpdate.Contenu = commentaire.Contenu;
             
                _db.SaveChanges();
                return Json(toUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
