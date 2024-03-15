using System.ComponentModel.DataAnnotations;

namespace PruebaToDoList.Client.Moldes
{
    public class FormName
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(80, ErrorMessage = "Maximo 80 caracteres")]
        public string Name { get; set; } = string.Empty;
    }
}
