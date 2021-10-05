namespace TesteProverDominio.Entidades
{
    public class Contato : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cargo { get; set; }


        //public Cargo Cargo { get; set; }
    }
}
