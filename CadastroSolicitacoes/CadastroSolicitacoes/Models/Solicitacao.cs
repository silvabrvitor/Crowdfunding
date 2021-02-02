using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroSolicitacoes.Models
{
    public class Solicitacao
    {
        public int Id { get; set; }
        [Display(Name ="Descrição da Solicitação")]
        public string Descricao { get; set; }
        [Display(Name ="Data")]
        public DateTime DataSolicitacao { get; set; }
        [Display(Name ="Nome do Aluno")]
        public int AlunoId { get; set; }

        public Aluno Aluno { get; set; }
    }
}
