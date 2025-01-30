
using System.Timers;

class Cuenta
{
    private string titular;
    private double saldo;
    private NumeroCuenta numero;
    public Cuenta(in string numero, in string titular){
        this.numero = new NumeroCuenta(numero);
        this.titular = titular;
        saldo = 0;
    }
    public void Ingreso(in double cantidad){
        saldo+=cantidad;
    }
    public void Reintegro(in double cantidad){
        if(cantidad>saldo){
            throw new SaldoInsuficienteException("El reintegro es mayor que el saldo");
        }
        saldo-=cantidad;
    }
    override
    public string ToString(){
        return  "El titular es: "+titular+
                "\nInformacion de la cuenta: "+
                "\n\tSaldo:\t"+saldo+ 
                "\n\tCuenta: "+numero.ToString();
    }
}
