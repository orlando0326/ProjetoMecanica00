namespace ProjetoMecanica.Models
{
    public class Agendamento
    {
        public int id { get; set; }
        public DateTime Data { get; set; }
        public string Servico { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
