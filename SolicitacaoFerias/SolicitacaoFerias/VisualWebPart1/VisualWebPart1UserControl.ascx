<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="SolicitacaoFerias.VisualWebPart1.VisualWebPart1UserControl" %>


<style type="text/css">
    .auto-style2 {
        vertical-align: top;
        }     
   
    .auto-style15 {
        width: 132px;
    }
    .auto-style16 {
        width: 191px;
    }
    .auto-style17 {
        width: 380px;
    }
    .auto-style18 {
        width: 150px;
    }
    .auto-style20 {
        width: 136px;
    }
    .auto-style22 {
        width: 146px;
    }
    .auto-style23 {
        width: 160px;
    }
    .auto-style24 {
        width: 69px;
    }
    
    .auto-style26 {
        vertical-align: top;
        width: 383px;
    }
    .auto-style27 {
        width: 383px;
    }
    
    .auto-style28 {
        vertical-align: top;
        width: 37px;
    }
    .auto-style29 {
        text-align: center;
    }
    
    .auto-style33 {
        width: 40px;
        text-align: left
    }
    
    .auto-style35 {
        width: 40px;
    }
    
    .auto-style38 {
        font-size: small;
    }
    
    .auto-style40 {
        width: 342px;
        text-align: left;
    }
    
    .auto-style41 {
        width: 342px;
        text-align: left;
        height: 23px;
    }
        
</style>

<table style="width: 400px;" runat="server">
    <tr>
        <td class="auto-style15">ID</td>
        <td class="auto-style16">CPF</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style15">
            <asp:TextBox ID="idText" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style16">
            <asp:TextBox ID="cpfText" runat="server" Width="180px"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="buscarBTN" runat="server" Text="Buscar" OnClick="buscarBTN_Click" />
        </td>
    </tr>
</table>
<p>
    &nbsp;</p>
<table style="width: 560px;" runat="server">
    <tr>
        <td class="auto-style17">Nome</td>
        <td>Matrícula</td>
    </tr>
    <tr>
        <td class="auto-style17">
            <asp:TextBox ID="nomeText" runat="server" Enabled="False" Width="98%
                "></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="matriculaText" runat="server" Enabled="False" Width="98%
                "></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style17">Cargo</td>
        <td>Data Admimissão</td>
    </tr>
    <tr>
        <td class="auto-style17">
            <asp:TextBox ID="cargoText" runat="server" Enabled="False" Width="98%"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="dataAdmissaoText" runat="server" Enabled="False" Width="98%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style17">Localização / Gerência / Setor</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style17">
            <asp:TextBox ID="localText" runat="server" Enabled="False" Width="98%"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style17">Encarregado / Líder</td>
        <td>UA</td>
    </tr>
    <tr>
        <td class="auto-style17">
            <asp:TextBox ID="liderText" runat="server" Enabled="False" Width="98%"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="uaText" runat="server" Enabled="False" Width="98%"></asp:TextBox>
        </td>
    </tr>
</table>
<p>
    &nbsp;</p>
<table style="width:auto;" runat="server">
    <tr>
        <td class="auto-style18">Período Aquisitivo</td>
        <td class="auto-style27">
            <asp:TextBox ID="paInicio" runat="server" Enabled="False" Width="134px"></asp:TextBox>
        &nbsp;
            <asp:TextBox ID="paFim" runat="server" Enabled="False" Width="134px"></asp:TextBox>
        </td>
        <td class="auto-style28" rowspan="4">
            &nbsp;</td>
        <td class="auto-style2" rowspan="4">
            <asp:Panel ID="panelInconsistencias" runat="server" BorderColor="#FF3300" BorderWidth="1px" BorderStyle="Solid" Visible="False">
                <div class="auto-style29">
                    <asp:Label ID="labelTitileInconsistencias" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="labelTitlePeriodo" runat="server" style="font-weight: 700"></asp:Label>
                    <br />
                    <br />
                    <table style="width:600px;" runat="server" border="0">
                        <tr>
                            <td style="text-align:left;border-bottom: 1px solid #e6e6e6;" class="auto-style41">
                                <asp:Label ID="labelIncosistencia1" runat="server" Text="Saldo dias Período Aquisitivo anterior:"></asp:Label>
                                <br />
                                <br />
                            </td>
                            <td class="auto-style35" style="border-bottom: 1px solid #e6e6e6;" >
                                <asp:Label ID="labelSaldoDiasPA" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td class="auto-style35"  style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="validaSaldoDias" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;border-bottom: 1px solid #e6e6e6;" class="auto-style40" >
                                <asp:Label ID="labelIncosistencia2" runat="server" Text="Dia de início das férias"></asp:Label>
                                <br />
                                <em><span class="auto-style38">***não pode iniciar às sextas/fim de semana/feriado</span></em></td>
                            <td class="auto-style35"  style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="labelInicioFerias" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td class="auto-style33"  style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="validaInicioFerias" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;border-bottom: 1px solid #e6e6e6;" class="auto-style40">
                                <asp:Label ID="labelIncosistencia3" runat="server" Text="Adiantamento de 50% do 13º salário"></asp:Label>
                                :<br /> <span class="auto-style38"><em>***não pode ser solicitado em Janeiro ou Dezembro</em></span></td>
                            <td class="auto-style35"  style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="labelMesFerias" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td class="auto-style33"  style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="validaMesFerias" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;border-bottom: 1px solid #e6e6e6;" class="auto-style40">
                                <asp:Label ID="labelIncosistencia4" runat="server" Text="Dias de antecedência"></asp:Label>
                                <br />
                                <span class="auto-style38"><em>***deve ser feito com no mínimo 60 dias de antecedência</em></span></td>
                            <td class="auto-style35" style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="labelDiasAntecedencia" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td class="auto-style33" style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="validaDiasAntecedencia" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style40" style="text-align: left; border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="labelIncosistencia5" runat="server" Text="Data de ínicio"></asp:Label>
                                <br />
                                <span class="auto-style38"><em>***não pode inciar antes do período aquisitivo</em></span></td>
                            <td class="auto-style35" style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="labelDataInicio" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td class="auto-style33" style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="validaDataInicio" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style40" style="text-align: left; border-bottom: 1px solid #e6e6e6;">Data mínima para ínicio das férias<br /> <br /></td>
                            <td class="auto-style35" style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="labelPeriodo" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td class="auto-style33" style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="validaPeriodo" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style40" style="text-align: left; border-bottom: 1px solid #e6e6e6;">Data limite para gozo das férias<br /> <span class="auto-style38"><em>***o período de gozo não pode ultrapassar o limite </em></span></td>
                            <td class="auto-style35" style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="labelLimiteGozo" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td class="auto-style33" style="border-bottom: 1px solid #e6e6e6;">
                                <asp:Label ID="validaLimiteGozo" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    &nbsp;</div>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Quantidade Dias</td>
            <td class="auto-style27">
            <asp:Label ID="qtdDias" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Opções de períodos</td>
        <td class="auto-style26" runat="server">
            <asp:RadioButton ID="opCao1" runat="server" GroupName="opcoes" Text="30 dias corridos" Width="380px" OnCheckedChanged="opCao1_CheckedChanged" AutoPostBack="true" Visible="False" />
            <asp:RadioButton ID="opCao9" runat="server" GroupName="opcoes" Text="20 dias corridos" Width="380px" OnCheckedChanged="opCao1_CheckedChanged" AutoPostBack="true" Visible="False" />
            <br />
            <br />
            <asp:RadioButton ID="opCao2" runat="server" GroupName="opcoes" Text="20 dias corridos + 10 abono pecuniário" Width="380px" OnCheckedChanged="opCao1_CheckedChanged" AutoPostBack="true" Visible="False"/>
            <asp:RadioButton ID="opCao3" runat="server" GroupName="opcoes" Text="15 dias corridos + 10 abono pecuniário + 5 dias corridos" Width="380px" OnCheckedChanged="opCao2_CheckedChanged" AutoPostBack="True" Visible="False" />
            <asp:RadioButton ID="opCao20" runat="server" GroupName="opcoes" Text="5 dias corridos + 10 abono pecuniário + 15 dias corridos" Width="380px" OnCheckedChanged="opCao2_CheckedChanged" AutoPostBack="True" Visible="False" />
            <br />
            <br />
            <asp:RadioButton ID="opCao13" runat="server" GroupName="opcoes" Text="25 dias corridos + 5 dias corridos" Width="380px" OnCheckedChanged="opCao2_CheckedChanged" AutoPostBack="true" Visible="False" />
            <asp:RadioButton ID="opCao4" runat="server" GroupName="opcoes" Text="20 dias corridos + 10 dias corridos" Width="380px" AutoPostBack="True" OnCheckedChanged="opCao2_CheckedChanged" Visible="False" />
            <asp:RadioButton ID="opCao5" runat="server" GroupName="opcoes" Text="15 dias corridos + 15 dias corridos" Width="380px" AutoPostBack="True" OnCheckedChanged="opCao2_CheckedChanged" Visible="False" />
            <asp:RadioButton ID="opCao8" runat="server" GroupName="opcoes" Text="15 dias corridos + 5 dias corridos" Width="380px" OnCheckedChanged="opCao2_CheckedChanged" AutoPostBack="true" Visible="False" />
            <asp:RadioButton ID="opCao12" runat="server" GroupName="opcoes" Text="10 dias corridos + 20 dias corridos" Width="380px" OnCheckedChanged="opCao2_CheckedChanged" AutoPostBack="true" Visible="False" />
            <asp:RadioButton ID="opCao14" runat="server" GroupName="opcoes" Text="5 dias corridos + 25 dias corridos" Width="380px" OnCheckedChanged="opCao2_CheckedChanged" AutoPostBack="true" Visible="False" />
            <br />
            <br />
            <asp:RadioButton ID="opCao10" runat="server" GroupName="opcoes" Text="20 dias corridos + 5 dias corridos + 5 dias corridos" Width="380px" OnCheckedChanged="opCao3_CheckedChanged" AutoPostBack="true" Visible="False" />
            <asp:RadioButton ID="opCao7" runat="server" GroupName="opcoes" Text="15 dias corridos + 10 dias corridos + 5 dias corridos" Width="380px" AutoPostBack="True" OnCheckedChanged="opCao3_CheckedChanged" Visible="False" />            
            <asp:RadioButton ID="opCao6" runat="server" GroupName="opcoes" Text="15 dias corridos + 5 dias corridos + 10 dias corridos" Width="380px" AutoPostBack="True" OnCheckedChanged="opCao3_CheckedChanged" Visible="False" />
            <asp:RadioButton ID="opCao17" runat="server" GroupName="opcoes" Text="10 dias corridos + 15 dias corridos + 5 dias corridos" Width="380px" OnCheckedChanged="opCao3_CheckedChanged" AutoPostBack="true" Visible="False" />
            <asp:RadioButton ID="opCao16" runat="server" GroupName="opcoes" Text="10 dias corridos + 5 dias corridos + 15 dias corridos" Width="380px" OnCheckedChanged="opCao3_CheckedChanged" AutoPostBack="true" Visible="False" />
            <asp:RadioButton ID="opCao21" runat="server" GroupName="opcoes" Text="5 dias corridos + 20 dias corridos + 5 dias corridos" Width="380px" OnCheckedChanged="opCao3_CheckedChanged" AutoPostBack="true" Visible="False" />
            <asp:RadioButton ID="opCao19" runat="server" GroupName="opcoes" Text="5 dias corridos + 15 dias corridos + 10 dias corridos" Width="380px" OnCheckedChanged="opCao3_CheckedChanged" AutoPostBack="true" Visible="False" />
            <asp:RadioButton ID="opCao18" runat="server" GroupName="opcoes" Text="5 dias corridos + 10 dias corridos + 15 dias corridos" Width="380px" OnCheckedChanged="opCao3_CheckedChanged" AutoPostBack="true" Visible="False" />
            <asp:RadioButton ID="opCao11" runat="server" GroupName="opcoes" Text="5 dias corridos + 5 dias corridos + 20 dias corridos" Width="380px" OnCheckedChanged="opCao3_CheckedChanged" AutoPostBack="true" Visible="False" />
            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Adiantamento 50% 13º</td>
        <td class="auto-style26" runat="server">
            <asp:RadioButton ID="opCaoDecimo1" runat="server" GroupName="opcoesDecimo" Text="Sim" AutoPostBack="true" OnCheckedChanged="opCaoDecimo1_CheckedChanged" />
            <asp:RadioButton ID="opCaoDecimo2" runat="server" GroupName="opcoesDecimo" Text="Não" AutoPostBack="true" OnCheckedChanged="opCaoDecimo2_CheckedChanged" />
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownListPeriodos" Visible="false" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
</table>
<p>
    &nbsp;</p>
    <table style="width: 1150px;" runat="server">
        <tr>
            <td class="auto-style20">&nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style22">&nbsp;</td>
            <td class="auto-style24">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style20">
                <asp:Label ID="labelPr1" runat="server" Text="Período 1" Visible="false"></asp:Label>
            </td>
            <td class="auto-style23">
                <SharePoint:DateTimeControl ID="prInicio1" runat="server" DateOnly="True" Visible="false" SelectedDate="" />
            </td>
            <td class="auto-style22">
                <asp:TextBox ID="prFim1" runat="server" Enabled="False" Width="134px" Visible="false"></asp:TextBox>
            </td>
            <td class="auto-style24">
                <asp:Button ID="checarBTN1" runat="server" Text="Validar" OnClick="checarBTN1_Click" Visible="False" Enabled="False" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style20">
                <asp:Label ID="labelPr2" runat="server" Text="Período 2" Visible="false"></asp:Label>
            </td>
            <td class="auto-style23">
                <SharePoint:DateTimeControl ID="prInicio2" runat="server" DateOnly="True" Visible="false" SelectedDate=""/>
            </td>
            <td class="auto-style22">
                <asp:TextBox ID="prFim2" runat="server" Enabled="False" Width="134px" Visible="false"></asp:TextBox>
            </td>
            <td class="auto-style24">
                <asp:Button ID="checarBTN2" runat="server" Text="Validar" Visible="False" OnClick="checarBTN2_Click" Enabled="False" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style20">
                <asp:Label ID="labelPr3" runat="server" Text="Período 3" Visible="false"></asp:Label>
            </td>
            <td class="auto-style23">
                <SharePoint:DateTimeControl ID="prInicio3" runat="server" DateOnly="True" Visible="false" SelectedDate=""/>
            </td>
            <td class="auto-style22">
                <asp:TextBox ID="prFim3" runat="server" Enabled="False" Width="134px" Visible="false"></asp:TextBox>
            </td>
            <td class="auto-style24">
                <asp:Button ID="checarBTN3" runat="server" Text="Validar" Visible="False" OnClick="checarBTN3_Click" Enabled="False" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style20">
                &nbsp;</td>
            <td class="auto-style23">
                &nbsp;</td>
            <td class="auto-style22">
                &nbsp;</td>
            <td class="auto-style24">
                <br />
                <asp:Button ID="enviarBTN" runat="server" OnClick="enviarBTN_Click" Text="Enviar" Visible="False" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>





