using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("sessao")]

    public class Sessao
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id;

        [Column("usuario_id")]
        [ForeignKey("id")]
        public Usuario Usuario;
        
        [Column("token")]
        public String Token;
        
        [Column("data_criacao")]
        public DateTime DataCriacao;
        
        [Column("data_expiracao")]
        public DateTime DataExpiracao;

        public Sessao(Usuario usuario, string token, DateTime dataCriacao)
        {
            Usuario = usuario;
            Token = token;
            DataCriacao = dataCriacao;
        }
    }
}