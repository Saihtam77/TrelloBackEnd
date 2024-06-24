namespace TrelloBack.Models.DTO{

    public class ProjetDTO
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public DateTime? CreatedAt { get; set; }   
    }

    public class ListeDTO
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public int ProjetId { get; set; }
    }

    public class TacheDTO
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public int ListeId { get; set; }
    }

    public class CommentaireDTO
    {
        public int Id { get; set; }
        public required string Contenu { get; set; }
        public int TacheId { get; set; }
    }

}