using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SharePoint.Client;
using System.Security;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;


namespace SolicitacaoFerias
{
    class AgendamentoFeriasListItem
    {
        SPWeb web = SPContext.Current.Web;

        public void createAgendamentoFerias(AgendamentoFerias item)
        {

            web.AllowUnsafeUpdates = true;

            // Fetch the List
            SPList list = web.Lists["Agendamento de Férias"];

            //Add a new item in the List
            SPListItem itemToAdd = list.Items.Add();

            itemToAdd["IDIntegrante"] = item.IDIntegrante;
            itemToAdd["Matricula"] = item.Matricula;
            itemToAdd["NomeIntegrante"] = item.NomeIntegrante;
            itemToAdd["Cargo"] = item.Cargo;
            itemToAdd["Localizacao-Gerencia-Setor"] = item.LocalizacaoGerenciaSetor;
            itemToAdd["UA"] = item.UA;
            itemToAdd["Lider"] = item.Lider;
            itemToAdd["PeriodoAquisitivoInicio"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(item.PeriodoAquisitivoInicio.AddDays(1));
            itemToAdd["PeriodoAquisitivoFinal"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(item.PeriodoAquisitivoFinal.AddDays(1));
            itemToAdd["AbonoPecuniario"] = item.AbonoPecuniario;
            itemToAdd["Adiantamento13Salario"] = item.Adiantamento13Salario;
            itemToAdd["DataConsulta"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(item.DataConsulta);
            itemToAdd["DataAdmissao"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(item.DataAdmissao.AddDays(1));
            itemToAdd["Inicio"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(item.Inicio.AddDays(1));
            itemToAdd["QuantidadeDias"] = item.QuantidadeDias;
            itemToAdd["SaldoPerAnterior"] = item.SaldoPerAnterior;
            itemToAdd["AnoPAInicio"] = item.AnoPAInicio;
            itemToAdd["saldoDias"] = item.saldoDias;
            itemToAdd["AnoInicio"] = item.AnoInicio;
            itemToAdd["periodoGozoFinal"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(item.periodoGozoFinal.AddDays(1));
            itemToAdd["retornoAoTrabalho"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(item.retornoAoTrabalho.AddDays(1));
            itemToAdd["CTPS"] = item.CTPS;
            itemToAdd["cpf"] = item.cpf;
            itemToAdd["SalvarConsulta"] = item.SalvarConsulta;
            itemToAdd["validaDiaInicioFerias"] = item.ValidaDiaInicioFerias;
            itemToAdd["validaAdiantamento13"] = item.ValidaAdiantamento13;
            itemToAdd["validaQtdDiasAntecedencia"] = item.ValidaQtdDiasAntecedencia;
            itemToAdd["periodo"] = item.Periodo;

            itemToAdd.Update();

        }
    }
}







