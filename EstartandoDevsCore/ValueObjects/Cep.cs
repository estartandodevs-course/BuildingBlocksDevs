using System.Text.RegularExpressions;
using EstartandoDevsCore.DomainObjects;
using EstartandoDevsCore.Ultilities;

namespace EstartandoDevsCore.ValueObjects;

public class Cep
{
    public string Numero { get; private set; }

    public string NumeroFormatado
    {
        get
        {
            var Contador = 0;
            var CepFormatado = string.Empty;

            foreach (var digito in Numero)
            {
                if (Contador == 5)
                    CepFormatado += "-";

                CepFormatado += digito;

                Contador++;
            }

            return CepFormatado;
        }
    }

    private readonly string _NumeroFormatado;

    protected Cep() { }

    public Cep(string numero)
    {
        if (string.IsNullOrEmpty(numero)) throw new DomainException("Não foi possível construir um CEP sem um número válido!");

        _NumeroFormatado = numero;

        Numero = numero.ApenasNumeros();
    }

    public bool EstaValido()
    {
        if (string.IsNullOrWhiteSpace(_NumeroFormatado)) return false;

        Regex regex = new Regex(@"^\d{5}-\d{3}$");

        Match match = regex.Match(_NumeroFormatado);

        return match.Success;
    }

}
