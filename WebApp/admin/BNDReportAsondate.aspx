<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="BNDReportAsondate.aspx.cs" Inherits="WebApp.admin.BNDReportAsondate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .t01 th, td {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 2px 2px 2px 2px;
            font-size: 11px;
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">



    <div class="row">

        <div class="col-xs-12">
            <div class="box">
                <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                    <h3 class="box-title" style="color: white">Data List</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body no-padding">
                    <div class="row">

                        <div class="col-md-11">
                        </div>
                        <div class="col-md-1">



                            <asp:LinkButton runat="server" ID="exportdata" CssClass="btn btn-primary  btn-flat" OnClick="exportdata_Click"><i class="fa fa-file-excel-o"></i></asp:LinkButton>






                        </div>





                    </div>
                   
                        <asp:GridView ID="gvlocation" Style='width: 100%' CssClass='t02 t01' runat="server" AutoGenerateColumns="false" Width="98%" align="center">
                            <Columns>
                              
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="BranchName" HeaderStyle-Wrap="False" ItemStyle-Wrap="False">
                                    <ItemTemplate><%# Eval("BranchName")%></ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="DMSINVNo">
                                    <ItemTemplate><%# Eval("DMSINVNo")%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DMSINVDate">
                                    <ItemTemplate><%# Eval("DMSINVDate")%></ItemTemplate>
                                </asp:TemplateField>
                              
                               
                               
                                <asp:TemplateField HeaderText="VARIANT" HeaderStyle-Wrap="False" ItemStyle-Wrap="False">
                                    <ItemTemplate><%# Eval("VARIANT")%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ChasNo">
                                    <ItemTemplate><%# Eval("ChasNo")%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ENGINE_NUM">
                                    <ItemTemplate><%# Eval("ENGINE_NUM")%></ItemTemplate>
                                </asp:TemplateField>
                          
                                <asp:TemplateField HeaderText="MulInvDate">
                                    <ItemTemplate><%# Eval("MulInvDate")%></ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="CustomerName" HeaderStyle-Wrap="False" ItemStyle-Wrap="False">
                                    <ItemTemplate><%# Eval("CustomerName")%></ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="ErpExecutive" HeaderStyle-Wrap="False" ItemStyle-Wrap="False">
                                    <ItemTemplate><%# Eval("ErpExecutive")%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ageing">
                                    <ItemTemplate><%# Eval("Ageing")%></ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <EmptyDataTemplate>
                                No Record Exists
                            </EmptyDataTemplate>
                        </asp:GridView>
                   
                </div>



                <!-- /.box-body -->
            </div>
            <!-- /.box -->
        </div>



    </div>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
