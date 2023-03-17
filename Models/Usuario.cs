using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id;

        [Column("nome")]
        public String Nome;

        [Column("email")]
        public String Email;

        [Column("senha")]
        public String Senha;

        [Column("perfil")]
        public Perfil Perfil;

        public Usuario(string nome, string email, string senha, Perfil perfil)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Perfil = perfil;
        }
    }
}