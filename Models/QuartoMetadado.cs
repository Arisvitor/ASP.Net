using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    [MetadataType(typeof(QuartoMetadado))]
    public partial class Quarto { }

    public class QuartoMetadado
    {
        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{1,100}$",
        ErrorMessage = "Este campo deve ter entre 1 e 100 caracteres (letras ou espaços).")]
        public int IdQuarto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{1,100}$",
        ErrorMessage = "Este campo deve ter entre 1 e 100 caracteres (letras ou espaços).")]
        public int IdEstabelecimento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{1,100}$",
        ErrorMessage = "Este campo deve ter entre 1 e 100 caracteres (letras ou espaços).")]
        public int IdTipoQuarto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{1,10}$",
        ErrorMessage = "Este campo deve ter entre 1 e 10 caracteres (letras ou espaços).")]
        [System.Web.Mvc.Remote("VerificaSeNumeroQuartoNaoExiste", "Quarto", AdditionalFields = "IdEstabelecimento",
        ErrorMessage = "Este número de quarto já existe no banco de dados.")]
        public int NumeroQuarto { get; set; }
    }
}