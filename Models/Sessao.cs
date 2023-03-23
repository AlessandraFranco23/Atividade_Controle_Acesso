using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace Models
{
    [Table("sessao")]

    public class Sessao
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}

        [Column("usuario_id")]
        [ForeignKey("id")]
        public Usuario Usuario{get;set;}
        
        [Column("token")]
        public String Token{get;set;}
        
        [Column("data_criacao")]
        public DateTime DataCriacao{get;set;}
        
        [Column("data_expiracao")]
        public DateTime DataExpiracao{get;set;}


        public Sessao()
        {
        }
        
        public Sessao(Usuario usuario, string token, DateTime dataCriacao)
        {
            Usuario = usuario;
            Token = token;
            DataCriacao = dataCriacao;
        }

    }
}