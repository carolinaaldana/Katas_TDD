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
        if(numeros == "") 
            return 0;
        return 0;
    }
}