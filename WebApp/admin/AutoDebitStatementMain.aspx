<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="AutoDebitStatementMain.aspx.cs" Inherits="WebApp.admin.AutoDebitStatementMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .t01 th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        .t02 th {
            background-color: navy;
            color: white;
        }
        .disn {
            display:none;
        }
        .disy {
            display:block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">


    <div class="row">
        <SG:Message runat="server" ID="MessageBox" />


        <div class="col-md-12">

            <!-- general form elements disabled -->
            <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                    <h3 class="box-title">Auto Debit Statement</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">


                    <div class="row">

                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Branch</label>
                                <asp:DropDownList runat="server" ID="GodownId" CssClass="form-control">
                                </asp:DropDownList>

                            </div>
                        </div>
                       
                 
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>From Date </label>
                                <asp:TextBox runat="server" ID="FromDate" CssClass="form-control Date"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="FromDate" runat="server" ForeColor="Red"
                                    ErrorMessage="Please enter From Date" Display="Dynamic"
                                    ValidationGroup="ok"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>To Date </label>
                               

                                <div class="input-group input-group-sm">
                <asp:TextBox runat="server" ID="ToDate" CssClass="form-control Date"></asp:TextBox>
                                             
                    <span class="input-group-btn">
                         <asp:Button runat="server" ID="GetData" Text="Get Data" ValidationGroup="ok" CssClass="btn btn-info btn-flat" OnClick="GetData_Click" />
                      
                    </span>
              </div>

 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ToDate" runat="server" ForeColor="Red"
                                    ErrorMessage="Please enter To Date" Display="Dynamic" 
                                    ValidationGroup="ok"></asp:RequiredFieldValidator>
                                
                                           
                               
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:GridView ID="gvlocation"  Style='width: 100%' CssClass='t02 t01' HeaderStyle-BackColor="LightBlue" runat="server"  AutoGenerateColumns="false" Width="98%" align="center">
                                    <Columns>
                                       
                                        <asp:TemplateField HeaderText="SR.NO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="TRANSACTION OUTLET">
                                            <ItemTemplate>

                                                <%# Eval("TRANSACTIONOUTLET")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="OpenBalance">
                                            <ItemTemplate>
                                                <%# Eval("OpenBalance")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DebitAmount">
                                            <ItemTemplate>
                                                <%# Eval("DebitAmount")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                        <asp:TemplateField HeaderText="CreditAmount">
                                            <ItemTemplate>
                                                <%# Eval("CreditAmount")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reversal Amount">
                                            <ItemTemplate>
                                                <%# Eval("ReversalAmount")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        
                                    

                                        <asp:TemplateField HeaderText="CloseBalance">
                                            <ItemTemplate>
                                                <%# Eval("CloseBalance")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                

                                                <%# Eval("Key")%>
                                            </ItemTemplate>
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
    <asp:Literal runat="server" ID="UpdatePanels"></asp:Literal>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
    <script>
        function showLeter(str) {
              var popup;
              var left = (screen.width - 450) / 2; var top = (screen.height - 500) / 4;

              var popup = window.open(str, 'Scheme Month wise Data Excel Format', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no,fullscreen=yes, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=' + top + ', left=' + left);
              popup.focus();
          }


    </script>
</asp:Content>
