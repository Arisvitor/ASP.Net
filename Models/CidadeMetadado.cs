using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    [MetadataType(typeof(CidadeMetadado))]
    public partial class Cidade { }

    public class CidadeMetadado
    {
        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{1,1000}$",
        ErrorMessage = "Este campo deve ter entre 1 e 1000 caracteres (letras ou espaços).")]
        public int IdCidade { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{2,30}$",
        ErrorMessage = "Este campo deve ter entre 2 e 30 caracteres (letras ou espaços).")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{2,2}$",
        ErrorMessage = "Este campo deve ter 2 caracteres (letras).")]
        public string UF { get; set; }
    }
}