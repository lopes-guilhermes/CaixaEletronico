using CaixaEletronico.Enums;

namespace CaixaEletronico.Models
{
    public class Saque
    {
        public int Quantidade { get; set; }
        public CedulaEnum Cedula { get; set; }
    }
}
