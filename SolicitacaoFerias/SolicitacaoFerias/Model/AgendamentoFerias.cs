using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolicitacaoFerias
{
    class AgendamentoFerias
    {
        public string IDIntegrante { get; set; }
        public string Matricula { get; set; }
        public string NomeIntegrante { get; set; }
        public string Cargo { get; set; }
        public string LocalizacaoGerenciaSetor { get; set; }
        public string UA { get; set; }
        public string Lider { get; set; }
        public DateTime PeriodoAquisitivoInicio { get; set; } 
        public DateTime PeriodoAquisitivoFinal { get; set; }
        public string AbonoPecuniario { get; set; }
        public string Adiantamento13Salario { get; set; }
        public DateTime DataConsulta { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime Inicio { get; set; }
        public string QuantidadeDias { get; set; }
        public string SaldoPerAnterior { get; set; }
        public string AnoPAInicio { get; set; }
        public string saldoDias { get; set; }
        public string AnoInicio { get; set; }
        public bool SalvarConsulta { get; set; }
        public DateTime periodoGozoFinal { get; set; }
        public DateTime retornoAoTrabalho { get; set; }
        public string CTPS { get; set; }
        public string cpf { get; set; }
        public bool ValidaDiaInicioFerias { get; set; }
        public bool ValidaAdiantamento13 { get; set; }
        public bool ValidaQtdDiasAntecedencia { get; set; }
        public string Periodo { get; set; }

    }
}
