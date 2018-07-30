using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitacaoFerias.DAO
{
    class AgendamentoQuery
    {
        SPWeb web = SPContext.Current.Web;

        public bool exist(string date, string id)
        {
            SPList Calendario = web.Lists["Agendamento de Férias"];
            SPQuery query = new SPQuery();

            string textQuery =
               "<Where>" +
                  "<And>" +
                     "<Eq>" +
                        "<FieldRef Name='Title' />" +
                        "<Value Type='Text'>" + id + "</Value>" +
                     "</Eq>" +
                     "<And>" +
                        "<Eq>" +
                           "<FieldRef Name='PeriodoAquisitivoInicio' />" +
                           "<Value IncludeTimeValue='FALSE' Type='DateTime'>" + date + "</Value>" +
                        "</Eq>" +
                        "<Eq>" +
                           "<FieldRef Name='SalvarConsulta' />" +
                           "<Value Type='Boolean'>1</Value>" +
                        "</Eq>" +
                     "</And>" +
                  "</And>" +
               "</Where>";

            query.Query = textQuery;
            SPListItemCollection agendamentos = Calendario.GetItems(query);

            try
            {
                string agendamentoData = DateTime.Parse(agendamentos[0]["PeriodoAquisitivoInicio"].ToString()).ToShortDateString();
                string idIntegrante = agendamentos[0]["Title"].ToString();

                if (agendamentoData.Equals(DateTime.Parse(date).ToShortDateString()) && idIntegrante.Equals(id))
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

            return false;
        }
    }
}
