namespace TcpPlcToScadaSincrona.Models
{
    public class AgvDataFormat
    {
        public string idAgv { get; set; }
        public string sinais { get; set; }
        public string posto { get; set; }
        public string comando { get; set; }
        public string velocidade { get; set; }
        public string processo { get; set; }
        public string velAtual { get; set; }
        public string errosAgv { get; set; }
        public string errosPgv { get; set; }
        public string errosMotorPasso { get; set; }
      

    }
}
