using System;
namespace Aspects 
{
    public class AOPMain 
    {
	    public static void Main() 
        {
		    UnaClaseDePrueba obj = new UnaClaseDePrueba ();
			
		    obj.Saluda ("A mis alumnos");
			
			// amplia tu clase de ejemplo con nuevos métodos
			// y llamalos
			
            Console.WriteLine("Fortune me dice algo que no esperaba:" +obj.Fortune);

            Console.WriteLine("Pulsa Enter para terminar");
            Console.ReadLine();
	    }
	}
}
