using System.Security.Cryptography;
using System.Text;

namespace EstartandoDevsCore.DomainObjects;

public abstract class Aggregate
{
    /// <summary>
    /// Gera um hash através do id 
    /// </summary>
    public virtual string ObterHash()
    {
        return GerarHashMD5(Guid.NewGuid().ToString());
    }

    /// <summary>
    /// Utilizar para gerar um hash de valores personalizados
    /// </summary>
    /// <param name="values">valores concatenados em string</param>
    /// <returns></returns>
    protected string ObterHash(string valor)
    {
        return GerarHashMD5(valor);
    }

    private string GerarHashMD5(string input)
    {
        // Calculate MD5 hash from input 
        var md5 = MD5.Create();
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hash = md5.ComputeHash(inputBytes);

        // Convert byte array to hex string 
        var sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }

        return sb.ToString();
    }
}
