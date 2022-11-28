<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="ExportTallyTrialBanlance.aspx.cs" Inherits="WebApp.admin.ExportTallyTrialBanlance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
        .t01 th, td {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 2px 2px 2px 2px;
            font-size: 13px;
        }

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
    Ledger Group Sheet
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">

   
            <div class="row">
                <SG:Message runat="server" ID="MessageBox" />


                <div class="col-md-12">

                    <!-- general form elements disabled -->
                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                            <h3 class="box-title">Data List</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">



                            <div class="row">


                                <div class="col-md-6">
                                    <label>Branch</label>
                                    <asp:ListBox ID="BranchId" runat="server" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                                </div>
                                 <div class="col-md-2">
                                    <label> From  Date </label>
                                 <asp:TextBox runat="server" ID="FromDate"  CssClass="form-control Date"></asp:TextBox>
                                </div>

                                <div class="col-md-2">
                                    <label> To Date </label>
                                 <asp:TextBox runat="server" ID="Date"  CssClass="form-control Date"></asp:TextBox>
                                </div>

                              
                                <div class="col-md-2">
                                    <label> </label>
                                    <div class="input-group">
                                      
                                        <span class="input-group-btn">
                                            <asp:LinkButton runat="server" ID="btnsearchdata" CssClass="btn btn-warning btn-flat" OnClick="btnsearchdata_Click"><i class="fa fa-fw fa-search"></i></asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="exportdata" CssClass="btn btn-primary-flat" OnClick="btnsearchdata_Click">Export</asp:LinkButton>
                                             
                                        </span>
                                    </div>

                                </div>

                                </div>

                                <hr />
                                <hr />
                                <hr />
                                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                
                                <div class="table-responsive">
                                <asp:GridView ID="gvlocation"  Style='width: 100%' class="t02 t01 table table-hover" HeaderStyle-BackColor="LightBlue" runat="server" AutoGenerateColumns="false" Width="98%" align="center">
                                    <Columns>
                                      
                                        <asp:TemplateField HeaderText="SR.NO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                       
                                        <asp:TemplateField HeaderText="Branch">
                                            <ItemTemplate><%# Eval("Branch")%> </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                   
                                      
                                        <asp:TemplateField HeaderText="OPENINGBALANCE">
                                            <ItemTemplate><%# Eval("OPENINGBALANCE")%> </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DEBITBALANCE">
                                            <ItemTemplate><%# Eval("DEBITBALANCE")%> </ItemTemplate>
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="CREDITBALANCE">
                                            <ItemTemplate><%# Eval("CREDITBALANCE")%> </ItemTemplate>
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="CLOSINGBALANCE">
                                            <ItemTemplate><%# Eval("CLOSINGBALANCE")%> </ItemTemplate>
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
          


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
   
</asp:Content>
