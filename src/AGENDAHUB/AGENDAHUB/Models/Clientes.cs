﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AGENDAHUB.Models
{
    [Table("Clientes")]
    public class Clientes
    {
        [Key]
        public int ID_Cliente { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CPF!")]
        [Validations.CPF]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Contato!")]
        [Validations.Telefone]
        public string Contato { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Email!")]
        public string Email { get; set; }

        public string Observacao { get; set; }


        //Formatação de CPF e contato
        public string FormatarCPF()
        {
            if (string.IsNullOrWhiteSpace(CPF))
            {
                return string.Empty;
            }

            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        public string FormatarContato()
        {
            if (string.IsNullOrWhiteSpace(Contato))
            {
                return string.Empty;
            }

            // Remove caracteres não numéricos do contato
            var contatoNumerico = new string(Contato.Where(char.IsDigit).ToArray());

            return Convert.ToUInt64(contatoNumerico).ToString(@"\(00\) 0 0000-0000");
        }



        //public string Login { get; set; }
        //public string Senha { get; set; }



        //// Relacionamentos
        //public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
        //public List<MovimentacaoFinanceira> MovimentacaoFinanceira { get; set; } = new List<MovimentacaoFinanceira>();

        ////Funcionalidades
        //public void CadastrarAgendamento(Agendamento agendamento)
        //{

        //}

        //public void PagarAgendamento(MovimentacaoFinanceira movimentacaoFinanceira)
        //{

        //}
    }
}
