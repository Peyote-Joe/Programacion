using System.Text.RegularExpressions;
public class NumeroCuenta
{
    private string entidad;
    private string sucursal;
    private string dcEntSuc;
    private string dcNumero;
    private string cuenta;

    public NumeroCuenta(in string numero)
    {
        entidad = dcEntSuc = dcNumero = cuenta = sucursal = "";

        if (!formatoCorrecto(numero))
        {
            throw new NumeroCuentaIncorrectoException("Numero cuenta incorrecto");
        }
        if (!DcCorrecto(dcEntSuc, entidad + sucursal, [4, 8, 5, 10, 9, 7, 3, 6]))
        {
            throw new NumeroCuentaIncorrectoException("Numero de control de entidad y sucursal incorrecto");
        }
        if (!DcCorrecto(dcNumero, cuenta, [1, 2, 4, 8, 5, 10, 9, 7, 3, 6]))
        {
            throw new NumeroCuentaIncorrectoException("Numero de control de numero de cuenta incorrecto");
        }
    }
    private bool formatoCorrecto(in string numero)
    {
        //Numero = 1111 2222 33 4444444444 
        //20 cifras del 0 al 9 
        bool resultado = false;

        Regex patronCuenta = new Regex(@"^(?<entidad>\d{4})[-\s]?(?<sucursal>\d{4})[-\s]?(?<dcEntSuc>\d)[-\s]?(?<dcNumero>\d)[-\s]?(?<cuenta>\d{10})");
        Match coincidencia = patronCuenta.Match(numero);
        
        if(coincidencia.Success){
            
            entidad = coincidencia.Groups["entidad"].Value;
            sucursal = coincidencia.Groups["sucursal"].Value;
            dcEntSuc = coincidencia.Groups["dcEntSuc"].Value;
            dcNumero = coincidencia.Groups["dcNumero"].Value;
            cuenta = coincidencia.Groups["cuenta"].Value;
            resultado = true;
        }
        return resultado;
    }
    private bool DcCorrecto(in string dc, in string digitos, in int[] ponderaciones)
    {

        bool resultado = false;
        int valor = 0;
        for (int i = 0; i < digitos.Length; i++)
        {
            valor += ponderaciones[i] * (int)char.GetNumericValue(digitos[i]);
        }

        valor = (11 - (valor % 11));//valor = numero entre 0 y 11
        if (valor == 10) valor = 1;
        if (valor == 11) valor = 0;

        if (valor.ToString() == dc)
        {
            resultado = true;
        }


        /* 
        Asi es como yo lo hubiera hecho sin los grupos de expresiones regulares

        if (digitos.Length == ponderaciones.Length && digitos.Length == 10)
        {
            if (valor == (int)char.GetNumericValue(dc[0]))
            {
                resultado = true;
            }
        }*/
        return resultado;
    }
    public override string ToString()
    {
        return  "\n\t\tEntidad: "+entidad+
                "\n\t\tSucursal: "+sucursal+
                "\n\t\tDigito de control: "+dcEntSuc+dcNumero+
                "\n\t\tNumero de cuenta: "+ cuenta;
    }


}