using System;
using System.Globalization;
using System.Threading;

namespace FormatarValoresConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Formatação de números !");

            decimal valor = 10000.59m;

            /*
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");
            Console.WriteLine("Formatação com decimais Pt:" + valor.ToString("###,##0.00"));


            Thread.CurrentThread.CurrentCulture = new CultureInfo("us");
            Console.WriteLine("Formatação com decimais:" + valor.ToString("###,##0.00"));
            

            Console.WriteLine("Digite um valor:");
            var valorStr = Console.ReadLine();

            decimal valor2 = Convert.ToDecimal(valorStr);

            Console.WriteLine("Formatação do texto:" + valorStr + " com decimais Default:" + valor2.ToString("###,##0.00"));

            Thread.CurrentThread.CurrentCulture = new CultureInfo("us");
            decimal valor3 = Convert.ToDecimal(valorStr);
            Console.WriteLine("Formatação do texto:" + valorStr + " com decimais Default:" + valor3.ToString("###,##0.00"));
            */
            var cultureInfoUsa = new CultureInfo("en-US");
            Console.WriteLine("Digite uma data:");
            var valorStr = Console.ReadLine();

            DateTime data1;
            try
            {
                data1 = DateTime.Parse(valorStr);
            }
            catch (Exception error)
            {
                
                data1 = DateTime.Parse(valorStr, cultureInfoUsa);
            }
            


            Console.WriteLine("Formatação do texto:" + valorStr + " com decimais Default:" + data1.ToString("dd/MM/yyyy"));

            Console.WriteLine("Formatação do texto:" + valorStr + " com decimais Default:" + data1.ToString("ddd/MMM/yyyy"));

            
            Console.WriteLine("Formatação do texto:" + valorStr + " com decimais Default:" + data1.ToString("dddd MMMM", cultureInfoUsa));

            Console.WriteLine("Formatação do texto:" + valorStr + " com decimais Default:" + data1.ToString("dd/MM/yyyy hh:mm:ss"));

        }
    }
}
