using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class ArreglosMediaModel : PageModel
    {
        public List<int> Numeros {  get; private set; } = new List<int>();
        public int Suma {  get; private set; }
        public double Promedio { get; private set; }
        public int Moda {  get; private set; }
        public int Mediana { get; private set; }


        public void OnGet()
        {
            // Generar números aleatorios
            Random random = new Random();
            Numeros = Enumerable.Range(1, 20).Select(_ => random.Next(0, 101)).ToList();

            // Calcular suma
            Suma = Numeros.Sum();

            // Calcular promedio
            Promedio = Numeros.Average();

            // Calcular moda
            Dictionary<int, int> frecuencias = new Dictionary<int, int>();
            foreach (var numero in Numeros)
            {
                if (frecuencias.ContainsKey(numero))
                {
                    frecuencias[numero]++;
                }
                else
                {
                    frecuencias[numero] = 1;
                }
            }

            int maxFrecuencia = frecuencias.Values.Max();
            Moda = frecuencias.Where(kv => kv.Value == maxFrecuencia).Select(kv => kv.Key).FirstOrDefault();
            // Calcular mediana
            var numerosOrdenados = Numeros.OrderBy(x => x).ToList();
            Mediana = numerosOrdenados[10];
        }

    }
}
