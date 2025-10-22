using System.Diagnostics.CodeAnalysis;

namespace StringCalculator;

public class StringCalculator
{
    [Fact]
    public void Si_Envio_Cadena_Vacia_Devuelve_Cero ()
    {
        var resultado = Suma("");
        resultado.Equals(0);
    }

    private int Suma(string numeros)
    {
        return 0; 
    }
}