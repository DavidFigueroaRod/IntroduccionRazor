using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class sumatoriaEcModel : PageModel
    {
        [BindProperty]
        public double A { get; set; } = 0;
        [BindProperty]
        public double B { get; set; } = 0;
        [BindProperty]
        public double X { get; set; } = 0;
        [BindProperty]
        public double Y { get; set; } = 0;
        [BindProperty]
        public int N { get; set; } = 0;

        public List<double> ListaResultadosK { get; private set; } = new List<double>();

        public double resultadoSencillo { get; set; }
        public double ResultadoLargo { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            resultadoSencillo = CalculoSencillo();
            ResultadoLargo = CalculoLargo();
            ModelState.Clear();
        }

        public double CalculoSencillo()
        {
            return Math.Pow(((A * X) + (B * Y)), N);
        }

        public double CalculoLargo()
        {
            double resultadoFinal = 0;

            for (int k = 0; k <= N; k++)
            {
                double coeficienteBinomial = CalcularCoeficienteBinomial(N, k);
                double potenciaA = N - k;
                double potenciaB = k;

                double resultado = coeficienteBinomial * Math.Pow(A * X, potenciaA) * Math.Pow(B * Y, potenciaB);
                ListaResultadosK.Add(resultado);
                resultadoFinal += resultado;
            }

            return resultadoFinal;
        }

        public static long CalcularFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("El factorial no está definido para números negativos.", nameof(n));
            }

            if (n == 0)
            {
                return 1;
            }

            long resultado = 1;
            for (int i = 2; i <= n; i++)
            {
                resultado *= i;
            }

            return resultado;
        }

        public static double CalcularCoeficienteBinomial(int n, int k)
        {
            if (k < 0 || k > n)
            {
                return 0;
            }

            return CalcularFactorial(n) / (CalcularFactorial(k) * CalcularFactorial(n - k));
        }

    }
 }