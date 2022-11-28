<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="InsurancePaymentData.aspx.cs" Inherits="WebApp.admin.InsurancePaymentData" %>

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
        <SG:Message runat="server" ID="MessageBox" />


        <div class="col-md-12">

            <!-- general form elements disabled -->
            <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                    <h3 class="box-title">Insurance Payment Data</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">


                    



                    <div class="row">

                        <div class="col-md-4">
                            <div class="form-group">
                                <label>From Date </label>
                                <asp:TextBox runat="server" ID="FromDate" CssClass="form-control Date"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>To Date </label>
                                <asp:TextBox runat="server" ID="ToDate" CssClass="form-control Date"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-3">
                                    <label style="color: white">To Date </label>
                                    <asp:Button runat="server" ID="GetData" Text="Get Data" CssClass="btn btn-info" OnClick="GetData_Click" />
                                </div>
                               

                            </div>
                        </div>


                    </div>

                    <div class="row">
                        <div class="col-md-12">
                             <div class="form-group">
                                <div style="text-align: right; padding: 5px;">
                                    
                                             <div class="input-group input-group-sm">
                                                         <input id="myInput" type="text" placeholder="Search.." >

                                                        <span class="input-group-btn">
                                                            <a  class="btn btn-primary" OnClick="Print_Click()" >Export</a>

                                                        </span>
                                                    </div>
                                </div>

                                <div class="table-responsive">

                                <asp:GridView ID="gvlocation" Height="150px" Style='width: 100%' CssClass='t02 t01' HeaderStyle-BackColor="LightBlue" runat="server"  AutoGenerateColumns="false" Width="98%" align="center">
                                    <Columns>
                                       
                                        <asp:TemplateField HeaderText="SR.NO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Exists
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div></div>

          
                </div>
            </div>
        </div>

    </div>
    <asp:Literal runat="server" ID="UpdatePanels"></asp:Literal>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
     <script src="js/jquery.table2excel.js"></script>
    <script>

   
			
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
				
			
		</script>

</asp:Content>
