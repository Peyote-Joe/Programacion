public class Program
{
    static void Main(string[] args)
    {
        Cuenta cuenta = new Cuenta("20850103920300731702", "Franco");
        cuenta.Ingreso(1234);
        //cuenta.Reintegro(1234);
        System.Console.WriteLine(cuenta.ToString());
        System.Console.ReadLine();
    }
}
