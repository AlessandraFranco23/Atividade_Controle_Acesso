using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("id")]
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        [Column("nome")]
        public String Nome {get; set;}

        [Column("email")]
        public String Email{get; set;}

        [Column("senha")]
        public String Senha{get; set;}

        [Column("perfil")]
        public Perfil Perfil{get; set;}
        public Usuario()
        {
        }
        public Usuario(string nome, string email, string senha, Perfil perfil)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Perfil = perfil;
        }
    }
}