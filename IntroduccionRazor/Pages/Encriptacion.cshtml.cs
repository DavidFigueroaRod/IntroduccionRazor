using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace IntroduccionRazor.Pages
{
    public class EncriptacionModel : PageModel
    {
        [BindProperty]
        public string Texto { get; set; } = "";

        [BindProperty]
        public string Accion { get; set; } = "";

        [BindProperty]
        public int N { get; set; }

        public string TextoResultado { get; set; } = "";

        //Aqui va el onpost
        public void OnPost()
        {
            TextoResultado = CodificarDecodificarTexto(Texto, Accion, N);
        }

        //--------------
        private string CodificarDecodificarTexto(string texto, string accion, int n)
        {
            StringBuilder resultado = new StringBuilder();

            foreach (char caracter in texto)
            {
                if (char.IsLetter(caracter))
                {
                    char inicio = char.IsUpper(caracter) ? 'A' : 'a';
                    char codificado;

                    if (accion == "Codificar")
                    {
                        codificado = (char)(((caracter - inicio + n) % 26) + inicio);
                    }
                    else // Decodificar
                    {
                        codificado = (char)(((caracter - inicio - n + 26) % 26) + inicio);
                    }

                    resultado.Append(codificado);
                }
                else
                {
                    resultado.Append(caracter); // Mantener caracteres que no son letras
                }
            }

            return resultado.ToString();
        }



    }
}

