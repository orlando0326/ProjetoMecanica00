using System.Security.Cryptography.X509Certificates;

namespace ProjetoMecanica.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        
        public string telefone { get; set; }

        public string CPF {  get; set; }


    }
}
