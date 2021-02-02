using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroSolicitacoes.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Display(Name = "Nome do Curso")]
        public string NomeDoCurso { get; set; }
    }
}
