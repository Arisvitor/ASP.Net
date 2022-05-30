using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Pesquisa
    {
        public int IdCidade { get; set; }
        public int IdCategoria { get; set; }
    }
}