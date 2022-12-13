namespace bookstore.Domain.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime? DataDeAlteracao { get; set; }
    }
}
