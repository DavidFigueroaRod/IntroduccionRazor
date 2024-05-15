using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class SumaFormularioModel : PageModel
    {
        //Definimos los atributos
        public double suma = 0;
        [BindProperty]
        public string num1 { get; set; } = "";
        [BindProperty]
        public string num2 { get; set; } = "";

        public void OnPost()
        {
            double numero1 = Convert.ToDouble(num1);
            double numero2 = Convert.ToDouble(num2);

            suma = numero1 + numero2;

            ModelState.Clear();
        }


        public void OnGet()
        {
        }
    }
}
