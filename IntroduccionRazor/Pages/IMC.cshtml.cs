using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class IMCModel : PageModel
    {
        public double resultado = 0;

        [BindProperty]
        public string peso { get; set; } = "";

        [BindProperty]
        public string altura { get; set; } = "";

        public void OnPost()
        {
            double peso_convert = Convert.ToDouble(peso);
            double altura_convert = Convert.ToDouble(altura);

            resultado = peso_convert / Math.Pow(altura_convert,2);

            ModelState.Clear();
        }


        public void OnGet()
        {
        }
    }
}
