using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.Management;
using System.Management.Instrumentation;
using Microsoft.SharePoint.WebControls;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using SolicitacaoFerias.DAO;
using SolicitacaoFerias.Model;
using System.Web;

namespace SolicitacaoFerias.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        //private static Integrante integrante;
        private string username = "";
                
        HttpContext current = new HttpContext(HttpContext.Current.Request, HttpContext.Current.Response);
        
        protected void Page_Load(object sender, EventArgs e)
        {                      
            username = this.Context.User.Identity.Name.Substring(14);            
        }

        protected void buscarBTN_Click(object sender, EventArgs e)
        {
            //HttpContext.Current.Session["Agendamentos"] = new List<AgendamentoFerias>();
            HttpContext.Current.Session["Integrante"] = new IntegranteDAO().getIntegrante(idText.Text, cpfText.Text);

            try
            {                
                HttpContext.Current.Session["Integrante"] = new IntegranteQueryPASTotalgeral().queryIntegrante(((Integrante)HttpContext.Current.Session["Integrante"]));
                nomeText.Text = ((Integrante)HttpContext.Current.Session["Integrante"]).Nome;
                matriculaText.Text = ((Integrante)HttpContext.Current.Session["Integrante"]).Matricula;
                cargoText.Text = ((Integrante)HttpContext.Current.Session["Integrante"]).Cargo;
                dataAdmissaoText.Text = DateTime.Parse(((Integrante)HttpContext.Current.Session["Integrante"]).DataAdmissao).ToShortDateString();
                localText.Text = ((Integrante)HttpContext.Current.Session["Integrante"]).Gerencia;
                uaText.Text = ((Integrante)HttpContext.Current.Session["Integrante"]).UA;
                liderText.Text = ((Integrante)HttpContext.Current.Session["Integrante"]).Lider;
                paInicio.Text = ((Integrante)HttpContext.Current.Session["Integrante"]).PeriodoAquisitivoInicio;
                paFim.Text = ((Integrante)HttpContext.Current.Session["Integrante"]).PeriodoAquisitivoFim;
                qtdDias.Text = (30 - (Int32.Parse(((Integrante)HttpContext.Current.Session["Integrante"]).DiasGozados))).ToString();

                
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Integrante não encontrado, verifique o ID e CPF digitados.');", true);
                return;
            }

            bool existPa = new AgendamentoQuery().exist(DateTime.Parse(paInicio.Text).AddHours(22).ToString("s"), ((Integrante)HttpContext.Current.Session["Integrante"]).IDIntegrante);
            

            if (existPa)
            {
                Response.Write("<script language='javascript'>window.alert('Já existe programação de férias desse Período Aquisitivo para o Integrante informado! Para cancelamento ou alterações entre em contato com P&O.');window.location='http://sistemas.icnavais.net/po/controleferias/';</script>");
            }
            else
            {

                if (qtdDias.Text.Equals("30"))
                {
                    opCao1.Visible = true;
                    opCao2.Visible = true;
                    opCao3.Visible = true;
                    opCao4.Visible = true;
                    opCao5.Visible = true;
                    opCao6.Visible = true;
                    opCao7.Visible = true;
                    
                    opCao10.Visible = true;
                    opCao11.Visible = true;
                    opCao12.Visible = true;
                    opCao13.Visible = true;
                    opCao14.Visible = true;
                    
                    opCao16.Visible = true;
                    opCao17.Visible = true;
                    opCao18.Visible = true;
                    opCao19.Visible = true;
                    opCao20.Visible = true;
                    opCao21.Visible = true;


                    opCao8.Visible = false;
                    opCao9.Visible = false;                    

                }
                else if (qtdDias.Text.Equals("20"))
                {
                    opCao8.Visible = true;
                    opCao9.Visible = true;
                    opCao1.Visible = false;
                    opCao2.Visible = false;
                    opCao3.Visible = false;
                    opCao4.Visible = false;
                    opCao5.Visible = false;
                    opCao6.Visible = false;
                    opCao7.Visible = false;
                }
            }

        }

        protected void checarBTN1_Click(object sender, EventArgs e)
        {
            

            try
            {               

                if (!prInicio1.SelectedDate.ToShortDateString().Equals(DateTime.Today.ToShortDateString()))
                {
                    validateDateLine1(prInicio1, prFim1);
                    setPanelInconsistencies(((Integrante)HttpContext.Current.Session["Integrante"]).IDIntegrante, prInicio1, ((Integrante)HttpContext.Current.Session["Integrante"]).PeriodoAquisitivoInicio, prFim1.Text, (Button)sender);
                    validateInconsistencies((Button)sender, 1, prInicio1, DateTime.Parse(prFim1.Text).Date);
                }
            }
            catch (Exception)
            {
                
               Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Selecione uma data válida!');", true);
            }

        }

        protected void checarBTN2_Click(object sender, EventArgs e)
        {            

            try
            {                

                if (!(prInicio2.SelectedDate.ToShortDateString().Equals(DateTime.Today.ToShortDateString())))
                {
                    validateDateLine2(prInicio2, prFim2);
                    setPanelInconsistencies(((Integrante)HttpContext.Current.Session["Integrante"]).IDIntegrante, prInicio2, ((Integrante)HttpContext.Current.Session["Integrante"]).PeriodoAquisitivoInicio, prFim1.Text, (Button)sender);
                    validateInconsistencies((Button)sender, 2, prInicio2, DateTime.Parse(prFim2.Text).Date);
                }
            }
            catch (Exception)
            {
                
               Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Selecione uma data válida!');", true);
            }

        }

        protected void checarBTN3_Click(object sender, EventArgs e)
        {
           
            try
            {               

                if (!(prInicio3.SelectedDate.ToShortDateString().Equals(DateTime.Today.ToShortDateString())))
                {
                    validateDateLine3(prInicio3, prFim3);
                    setPanelInconsistencies(((Integrante)HttpContext.Current.Session["Integrante"]).IDIntegrante, prInicio3, ((Integrante)HttpContext.Current.Session["Integrante"]).PeriodoAquisitivoInicio, prFim2.Text, (Button)sender);
                    validateInconsistencies((Button)sender, 3, prInicio3, DateTime.Parse(prFim3.Text).Date);
                }
            }
            catch (Exception)
            {
                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Selecione uma data válida!');", true);
            }

        }

        protected void opCao1_CheckedChanged(object sender, EventArgs e)
        {

            HttpContext.Current.Session["Agendamentos"] = new List<AgendamentoFerias>();

            clearAndDisableLineForm(prFim1, labelPr1, prInicio1, checarBTN1);
            clearAndDisableLineForm(prFim2, labelPr2, prInicio2, checarBTN2);
            clearAndDisableLineForm(prFim3, labelPr3, prInicio3, checarBTN3);

            DropDownListPeriodos.Items.Clear();
            DropDownListPeriodos.Visible = false;
            opCaoDecimo1.Checked = false;
            opCaoDecimo2.Checked = false;
            enableLineForm(prFim1, labelPr1, prInicio1, checarBTN1);
        }

        protected void opCao2_CheckedChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Session["Agendamentos"] = new List<AgendamentoFerias>();

            clearAndDisableLineForm(prFim1, labelPr1, prInicio1, checarBTN1);
            clearAndDisableLineForm(prFim2, labelPr2, prInicio2, checarBTN2);
            clearAndDisableLineForm(prFim3, labelPr3, prInicio3, checarBTN3);

            DropDownListPeriodos.Items.Clear();
            DropDownListPeriodos.Visible = false;
            opCaoDecimo1.Checked = false;
            opCaoDecimo2.Checked = false;
            enableLineForm(prFim1, labelPr1, prInicio1, checarBTN1);
            enableLineForm(prFim2, labelPr2, prInicio2, checarBTN2);

        }

        protected void opCao3_CheckedChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Session["Agendamentos"] = new List<AgendamentoFerias>();

            clearAndDisableLineForm(prFim1, labelPr1, prInicio1, checarBTN1);
            clearAndDisableLineForm(prFim2, labelPr2, prInicio2, checarBTN2);
            clearAndDisableLineForm(prFim3, labelPr3, prInicio3, checarBTN3);

            DropDownListPeriodos.Items.Clear();
            DropDownListPeriodos.Visible = false;
            opCaoDecimo1.Checked = false;
            opCaoDecimo2.Checked = false;
            enableLineForm(prFim1, labelPr1, prInicio1, checarBTN1);
            enableLineForm(prFim2, labelPr2, prInicio2, checarBTN2);
            enableLineForm(prFim3, labelPr3, prInicio3, checarBTN3);
        }

        protected void opCaoDecimo1_CheckedChanged(object sender, EventArgs e)
        {
            if (opCao1.Checked || opCao2.Checked || opCao9.Checked)
            {
                DropDownListPeriodos.Items.Clear();
                DropDownListPeriodos.Visible = true;
                DropDownListPeriodos.Items.Insert(0, "Período 1");
                DropDownListPeriodos.SelectedIndex = 0;
            }

            if (opCao3.Checked || opCao4.Checked || opCao5.Checked || opCao8.Checked || opCao12.Checked || opCao13.Checked || opCao20.Checked || opCao14.Checked)
            {
                DropDownListPeriodos.Items.Clear();
                DropDownListPeriodos.Visible = true;
                DropDownListPeriodos.Items.Insert(0, "");
                DropDownListPeriodos.Items.Insert(1, "Período 1");
                DropDownListPeriodos.Items.Insert(2, "Período 2");
                DropDownListPeriodos.SelectedIndex = 0;
            }

            if (opCao6.Checked || opCao7.Checked || opCao10.Checked || opCao11.Checked || opCao16.Checked || opCao17.Checked || opCao18.Checked || opCao19.Checked || opCao21.Checked)
            {
                DropDownListPeriodos.Items.Clear();
                DropDownListPeriodos.Visible = true;
                DropDownListPeriodos.Items.Insert(0, "");
                DropDownListPeriodos.Items.Insert(1, "Período 1");
                DropDownListPeriodos.Items.Insert(2, "Período 2");
                DropDownListPeriodos.Items.Insert(3, "Período 3");
                DropDownListPeriodos.SelectedIndex = 0;
            }

        }

        protected void opCaoDecimo2_CheckedChanged(object sender, EventArgs e)
        {
            DropDownListPeriodos.Visible = false;
            DropDownListPeriodos.Items.Clear();
        }

        public void enableLineForm(TextBox txtBox, Label label, Microsoft.SharePoint.WebControls.DateTimeControl date, Button btnCheck)
        {
            label.Visible = true;
            date.Visible = true;
            date.ClearSelection();
            txtBox.Visible = true;
            btnCheck.Visible = true;
            btnCheck.Enabled = true;
            disableIDandCPF();
        }

        public void clearAndDisableLineForm(TextBox txtBox, Label label, DateTimeControl date, Button btn)
        {
            label.Visible = false;
            date.Visible = false;
            date.ClearSelection();
            txtBox.Visible = false;
            txtBox.Text = "";
            btn.Visible = false;
            enviarBTN.Visible = true;

        }

        public void validateDateLine1(DateTimeControl date, TextBox text)
        {

            if (opCao1.Checked)
            {
                text.Text = date.SelectedDate.AddDays(29).ToShortDateString();
            }

            if (opCao13.Checked)
            {
                text.Text = date.SelectedDate.AddDays(24).ToShortDateString();
            }

            if (opCao2.Checked || opCao4.Checked || opCao9.Checked || opCao10.Checked)
            {
                text.Text = date.SelectedDate.AddDays(19).ToShortDateString();
            }

            if (opCao3.Checked || opCao5.Checked || opCao6.Checked || opCao7.Checked || opCao8.Checked)
            {
                text.Text = date.SelectedDate.AddDays(14).ToShortDateString();
            }

            if (opCao12.Checked || opCao16.Checked || opCao17.Checked)
            {
                text.Text = date.SelectedDate.AddDays(9).ToShortDateString();
            }

            if (opCao11.Checked || opCao14.Checked || opCao18.Checked || opCao19.Checked || opCao20.Checked || opCao21.Checked)
            {
                text.Text = date.SelectedDate.AddDays(4).ToShortDateString();
            }
        }


        public void validateDateLine2(DateTimeControl date, TextBox text)
        {
            
            if (opCao14.Checked)
            {
                text.Text = date.SelectedDate.AddDays(24).ToShortDateString();
            }

            if (opCao12.Checked || opCao21.Checked)
            {
                text.Text = date.SelectedDate.AddDays(19).ToShortDateString();
            }

            if (opCao5.Checked || opCao17.Checked || opCao19.Checked || opCao20.Checked)
            {
                text.Text = date.SelectedDate.AddDays(14).ToShortDateString();
            }

            if (opCao4.Checked || opCao7.Checked || opCao18.Checked)
            {
                text.Text = date.SelectedDate.AddDays(9).ToShortDateString();
            }

            if (opCao3.Checked || opCao6.Checked || opCao8.Checked || opCao10.Checked || opCao11.Checked || opCao13.Checked || opCao16.Checked)
            {
                text.Text = date.SelectedDate.AddDays(4).ToShortDateString();
            }
        }

        public void validateDateLine3(DateTimeControl date, TextBox text)
        {

            if (opCao11.Checked)
            {
                text.Text = date.SelectedDate.AddDays(19).ToShortDateString();
            }

            if (opCao16.Checked || opCao18.Checked)
            {
                text.Text = date.SelectedDate.AddDays(14).ToShortDateString();
            }

            if (opCao6.Checked || opCao19.Checked)
            {
                text.Text = date.SelectedDate.AddDays(9).ToShortDateString();
            }

            if (opCao7.Checked || opCao10.Checked || opCao17.Checked || opCao21.Checked)
            {
                text.Text = date.SelectedDate.AddDays(4).ToShortDateString();
            }
        }

        public void disableIDandCPF()
        {
            idText.Enabled = false;
            cpfText.Enabled = false;
            buscarBTN.Enabled = false;
        }

        protected void setPanelInconsistencies(string id, DateTimeControl periodoInicio, string paInicio, string periodoFim, Button btnCheck)
        {
            int saldoDiasPA = new IntegranteQueryPASTotalgeral().saldoDias(id, paInicio);
            labelSaldoDiasPA.Text = saldoDiasPA.ToString();
            var culture = new System.Globalization.CultureInfo("pt-BR");
            labelInicioFerias.Text = culture.DateTimeFormat.GetDayName(periodoInicio.SelectedDate.DayOfWeek);
            labelMesFerias.Text = culture.DateTimeFormat.GetMonthName(periodoInicio.SelectedDate.Month);
            labelDiasAntecedencia.Text = (periodoInicio.SelectedDate - DateTime.Now).Days.ToString();
            labelDataInicio.Text = periodoInicio.SelectedDate.ToShortDateString();
            labelLimiteGozo.Text = DateTime.Parse(paInicio).AddYears(2).ToShortDateString();
            
            if(btnCheck.ID.Equals("checarBTN1"))
            {
               labelPeriodo.Text = DateTime.Parse(paFim.Text).AddDays(1).ToShortDateString();
            }
            else
            {
              labelPeriodo.Text = DateTime.Parse(periodoFim).AddDays(1).ToShortDateString();
            }

            if (btnCheck.ID.Equals("checarBTN1")) labelTitlePeriodo.Text = "PERÍODO 1";
            if (btnCheck.ID.Equals("checarBTN2")) labelTitlePeriodo.Text = "PERÍODO 2";
            if (btnCheck.ID.Equals("checarBTN3")) labelTitlePeriodo.Text = "PERÍODO 3";

        }

        protected void validateInconsistencies(Button btnCheck, int line, DateTimeControl periodoInicio, DateTime periodoFinal)
        {
            
            string periodoOption = "NÃO";
            string abonoOption = "NÃO";

            panelInconsistencias.Visible = true;
            bool holidayAndWeekend = new CalendarioQuery().holidayAndWeekend(periodoInicio.SelectedDate.ToString("u"));
            bool validation1 = labelInicioFerias.Text.Equals("sexta-feira") || labelInicioFerias.Text.Equals("sábado") || labelInicioFerias.Text.Equals("domingo") || holidayAndWeekend;
            bool validation2 = cargoText.Text.Contains("VIGILANTE") || cargoText.Text.Contains("BOMBEIRO CIVIL") || cargoText.Text.Contains("OPERADOR DE UTILIDADES") || cargoText.Text.Contains("ELETRICISTA FORCA E CONTROLE");
            bool validation3 = !(labelMesFerias.Text.Equals("janeiro") || labelMesFerias.Text.Equals("dezembro") && opCaoDecimo1.Checked);
            bool validation4 = !(Int32.Parse(labelDiasAntecedencia.Text) < 60);
            bool validation5 = (DateTime.Compare(DateTime.Parse(paFim.Text), prInicio1.SelectedDate)) < 0;
            bool validation6 = (DropDownListPeriodos.SelectedValue.ToString().Equals("Período " + line)) && (btnCheck.ID.ToString().Equals("checarBTN" + line));
            bool validation7 = (DateTime.Compare(DateTime.Parse(paInicio.Text).AddYears(2), periodoFinal)) >= 0;

            if (!validation1) { validaInicioFerias.Text = "OK"; }
            else if (validation2 /*&& labelInicioFerias.Text.Equals("sexta-feira")*/) { validaInicioFerias.Text = "OK"; }
            else { validaInicioFerias.Text = "Inválido";}

            if (!validation6 && !DropDownListPeriodos.SelectedValue.Equals("") || opCaoDecimo2.Checked) { validaMesFerias.Text = "OK"; }
            else if (validation3 && !DropDownListPeriodos.SelectedValue.Equals("")) { validaMesFerias.Text = "OK"; }
            else { validaMesFerias.Text = "Inválido"; }

            if (validation4) { validaDiasAntecedencia.Text = "OK"; } else { validaDiasAntecedencia.Text = "Inválido";}

            if (validation5) { validaDataInicio.Text = "OK"; } else { validaDataInicio.Text = "Inválido";}

            if (validation7) { validaLimiteGozo.Text = "OK"; } else { validaLimiteGozo.Text = "Inválido"; }
            
            if (!(btnCheck.ID.Equals("checarBTN1")))
            {
                if (!(prFim1.Text.Equals("")) && btnCheck.ID.Equals("checarBTN2"))
                {
                    if ((DateTime.Compare(periodoInicio.SelectedDate, DateTime.Parse(prFim1.Text))) > 0) { validaPeriodo.Text = "OK"; } else { validaPeriodo.Text = "Inválido"; }
                }

                if (!(prFim2.Text.Equals("")) && btnCheck.ID.Equals("checarBTN3"))
                {
                    if ((DateTime.Compare(periodoInicio.SelectedDate, DateTime.Parse(prFim2.Text))) > 0) { validaPeriodo.Text = "OK"; } else { validaPeriodo.Text = "Inválido"; }
                }                
            }
            else if ((DateTime.Compare(periodoInicio.SelectedDate, DateTime.Parse(paFim.Text))) > 0) { validaPeriodo.Text = "OK"; } else { validaPeriodo.Text = "Inválido"; }       


            if (validaInicioFerias.Text.Equals("OK") && 
                validaMesFerias.Text.Equals("OK") && 
                validaDiasAntecedencia.Text.Equals("OK") && 
                validaDataInicio.Text.Equals("OK") && 
                validaPeriodo.Text.Equals("OK") 
                && validaLimiteGozo.Text.Equals("OK"))
            {
                labelTitileInconsistencias.Text = "Validação completa";
                labelTitileInconsistencias.Font.Bold = true;

                if (opCao2.Checked && btnCheck.ID.Equals("checarBTN1") || opCao3.Checked && btnCheck.ID.Equals("checarBTN1") || opCao20.Checked && btnCheck.ID.Equals("checarBTN1"))
                {
                    abonoOption = "SIM";
                }

                if (opCaoDecimo1.Checked && DropDownListPeriodos.SelectedValue.Equals("Período " + line))
                {
                    periodoOption = "SIM";
                }

                btnCheck.Enabled = false;
                btnCheck.Visible = false;

                AgendamentoFerias agendamento = new AgendamentoFactory().getAgendamento(abonoOption, periodoOption, periodoInicio.SelectedDate.ToShortDateString(), periodoFinal.ToShortDateString(), ((Integrante)HttpContext.Current.Session["Integrante"]), labelSaldoDiasPA.Text, labelTitlePeriodo.Text);
                                
                ((List<AgendamentoFerias>)HttpContext.Current.Session["Agendamentos"]).Add(agendamento);

            }
            else
            {
                labelTitileInconsistencias.Text = "CORRIJA AS INCONSISTÊNCIAS";
            }

        }               

        protected void enviarBTN_Click(object sender, EventArgs e)
        {
            if (checarBTN1.Enabled || checarBTN2.Enabled || checarBTN3.Enabled || string.IsNullOrEmpty(idText.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Há validações pendentes!');", true);
            }
            else
            {
                List<AgendamentoFerias> agendamentosSession = (List<AgendamentoFerias>)HttpContext.Current.Session["Agendamentos"];

                foreach (AgendamentoFerias item in agendamentosSession)
                {
                    new AgendamentoFeriasListItem().createAgendamentoFerias(item);                    
                }

                Response.Write("<script language='javascript'>window.alert('Férias programadas com sucesso!');window.location='http://sistemas.icnavais.net/po/controleferias/Lists/ConsultaPedidoDeFerias/';</script>");              
            }
        }
    }
}
