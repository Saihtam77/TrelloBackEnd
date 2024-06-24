namespace TrelloBack.Models.DAO
{
    public interface ITacheDAO
    {
        public void AddTache(Tache tache);
        public void UpdateTache(Tache tache);
        public void DeleteTache(Tache tache);
        public Tache GetTacheById(int id);

        public List<Tache> GetTachesByListeId(int listId);
        public List<Tache> GetTaches();
    }

    public class TacheDAO : ITacheDAO
    {
        private readonly DatabaseContext _db;

        public TacheDAO(DatabaseContext db)
        {
            _db = db;
        }

        public List<Tache> GetTaches()
        {
            return _db.Taches.ToList();
        }
        public Tache GetTacheById(int id)
        {
            return _db.Taches.Find(id);
        }

        public List<Tache> GetTachesByListeId(int listId)
        {
            return _db.Taches.Where(t => t.ListeId == listId).ToList();
        }

        

        public void AddTache(Tache tache)
        {
            _db.Taches.Add(tache);
            _db.SaveChanges();
        }

        public void UpdateTache(Tache tache)
        {
            _db.Taches.Update(tache);
            _db.SaveChanges();
        }

        public void DeleteTache(Tache tache)
        {
            _db.Taches.Remove(tache);
            _db.SaveChanges();
        }


    }
}