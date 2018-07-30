using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitacaoFerias
{
    class CalendarioQuery
    {
        SPWeb web = SPContext.Current.Web;        

        public string queryReturnDay(string date)
        {
            SPList Calendario = web.Lists["Calendario"];
            SPQuery query = new SPQuery();
           
            string textQuery =
              "<Where>" +
                  "<And>" +
                     "<Gt>" +
                        "<FieldRef Name='Data' />" +
                        "<Value IncludeTimeValue='FALSE' Type='DateTime'>" + date + "</Value>" +
                     "</Gt>" +
                     "<And>" +
                        "<Neq>" +
                           "<FieldRef Name='DiaDaSemana' />" +
                           "<Value Type='Calculated'>string;#sábado</Value>" +
                        "</Neq>" +
                        "<And>" +
                           "<Neq>" +
                              "<FieldRef Name='DiaDaSemana' />" +
                              "<Value Type='Calculated'>string;#domingo</Value>" +
                           "</Neq>" +
                           "<Neq>" +
                              "<FieldRef Name='Feriado' />" +
                              "<Value Type='Boolean'>1</Value>" +
                           "</Neq>" +
                        "</And>" +
                     "</And>" +
                  "</And>" +
               "</Where>" +
               "<OrderBy><FieldRef Name='ID' Ascending='TRUE'></FieldRef></OrderBy>";

            query.Query = textQuery;
            SPListItemCollection days = Calendario.GetItems(query);
            
            string day = days[0]["Data"].ToString();

            return day;
        }

        public bool holidayAndWeekend(string day)
        {
            SPList Calendario = web.Lists["Calendario"];
            SPQuery query = new SPQuery();

            string textQuery =
              "<Where>" +
                  "<Eq>" +
                      "<FieldRef Name='Data' />" +
                      "<Value IncludeTimeValue='FALSE' Type='DateTime'>" + day + "</Value>" +                   
                  "</Eq>" +
               "</Where>";

            query.Query = textQuery;
            SPListItemCollection days = Calendario.GetItems(query);

            string weekDay = days[0]["DiaDaSemana"].ToString();
            string feriado;
            
            try { feriado = days[0]["Feriado"].ToString(); }
            catch { feriado = "false"; }

            if (weekDay.Contains("sábado") || weekDay.Contains("domingo") || feriado.Contains("True"))
            {
                return true;
            }

            return false;
        }
    }
}
