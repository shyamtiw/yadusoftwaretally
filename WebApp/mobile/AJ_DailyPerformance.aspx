<%@ Page Title="" Language="C#" MasterPageFile="~/ESSP/ESSP.Master" AutoEventWireup="true"
    CodeBehind="AJ_DailyPerformance.aspx.cs" Inherits="IHITS_HRMS_MG.AJ_DailyPerformance" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1.Export, Version=10.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v10.1.Export, Version=10.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraPivotGrid.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function LoadUserGrid() {
            callBackGrid.PerformCallback(2);
        }        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="outerDiv">
        <div class="nameDiv">
            <div class="subDiv">
                Time Utilization</div>
        </div>
        <table border="0" cellspacing="1" cellpadding="1" style="width: 100%; margin-bottom: 5px;">
            <tr>
                <td>
                </td>
                <td align="center" style="width: 120px">
                    <dx:ASPxButton ID="ASPxButton3" TabIndex="0" runat="server" Text="Time Utilization"
                        Width="120px" PostBackUrl="AJ_DailyPerformance.aspx" CausesValidation="False">
                    </dx:ASPxButton>
                </td>
                <td align="center" style="width: 170px">
                    <dx:ASPxButton ID="ASPxButton4" TabIndex="0" runat="server" Text="My Attendance Summary"
                        Width="170px" PostBackUrl="Aj_Attendance_Summary.aspx" CausesValidation="False">
                    </dx:ASPxButton>
                </td>
                <td align="center" style="width: 120px">
                    <dx:ASPxButton ID="ASPxButton1" TabIndex="0" runat="server" Text="Late In Report"
                        Width="120px" PostBackUrl="Aj_Late_In_Report.aspx" CausesValidation="False">
                    </dx:ASPxButton>
                </td>
                <td align="center" style="width: 2px">
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td align="right" style="width: 50px;">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="From">
                    </dx:ASPxLabel>
                </td>
                <td align="left" style="width: 100px;">
                    <dx:ASPxDateEdit ID="mskFrom" runat="server" EditFormatString="dd/MMM/yyyy" Width="100">
                        <ClientSideEvents DateChanged="LoadUserGrid" />
                    </dx:ASPxDateEdit>
                </td>
                <td align="right" style="width: 50px;">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="To">
                    </dx:ASPxLabel>
                </td>
                <td align="left" style="width: 100px;">
                    <dx:ASPxDateEdit ID="mskTo" runat="server" EditFormat="Custom" EditFormatString="dd/MMM/yyyy"
                        AutoPostBack="false" Width="100">
                        <ClientSideEvents DateChanged="LoadUserGrid" />
                    </dx:ASPxDateEdit>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="5" align="center" valign="top">
                    <dx:ASPxCallbackPanel ID="callBackGrid" runat="server" ClientInstanceName="callBackGrid"
                        CssFilePath="~/App_Themes/SoftOrange/{0}/styles.css" CssPostfix="SoftOrange"
                        LoadingPanelImagePosition="Top" OnCallback="callBackGrid_Callback" Width="100%">
                        <LoadingPanelImage Url="~/App_Themes/SoftOrange/Web/Loading.gif">
                        </LoadingPanelImage>
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                                <table width="100%" cellpadding="2" cellspacing="0" border="0">
                                    <tr>
                                        <td align="left">
                                            <dx:ASPxLabel ID="lblMessage" runat="server" ForeColor="#FF3300">
                                            </dx:ASPxLabel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <div class="roundtable" style="width: 99%">
                                                <dx:ASPxGridView ID="grdView" runat="server" OnCustomButtonCallback="grdView_CustomButtonCallback"
                                                    OnCustomSummaryCalculate="grdView_CustomSummaryCalculate" OnDataBound="grdView_DataBound"
                                                    OnHtmlDataCellPrepared="grdView_HtmlDataCellPrepared" OnHtmlRowCreated="grdView_HtmlRowCreated"
                                                    Width="100%">
                                                    <SettingsBehavior AllowGroup="False" AllowSort="False" ColumnResizeMode="Control" />
                                                    <SettingsPager Mode="ShowAllRecords">
                                                    </SettingsPager>
                                                    <Settings ShowFooter="True" ShowHorizontalScrollBar="True" ShowVerticalScrollBar="True"
                                                        VerticalScrollableHeight="350" />
                                                    <SettingsLoadingPanel ImagePosition="Top" />
                                                    <Paddings Padding="1px" />
                                                </dx:ASPxGridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="grdView"
                                                Landscape="True">
                                                <Styles>
                                                    <Header Font-Bold="True">
                                                    </Header>
                                                </Styles>
                                            </dx:ASPxGridViewExporter>
                                        </td>
                                    </tr>
                                </table>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
