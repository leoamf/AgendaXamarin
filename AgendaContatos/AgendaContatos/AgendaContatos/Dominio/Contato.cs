using SQLite;

namespace AgendaContatos.Dominio
{
    [Table("Contato")]
    public class Contato
    {
        [Column("id"), PrimaryKey(), AutoIncrement()]
        public int Id
        {
            get;
            set;
        }

        [Column("nome")]
        public string Nome
        {
            get;
            set;
        } 

        [Column("telefone")]
        public string Telefone
        {
            get;
            set;
        }
          
    }
}
