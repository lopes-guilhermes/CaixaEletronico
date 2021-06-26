using CaixaEletronico.Enums;

namespace CaixaEletronico.Models
{
    public class Saque
    {
        public int Quantidade { get; set; }
        public CedulaEnum Cedula { get; set; }

        public Saque()
        {

        }

        public Saque(int quantidade, CedulaEnum cedula)
        {
            this.Quantidade = quantidade;
            this.Cedula = cedula;
        }

        public override string ToString()
            => $"{Quantidade} cédula(s) de ${(int)Cedula} reais";

        public override bool Equals(object obj)
        {
            var compareObj = obj as Saque;
            return this.Quantidade == compareObj.Quantidade 
                && (int)this.Cedula == (int)compareObj.Cedula;
        }

        public override int GetHashCode() 
            => Quantidade.GetHashCode() ^ Cedula.GetHashCode();
    }
}
