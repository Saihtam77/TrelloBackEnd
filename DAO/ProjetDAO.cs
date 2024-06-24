namespace TrelloBack.Models.DAO
{

    public interface IProjetDAO
    {
        List<Projet> GetProjets();
        Projet GetProjetById(int id);

        void AddProjet(Projet projet);

        void UpdateProjet(Projet projet);

        void DeleteProjet(Projet projet);

    }

    public class ProjetDAO: IProjetDAO
    {
        private readonly DatabaseContext _db;

        public ProjetDAO(DatabaseContext db)
        {
            _db = db;
        }

        public List<Projet> GetProjets()
        {
            return _db.Projets.ToList();
        }

        public Projet GetProjetById(int id)
        {
            return _db.Projets.Find(id);
        }

        public void AddProjet(Projet projet)
        {
            _db.Projets.Add(projet);
            _db.SaveChanges();
        }

        public void UpdateProjet(Projet projet)
        {
            _db.Projets.Update(projet);
            _db.SaveChanges();
        }

        public void DeleteProjet(Projet projet)
        {
            _db.Projets.Remove(projet);
            _db.SaveChanges();
        }

    }
}