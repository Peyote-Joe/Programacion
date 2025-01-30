
class Cuenta
{
    private string titular;
    private double saldo;
    private string numero;
    public Cuenta(in string numero, in string titular){
        this.numero = numero;
        this.titular = titular;
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
    public string Tostring(){
        return titular;
    }
}
