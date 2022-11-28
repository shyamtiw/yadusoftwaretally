<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="OutstandingRemark.aspx.cs" Inherits="WebApp.admin.Reports.OutstandingRemark" %>


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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
   Sales  Outstanding Remarks
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
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="table-responsive">
                                <asp:GridView ID="gvlocation"  Style='width: 100%' CssClass='t02 t01 GVData' HeaderStyle-BackColor="LightBlue" runat="server" AutoGenerateColumns="false" Width="98%" align="center">
                                    <Columns>
                                      
                                        <asp:TemplateField HeaderText="SR.NO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <a onclick="<%# string.Concat("showLeter('salesoutstadingupdateRemark.aspx?ledg_Ac=",Eval("ledg_Ac").ToString(),"&&PendingAmt=",Eval("Pending_amt").ToString(),"')") %>" class="label label-sm label-info">Update Remark</a>                          
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice Location">
                                            <ItemTemplate><%# Eval("Invoice_Location")%> </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                        <asp:TemplateField HeaderText="ledg_Ac">
                                            <ItemTemplate><%# Eval("ledg_Ac")%> </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                   
                                      
                                        <asp:TemplateField HeaderText="Ledg_Name">
                                            <ItemTemplate><%# Eval("Ledg_Name")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pending_amt">
                                            <ItemTemplate><%# WebApp.LIBS.Common.ConvertDecimal( Eval("Pending_amt")).ToString("0.00")%> </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="Dms_Inv">
                                            <ItemTemplate><%# Eval("Dms_Inv")%> </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Inv_Date">
                                            <ItemTemplate><%# Eval("Inv_Date") %> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delv_Date">
                                            <ItemTemplate><%# Eval("Delv_Date")%> </ItemTemplate>
                                            
                                        </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="Cust_id">
                                            <ItemTemplate><%# Eval("Cust_id")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Del_CustId">
                                            <ItemTemplate><%# Eval("Del_CustId")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Chas_no">
                                            <ItemTemplate><%# Eval("Chas_no")%> </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="ERP_DSE">
                                            <ItemTemplate><%# Eval("ERP_DSE")%> </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ERP_TL">
                                            <ItemTemplate><%# Eval("ERP_TL")%> </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                          <asp:TemplateField HeaderText="Cust_Type">
                                            <ItemTemplate><%# Eval("Cust_Type")%> </ItemTemplate>
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Financer_Name">
                                            <ItemTemplate><%# Eval("Financer_Name")%> </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Invoice_Ageing">
                                            <ItemTemplate><%# Eval("Invoice_Ageing")%> </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Delivery_Location">
                                            <ItemTemplate><%# Eval("Delivery_Location")%> </ItemTemplate>
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
            var wird= parseInt(((screen.width*50)/100.00).toFixed(0));
            var left = (screen.width - wird) / 2; var top = (screen.height - 500) / 4;

            var popup = window.open(str, "Responce", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + wird + ', height=' + 500 + ', top=' + top + ', left=' + left);
            popup.focus();
        }

     


    </script>
</asp:Content>
