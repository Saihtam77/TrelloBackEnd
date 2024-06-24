namespace TrelloBack.Models.DAO
{
    public interface ICommentaireDAO
    {
        List<Commentaire> GetCommentaires();
        Commentaire GetCommentaireById(int id);
        List<Commentaire> GetCommentairesByTacheId(int tacheId);
        void AddCommentaire(Commentaire commentaire);
        void UpdateCommentaire(Commentaire commentaire);
        void DeleteCommentaire(Commentaire commentaire);

    }

    public class CommentaireDAO : ICommentaireDAO
    {
        private readonly DatabaseContext _db;

        public CommentaireDAO(DatabaseContext db)
        {
            _db = db;
        }

        public List<Commentaire> GetCommentaires()
        {
            return _db.Commentaires.ToList();
        }

        public Commentaire GetCommentaireById(int id)
        {
            return _db.Commentaires.Find(id);
        }

        public List<Commentaire> GetCommentairesByTacheId(int tacheId)
        {
            return _db.Commentaires.Where(c => c.TacheId == tacheId).ToList();
        }

        public void AddCommentaire(Commentaire commentaire)
        {
            _db.Commentaires.Add(commentaire);
            _db.SaveChanges();
        }

        public void UpdateCommentaire(Commentaire commentaire)
        {
            _db.Commentaires.Update(commentaire);
            _db.SaveChanges();
        }

        public void DeleteCommentaire(Commentaire commentaire)
        {
            _db.Commentaires.Remove(commentaire);
            _db.SaveChanges();
        }


    }
}