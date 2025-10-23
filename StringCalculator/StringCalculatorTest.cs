namespace StringCalculator;

public class StringCalculator
{
    [Fact]
    public void Si_Envio_Cadena_Vacia_Devuelve_Cero ()
    {
        var resultado = Suma("");
        resultado.Equals(0);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    public void Si_Envio_Un_Numero_Devuelve_El_Mismo_Numero(string numero)
    {
        var resultado = Suma(numero);
        resultado.Equals(numero);
    }

    private string Suma(string numeros)
    {
        if(numeros == "") 
            return "0";
        return numeros;
    }
}