namespace Questao5.Application.ViewModels
{
    public class ContaCorrenteViewModel
    {
        public ContaCorrenteViewModel(string idContaCorrente, int ativo)
        {
            IdContaCorrente = idContaCorrente;
            Ativo = ativo;
        }

        public string IdContaCorrente { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; }
        public int Ativo { get; set; }
    }
}
