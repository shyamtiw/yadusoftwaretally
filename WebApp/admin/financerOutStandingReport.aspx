<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="financerOutStandingReport.aspx.cs" Inherits="WebApp.admin.financerOutStandingReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .t02 th {
            background-color: navy;
            color: white;
        }

        .disn {
            display: none;
        }

        .disy {
            display: block;
        }


        tbody td {
            padding: 0px 0px !important;
        }

        tbody th {
            padding: 0px 0px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
    <asp:Literal runat="server" ID="ReportName"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">


    <div class="row">
        <SG:Message runat="server" ID="MessageBox" />


        <div class="col-md-12">

            <!-- general form elements disabled -->
            <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                    <h3 class="box-title">Data</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">




                    <div class="row">

                         <div class="col-md-3">
                            <div class="form-group">
                                <label>GroupName </label>
                                <asp:DropDownList runat="server" ID="GroupName" CssClass="form-control"></asp:DropDownList>

                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Bank_Ledg_Name </label>
                                <asp:DropDownList runat="server" ID="Bank_Ledg_Name" CssClass="form-control"></asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Branch Name</label>
                                <asp:DropDownList runat="server" ID="Branch_Name" CssClass="form-control"></asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Age_Bucket</label>
                                <table>
                                   <tr>
                                       <td style="width:95%">
                                           <asp:DropDownList runat="server" ID="Age_Bucket" CssClass="form-control"></asp:DropDownList>
                                       </td>
                                       <td style="width:5%"> <asp:Button runat="server" ID="GetData" Text="GO!" CssClass="btn btn-info btn-flat"  OnClick="GetData_Click"/>

                                       </td>
                                   </tr>
                                </table>
                                
                               
                                
                            </div>
                        </div>
                    </div>



                </div>




                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="table-responsive">
                                <asp:GridView ID="gvlocation" Style='width: 100%' CssClass='t02 t01 GVData' HeaderStyle-BackColor="LightBlue" runat="server" AutoGenerateColumns="false" Width="98%" align="center">
                                    <Columns>

                                        <asp:TemplateField HeaderText="SR.NO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--    <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <a onclick="<%# string.Concat("showLeter('salesoutstadingupdateRemark.aspx?ledg_Ac=",Eval("ledg_Ac").ToString(),"&&PendingAmt=",Eval("Pending_amt").ToString(),"')") %>" class="label label-sm label-info">Update Remark</a>                          
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>


                                          <asp:TemplateField HeaderText="Group Name">
                                            <ItemTemplate><%# Eval("GroupName")%> </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Bank_Ledg_Name">
                                            <ItemTemplate><%# Eval("Bank_Ledg_Name")%> </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--  
                                        <asp:TemplateField HeaderText="Dms_Inv">
                                            <ItemTemplate><%# Eval("Dms_Inv")%> </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Inv_Date">
                                            <ItemTemplate><%# Eval("Inv_Date") %> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delv_Date">
                                            <ItemTemplate><%# Eval("Delv_Date")%> </ItemTemplate>
                                            
                                        </asp:TemplateField>--%>


                                        <asp:TemplateField HeaderText="Cust_Ledg_Name">
                                            <ItemTemplate><%# Eval("Cust_Ledg_Name")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cust_Id">
                                            <ItemTemplate><%# Eval("Cust_Id")%> </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Branch_Name">
                                            <ItemTemplate><%# Eval("Branch_Name")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Ref_no">
                                            <ItemTemplate><%# Eval("Ref_no")%> </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="Do_Date">
                                            <ItemTemplate><%# Convert.ToDateTime( Eval("Do_Date")).ToString("dd/MM/yyyy")%> </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Age">
                                            <ItemTemplate><%# Eval("Age")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Age_Bucket">
                                            <ItemTemplate><%# Eval("Age_Bucket")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DO_Amount">
                                            <ItemTemplate>
                                                <%# 
     WebApp.LIBS.Common.ConvertDecimal( Eval("DO_Amount")).ToString("0.00")
                                                %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Recd_Amt">
                                            <ItemTemplate><%# WebApp.LIBS.Common.ConvertDecimal( Eval("Recd_Amt")).ToString("0.00")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Os_Amt">
                                            <ItemTemplate><%# WebApp.LIBS.Common.ConvertDecimal( Eval("Os_Amt")).ToString("0.00")%> </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Bank_ledg_Ac">
                                            <ItemTemplate><%# Eval("Bank_ledg_Ac")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cust Ledg Ac">
                                            <ItemTemplate><%# Eval("Cust_Ledg_Ac")%> </ItemTemplate>
                                        </asp:TemplateField>






                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Exists
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </div>

    </div>
    <asp:Literal runat="server" ID="UpdatePanels"></asp:Literal>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
    <script>
        function showLeter(str) {
            var popup;
            debugger;
            var wird = parseInt(((screen.width * 50) / 100.00).toFixed(0));
            var left = (screen.width - wird) / 2; var top = (screen.height - 500) / 4;

            var popup = window.open(str, "Responce", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + wird + ', height=' + 500 + ', top=' + top + ', left=' + left);
            popup.focus();
        }




    </script>
</asp:Content>
