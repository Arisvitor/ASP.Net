using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models{
            
    [MetadataType(typeof(CategoriaMetadado))]
    public partial class Categoria { }

    public class CategoriaMetadado
    {
        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{1,1000}$",
        ErrorMessage = "Este campo deve ter entre 1 e 1000 caracteres (letras ou espaços).")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{2,80}$",
        ErrorMessage = "Este campo deve ter entre 2 e 80 caracteres (letras ou espaços).")]
        public string Descricao { get; set; }
    }
}