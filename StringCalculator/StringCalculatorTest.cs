using System.Text.RegularExpressions;

namespace StringCalculator;

public class StringCalculator
{
    [Fact]
    public void Si_EnvioCadenaVacia_DevuelveCero ()
    {
        // Act
        var resultado = Suma("");
        
        // Assert
        resultado.Equals(0);
    }

    [Theory]
    [InlineData("1",1)]
    [InlineData("2",2)]
    public void Si_EnvioUnNumero_DevuelveElMismoNumero(string numEntrada, int numEsperado)
    {
        // Act
        var resultado = Suma(numEntrada);
        
        // Assert
        resultado.Equals(numEsperado);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,3", 5)]
    public void Si_EnvioDosNumeros_DevuelveLaSuma(string numEntrada, int numEsperado)
    {
        // Act
        var resultado = Suma(numEntrada);
        
        // Assert
        resultado.Equals(numEsperado);
    }
    
    [Theory]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    public void Si_EnvioUnaCantidadDeNumerosDesconocida_DevuelveLaSuma(string numEntrada, int numEsperado)
    {
        // Act
        var resultado = Suma(numEntrada);
        
        // Assert
        resultado.Equals(numEsperado);
    }

    [Fact]
    public void Si_EnvioVariosNumeros_SeparadosPorSaltosDeLineaoComas_DevuelveLaSuma()
    {
        // Act
        var resultado = Suma("1\n2,3");
        
        // Assert
        resultado.Equals(6);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    [InlineData("//;\n1;2", 3)]
    public void Si_EnvioVariosNumeros_SeparadosPorCualquierCaracter_DevuelveLaSuma(string numEntrada, int numEsperado)
    {
        // Act
        var resultado = Suma(numEntrada);
        
        // Assert
        resultado.Equals(numEsperado);
        
    }

    [Fact]
    public void Si_EnvioNumerosNegativos_DevuelveMensajeConListaDeNumerosNegativos()
    {
        // Act
        var resultado = Assert.Throws<Exception>(() => Suma("1,-2,-3"));
        
        // Assert
        Assert.Equal("Números negativos no permitidos: -2,-3", resultado.Message);

    }

    [Theory]
    [InlineData("5,1030, 2", 7)]
    [InlineData("1;1001//2,5", 8)]
    public void Si_EnvioNumerosMayoresDeMilIgnorarlos_DevuelveLaSuma(string numEntrada, int numEsperado)
    {
        // Act
        var resultado = Suma(numEntrada);
        
        // Assert
        resultado.Equals(numEsperado);
    }

    private int Suma(string numeros)
    {
        if (string.IsNullOrWhiteSpace(numeros))
            return 0;

        var matches = Regex.Matches(numeros, @"-?\d+");
        var valores = matches.Select(m => int.Parse(m.Value)).ToList();
        
        var negativos = valores.Where(x => x < 0).ToList();
        if (negativos.Any())
        {
            var lista = string.Join(",", negativos);
            throw new Exception($"Números negativos no permitidos: {lista}");
        }

        return valores.Where(x => x <= 1000).Sum();

    }
}