using System.Security.Cryptography.X509Certificates;

namespace ProjetoMecanica.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        
        public string poblema { get; set; }
        public string cor {  get; set; }
        public int ClienteId   { get; set; }
        public Cliente Cliente { get; set; }
    }
}
