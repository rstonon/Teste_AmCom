namespace Questao1
{
    class ContaBancaria
    {
        public int _numero;
        public string _titular;
        double _depositoInicial;
        public double _saldo = 0;
        public ContaBancaria(int numero, string titular, double depositoInicial = 0)
        {
            _numero = numero;
            _titular= titular;
            _depositoInicial = depositoInicial;
            _saldo += _depositoInicial;
        }

        public double Deposito(double valor)
        {
            //double saldo = _saldo;

            _saldo += valor;

            return _saldo;
        }

        public double Saque(double valor)
        {
            _saldo -= (valor + 3.5);

            return _saldo;
        }
    }
}
