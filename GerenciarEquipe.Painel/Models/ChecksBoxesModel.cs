using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciarEquipe.Painel.Models
{
    public class ChecksBoxesModel
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public bool Checked { get; set; }
    }
}