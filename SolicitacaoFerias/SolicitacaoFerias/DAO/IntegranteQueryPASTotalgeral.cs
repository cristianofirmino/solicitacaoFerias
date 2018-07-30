using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace SolicitacaoFerias
{
    class IntegranteQueryPASTotalgeral
    {
        SPWeb web = SPContext.Current.Web;

        public Integrante queryIntegrante(Integrante integrante)
        {

            SPList PASTotalGeral = web.Lists["PASTotalGeral"];
            SPQuery query = new SPQuery();

            string textQuery =
                "<Where>" +
                 "<And>" +
                   "<Eq><FieldRef Name='IDIntegrante' /> <Value Type='Text'>" + integrante.IDIntegrante + "</Value></Eq>" +
                     "<Or>" +
                       "<Eq><FieldRef Name='StatusPerAqui' /><Value Type='Text'>Aberto</Value></Eq>" +
                       "<Eq><FieldRef Name='StatusPerAqui' /><Value Type='Text'>Em Andamento</Value></Eq>" +
                      "</Or>" +
                  "</And>" +
               "</Where>" +
               "<OrderBy><FieldRef Name='StatusPerAqui' Ascending='TRUE'></FieldRef></OrderBy>";

            query.Query = textQuery;
            SPListItemCollection integrantes = PASTotalGeral.GetItems(query);

            int quantidade = integrantes.Count;


            foreach (SPListItem integ in integrantes)
            {
                if (integ["StatusPerAqui"].Equals("Aberto"))
                {
                    integrante.UA = (string)integ["IDCentroDeCustos"];
                    integrante.Lider = (string)integ["NomeSupervisor"];
                    integrante.PeriodoAquisitivoInicio = DateTime.Parse(integ["DataInicial"].ToString()).ToShortDateString();
                    integrante.PeriodoAquisitivoFim = DateTime.Parse(integ["DtFinal"].ToString()).ToShortDateString();
                    integrante.DiasGozados = (string)integ["DiasGozados"];
                    integrante.DiasAbono = (string)integ["DiasAbono"];

                    return integrante;
                }
                else if (integ["StatusPerAqui"].Equals("Em Andamento"))
                {
                    integrante.UA = (string)integ["IDCentroDeCustos"];
                    integrante.Lider = (string)integ["NomeSupervisor"];
                    integrante.PeriodoAquisitivoInicio = DateTime.Parse(integ["DataInicial"].ToString()).ToShortDateString();
                    integrante.PeriodoAquisitivoFim = DateTime.Parse(integ["DtFinal"].ToString()).ToShortDateString();
                    integrante.DiasGozados = (string)integ["DiasGozados"];
                    integrante.DiasAbono = (string)integ["DiasAbono"];

                    return integrante;
                }

            }

            return integrante;
        }

        public int saldoDias(string idIntegrante, string dataPaInicio)
        {

            SPList PASTotalGeral = web.Lists["PASTotalGeral"];
            SPQuery query = new SPQuery();

            Integrante integrante = new Integrante();
            int anoInicioPaAtual = DateTime.Parse(dataPaInicio).Year;
            int saldoDiasPA = 0;

            string textQuery =
                "<Where>" +
                 "<And>" +
                   "<Eq><FieldRef Name='IDIntegrante' /> <Value Type='Text'>" + idIntegrante + "</Value></Eq>" +
                   "<Eq><FieldRef Name='StatusPerAqui' /><Value Type='Text'>Encerrado</Value></Eq>" +
                   "<Eq><FieldRef Name='AnoFinal' /><Value Type='Text'>" + anoInicioPaAtual + "</Value></Eq>" +
                  "</And>" +
               "</Where>";

            query.Query = textQuery;

            SPListItemCollection integrantes = PASTotalGeral.GetItems(query);

            try
            {
                foreach (SPListItem integ in integrantes)
                {
                    integrante.IDIntegrante = (string)integ["IDIntegrante"];
                    integrante.DiasGozados = (string)integ["DiasGozados"];
                    integrante.DiasAbono = (string)integ["DiasAbono"];
                    integrante.AnoInicio = (string)integ["AnoInicio"];
                    integrante.AnoInicio = (string)integ["AnoFinal"];
                }

                saldoDiasPA = (Int32.Parse(integrante.DiasAbono)) + (Int32.Parse(integrante.DiasGozados));
                return saldoDiasPA;
            }
            catch (Exception)
            {
                return saldoDiasPA;
            }

        }

    }
}
