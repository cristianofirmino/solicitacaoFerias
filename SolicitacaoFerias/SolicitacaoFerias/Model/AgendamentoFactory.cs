using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitacaoFerias.Model
{
    public class AgendamentoFactory
    {

        internal AgendamentoFerias getAgendamento(string abono, string ad13, string prInicio, string prFinal, Integrante integrante, string saldoDiasPA, string titlePeriodo)
        {
            AgendamentoFerias agendamento = new AgendamentoFerias();

            agendamento.IDIntegrante = integrante.IDIntegrante;
            agendamento.Matricula = integrante.Matricula;
            agendamento.NomeIntegrante = integrante.Nome;
            agendamento.Cargo = integrante.Cargo;
            agendamento.LocalizacaoGerenciaSetor = integrante.Gerencia;
            agendamento.UA = integrante.UA;
            agendamento.Lider = integrante.Lider;
            agendamento.PeriodoAquisitivoInicio = DateTime.Parse(integrante.PeriodoAquisitivoInicio).Date;
            agendamento.PeriodoAquisitivoFinal = DateTime.Parse(integrante.PeriodoAquisitivoFim).Date;
            agendamento.AbonoPecuniario = abono;
            agendamento.Adiantamento13Salario = ad13;
            agendamento.DataConsulta = DateTime.Now;
            agendamento.DataAdmissao = DateTime.Parse(integrante.DataAdmissao).Date;
            agendamento.Inicio = DateTime.Parse(prInicio).Date;
            agendamento.SalvarConsulta = true;
            agendamento.periodoGozoFinal = DateTime.Parse(prFinal).Date;
            agendamento.retornoAoTrabalho = DateTime.Parse(new CalendarioQuery().queryReturnDay(DateTime.Parse(prFinal).ToString("u"))).Date;
            agendamento.CTPS = integrante.CTPS;
            agendamento.cpf = integrante.CPF;
            agendamento.SaldoPerAnterior = saldoDiasPA  /*labelSaldoDiasPA.Text*/;
            agendamento.ValidaDiaInicioFerias = true;
            agendamento.ValidaAdiantamento13 = true;
            agendamento.ValidaQtdDiasAntecedencia = true;
            agendamento.Periodo = titlePeriodo;
            agendamento.QuantidadeDias = ((agendamento.periodoGozoFinal - agendamento.Inicio).TotalDays + 1).ToString();

            return agendamento;
        }

    }
}
