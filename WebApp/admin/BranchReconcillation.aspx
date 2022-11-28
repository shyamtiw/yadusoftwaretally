<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="BranchReconcillation.aspx.cs" Inherits="WebApp.admin.BranchReconcillation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .t01 th, td {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 12px !important;
            font-size: 15px;
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
    Branch Reconcillation
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
                                   <div style="text-align: right; padding: 5px;">
                                   
                                                         <input id="myInput" type="text" placeholder="Search.." >

                                                        <span class="input-group-btn">
                                                            <a  class="btn btn-primary" OnClick="Print_Click()" >Export</a>

                                                        </span>
                                                    </div>
                              
                                <div class="table-responsive">
                                <asp:GridView ID="gvlocation"  Style='width: 100%' CssClass='t02 t01' HeaderStyle-BackColor="LightBlue" runat="server" AutoGenerateColumns="false" Width="98%" align="center">
                                    <Columns>
                                      
                                        <asp:TemplateField HeaderText="SR.NO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch">
                                            <ItemTemplate><%# Eval("Branch")%> </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Ledger Name">
                                            <ItemTemplate><%# Eval("ledgerName")%> </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                   
                                      
                                        <asp:TemplateField HeaderText="Opening Balance">
                                            <ItemTemplate><%# Eval("openingBalance")%> </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                     
                                        <asp:TemplateField HeaderText="Closing Balance">
                                            <ItemTemplate><%# Eval("closingBalance")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Group">
                                            <ItemTemplate><%# Eval("reservedName")%> </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="Recurcive Group">
                                            <ItemTemplate><%# Eval("Group")%> </ItemTemplate>
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
    <script src="js/jquery.table2excel.js"></script>
    <script type="text/javascript">  
        $(function () {
            $('[id*=BranchId]').multiselect({
                includeSelectAllOption: true
            });
        });

        

        function showLeter(str) {
            var popup;
            debugger;
            var wird= parseInt(((screen.width*75)/100.00).toFixed(0));
            var left = (screen.width - wird) / 2; var top = (screen.height - 500) / 4;

            var popup = window.open(str, "Responce", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + wird + ', height=' + 500 + ', top=' + top + ', left=' + left);
            popup.focus();
        }


         function Print_Click() {
            
            var table =$('#<%=gvlocation.ClientID %>').prepend($("<thead></thead>").prev($('#<%=gvlocation.ClientID %>').find("tr:first")));
					if(table && table.length){
					    debugger;
						$(table).table2excel({

                  name: "Data",
							filename: "Export_Notredeem " + new Date().toISOString().replace(/[\-\:\.]/g, "") + ".xls",
							fileext: ".xls",
							exclude_img: true,
							exclude_links: true,
							exclude_inputs: true,
							preserveColors: true
						});
					}
				}


            $(document).ready(function () {
                  $('#<%=gvlocation.ClientID %>').prepend($("<thead></thead>").append($('#<%=gvlocation.ClientID %>').find("tr:first")));
            $("#myInput").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#<%=gvlocation.ClientID %> tbody").find("tr").filter(function () {
                  $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
              });
            });
        });

    
    </script>
</asp:Content>
