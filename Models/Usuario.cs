namespace Models
{
    sealed class Usuario
    {
        private Int32 id;
        private String nome;
        private String email;
        private String senha;

        private Usuario(int id, string nome, string email, string senha)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
        }
    }
}