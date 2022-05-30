using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    [MetadataType(typeof(EstabelecimentoMetadado))]
    public partial class Estabelecimento { }

    public class EstabelecimentoMetadado
    {
        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{1,100}$",
        ErrorMessage = "Este campo deve ter entre 1 e 100 caracteres (letras ou espaços).")]
        public int IdEstabelecimento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{1,100}$",
        ErrorMessage = "Este campo deve ter entre 1 e 100 caracteres (letras ou espaços).")]
        public int IdCidade { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{1,100}$",
        ErrorMessage = "Este campo deve ter entre 1 e 100 caracteres (letras ou espaços).")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{5,80}$",
        ErrorMessage = "Este campo deve ter entre 5 e 80 caracteres (letras ou espaços).")]
        public string NomeComercial { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{5,80}$",
        ErrorMessage = "Este campo deve ter entre 5 e 80 caracteres (letras ou espaços).")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{5,200}$",
        ErrorMessage = "Este campo deve ter entre 5 e 80 caracteres (letras ou espaços).")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{11,20}$",
        ErrorMessage = "Este campo deve ter entre 11 e 20 caracteres (letras ou espaços).")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório. ", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZÁÂáâãÉÊéêÍíÓÔóôõÚúç\s]{5,80}$",
        ErrorMessage = "Este campo deve ter entre 5 e 80 caracteres (letras ou espaços).")]
        public string Site { get; set; }
    }
}