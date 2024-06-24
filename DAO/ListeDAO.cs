namespace TrelloBack.Models.DAO
{
    public interface IListeDAO
    {   
        List<Liste> GetListes();
        Liste GetListeById(int id);
        List<Liste> GetListesByProjetId(int projetId);

        void AddListe(Liste liste);

        void UpdateListe(Liste liste);

        void DeleteListe(Liste liste);

    }

    public class ListeDAO : IListeDAO
    {
        private readonly DatabaseContext _db;

        public ListeDAO(DatabaseContext db)
        {
            _db = db;
        }

        public List<Liste> GetListes()
        {
            return _db.Listes.ToList();
        }

        public Liste GetListeById(int id)
        {
            return _db.Listes.Find(id);
        }

        public List<Liste> GetListesByProjetId(int projetId)
        {
            return _db.Listes.Where(l => l.ProjetId == projetId).ToList();
        }

        public void AddListe(Liste liste)
        {
            _db.Listes.Add(liste);
            _db.SaveChanges();
        }

        public void UpdateListe(Liste liste)
        {
            _db.Listes.Update(liste);
            _db.SaveChanges();
        }

        public void DeleteListe(Liste liste)
        {
            _db.Listes.Remove(liste);
            _db.SaveChanges();
        }

    }
}