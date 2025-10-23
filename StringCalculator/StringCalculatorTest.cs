namespace StringCalculator;

public class StringCalculator
{
    [Fact]
    public void Si_Envio_Cadena_Vacia_Devuelve_Cero ()
    {
        // Act
        var resultado = Suma("");
        
        // Assert
        resultado.Equals(0);
    }

    [Theory]
    [InlineData("1",1)]
    [InlineData("2",2)]
    public void Si_Envio_Un_Numero_Devuelve_El_Mismo_Numero(string numEntrada, int numEsperado)
    {
        // Act
        var resultado = Suma(numEntrada);
        
        // Assert
        resultado.Equals(numEsperado);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,3", 5)]
    public void Si_Envio_Dos_Numeros_Devuelve_La_Suma(string numEntrada, int numEsperado)
    {
        // Act
        var resultado = Suma(numEntrada);
        
        // Assert
        resultado.Equals(numEsperado);
    }
    
    [Theory]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    public void Si_Envio_Una_Cantidad_De_Numeros_Desconocida_Devuelve_La_Suma(string numEntrada, int numEsperado)
    {
        // Act
        var resultado = Suma(numEntrada);
        
        // Assert
        resultado.Equals(numEsperado);
    }

    private int Suma(string numeros)
    {
        if (string.IsNullOrEmpty(numeros))
            return 0;
        
        var partes = numeros.Split(",");
        return partes.Select(int.Parse).Sum();
    }
}