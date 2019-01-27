using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.MVC
{
    public class RoteamentoPadrao
    {
        public static Task TratamentoPadrao(HttpContext context)
        {
            var classe = context.GetRouteValue("classe").ToString();
            var metodoNome = context.GetRouteValue("metodo").ToString();

            var tipo = Type.GetType($"Alura.ListaLeitura.App.Logica.{classe}.Logica");
            var metodo = tipo.GetMethods().Where(method => method.Name == metodoNome).FirstOrDefault();
            var requestDelegate = Delegate.CreateDelegate(typeof(RequestDelegate), metodo) as RequestDelegate;

            return requestDelegate.Invoke(context);
        }
    }
}
