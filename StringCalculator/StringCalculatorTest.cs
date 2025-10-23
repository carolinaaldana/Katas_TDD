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
    [InlineData("1",1)]
    [InlineData("2",2)]
    public void Si_Envio_Un_Numero_Devuelve_El_Mismo_Numero(string numEntrada, int numEsperado)
    {
        var resultado = Suma(numEntrada);
        resultado.Equals(numEsperado);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,3", 5)]
    public void Si_Envio_Dos_Numeros_Devuelve_La_Suma(string numEntrada, int numEsperado)
    {
        var resultado = Suma(numEntrada);
        resultado.Equals(numEsperado);
    }

    private int Suma(string numeros)
    {
        if(numeros == "") 
            return int.Parse("0");
        
        var separador = numeros.Split(",");
        return separador.Select(int.Parse).Sum();
    }
}