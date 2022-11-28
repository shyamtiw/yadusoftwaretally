<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="voucherpreview.aspx.cs" Inherits="WebApp.admin.voucherpreview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">
    <div class="row">
        <!-- left column -->
        <div class="col-md-12">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Creator Vocuher</h3>
                </div>
                <div class="box-body">
                    <div class="form-group">
                
                               <div class="table-responsive">
                                <asp:GridView ID="gvcreator"  Style='width: 100%' CssClass='t02 t01' HeaderStyle-BackColor="LightBlue" runat="server" AutoGenerateColumns="false" Width="98%" align="center">
                                    <Columns>
                                      
                                        <asp:TemplateField HeaderText="SR.NO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Branch">
                                            <ItemTemplate><%# Eval("Branch")%> </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                        <asp:TemplateField HeaderText="VocherType">
                                            <ItemTemplate><%# Eval("VocherType")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="VoucherNo">
                                            <ItemTemplate><%# Eval("VoucherNo")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="VoucherDate">
                                            <ItemTemplate><%#  Eval("VoucherDate")%> </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                   
                                   
                                      
                                        <asp:TemplateField HeaderText="Ledger">
                                            <ItemTemplate><%# Eval("Ledger")%> </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                         <asp:TemplateField HeaderText="Dr">
                                                  <ItemTemplate><%# Convert.ToDecimal( Eval("Dr"))>0? Eval("Dr").ToString():""%> </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Cr">
                                            <ItemTemplate><%# Convert.ToDecimal( Eval("Cr"))>0? Eval("Cr").ToString():""%> </ItemTemplate>
                                        </asp:TemplateField>
                                   
                                   
                                         <asp:TemplateField HeaderText="Narration">
                                            <ItemTemplate><%# Eval("Narration")%> </ItemTemplate>
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

         <div class="col-md-12">
            <!-- general form elements -->
            <div class="box box-warning">
                <div class="box-header with-border">
                    <h3 class="box-title">Approver Vocuher</h3>
                </div>
                <div class="box-body">
                    <div class="form-group">
                
                               <div class="table-responsive">
                                <asp:GridView ID="gvapprover"  Style='width: 100%' CssClass='t02 t01' HeaderStyle-BackColor="LightBlue" runat="server" AutoGenerateColumns="false" Width="98%" align="center">
                                    <Columns>
                                      
                                        <asp:TemplateField HeaderText="SR.NO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Branch">
                                            <ItemTemplate><%# Eval("Branch")%> </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                        <asp:TemplateField HeaderText="VocherType">
                                            <ItemTemplate><%# Eval("VocherType")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="VoucherNo">
                                            <ItemTemplate><%# Eval("VoucherNo")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="VoucherDate">
                                            <ItemTemplate><%# Eval("VoucherDate")%> </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                   
                                   
                                      
                                        <asp:TemplateField HeaderText="Ledger">
                                            <ItemTemplate><%# Eval("Ledger")%> </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                         <asp:TemplateField HeaderText="Dr">
                                            <ItemTemplate><%# Convert.ToDecimal( Eval("Dr"))>0? Eval("Dr").ToString():""%> </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Cr">
                                            <ItemTemplate><%# Convert.ToDecimal( Eval("Cr"))>0? Eval("Cr").ToString():""%> </ItemTemplate>
                                        </asp:TemplateField>
                                   
                                         <asp:TemplateField HeaderText="Narration">
                                            <ItemTemplate><%# Eval("Narration")%> </ItemTemplate>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
