using System;
using Aspects.Attributes;

namespace Aspects
{
    [Middleware]
    public class UnaClaseDePrueba : ContextBoundObject
    {   
		// Pon aqui tu propio constructor si crees que es necessario
		// pero para hacerlo divertido, hazlo con y sin parametros
		
		/// <summary>
		/// Esta es un metodo de ejemplo para hacer el 
		/// tipico hola mundo
		/// </summary>
		/// <param name="name">
		/// A <see cref="System.String"/>
		/// </param>
		public void Saluda (string name) 
		{
		   Console.WriteLine ("Hola {0}", name);
	    }
		
		// Pon aqui tu propio metodo. Por ejemplo, intenta poner 
		// algo del estilo de sumar o restar de la calculadora
		
		
		
		// si quieres ver algo interesante, llamame
		public string Fortune
		{
			get { return "No tienes nada que hacer"; }
		}
	}
}
