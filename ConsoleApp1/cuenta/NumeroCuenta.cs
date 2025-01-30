public class NumeroCuenta
{
    private string entidad;
    private string sucursal;
    private string dcEntSuc;
    private string dcNumero;
    private string cuenta;

    public NumeroCuenta(in string numero){
   


    }
    private bool formatoCorrecto(in string numero){
             string entidadAux;
    string sucursalAux;
    string dcEntSucAux;
    string dcNumeroAux;
    string cuentaAux;
    //Numero = 1111 2222 33 4444444444
    entidadAux = numero.Substring(0,4);
    sucursalAux = numero.Substring(4,4);
    dcEntSucAux = numero.Substring(8,1);
    
    cuentaAux = numero.Substring(10,10);



    
        return false;
    }
    private bool dcCorrecto(in string dc, in string digitos, in int[] ponderaciones){
    
        return false;
    }
    public string ToString(){
        return "";
    }    

    
}