using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    [MetadataType(typeof(TipoQuartoMetadado))]
    public partial class TipoQuarto { }

    public class TipoQuartoMetadado
    {
        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{1,100}$",
        ErrorMessage = "Este campo deve ter entre 1 e 100 caracteres (letras ou espaços).")]
        public int IdTipoQuarto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{5,80}$",
        ErrorMessage = "Este campo deve ter entre 5 e 80 caracteres (letras ou espaços).")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{3,15}$",
        ErrorMessage = "Este campo deve ter entre 3 e 15 caracteres (letras ou espaços).")]
        public decimal ValorDiaria { get; set; }
    }
}