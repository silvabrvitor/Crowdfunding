using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroSolicitacoes.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        [Display(Name = "Curso")]
        public int CursoId { get; set; }

        public Curso Curso { get; set; }
    }
}
