
<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="VoucherlistApprover.aspx.cs" Inherits="WebApp.admin.VoucherlistApprover" %>

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
    Voucher  List
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
                        <div class="col-md-12">
                            <div class="form-group">
                                   <div style="text-align: right; padding: 5px;">
                                   <div class="input-group">
                       <input id="myInput" type="text" placeholder="Search.." >
                      <span class="input-group-btn">
                             <a  class="btn btn-info btn-flat" OnClick="Print_Click()" >Export</a>
                          </span>
                    </div>
                                                       

                                                        
                                                    </div>
                              
                                <div class="table-responsive">
                                <asp:GridView ID="gvlocation"  Style='width: 100%' CssClass='t02 t01' HeaderStyle-BackColor="LightBlue" runat="server" AutoGenerateColumns="false" Width="98%" align="center">
                                    <Columns>
                                      
                                        <asp:TemplateField HeaderText="SR.NO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Requester Branch">
                                            <ItemTemplate><%# Eval("ReuestFromBranch")%> </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                        <asp:TemplateField HeaderText="Requested User">
                                            <ItemTemplate><%# Eval("UserName")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MobileNo">
                                            <ItemTemplate><%# Eval("MobileNo")%> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Request Send  Date">
                                            <ItemTemplate><%# Convert.ToDateTime( Eval("CreateDateTime")).ToString("dd/MM/yyyy hh:mm tt")%> </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                   
                                   
                                      
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate><%# Eval("VocuherTotal")%> </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                         <asp:TemplateField HeaderText="Narration">
                                            <ItemTemplate><%# Eval("CreatorNarration")%> </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action" >
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" Text="Approve Now" ID="Sessionactive"  PostBackUrl='<%# Eval("InterbranchEntryId","approvoucher.aspx?InterbranchEntryId={0}") %>' CssClass="label label-sm label-info" Visible='<%# Convert.ToInt32( Eval("Status"))==1?true:false %>' ></asp:LinkButton>
                                                <asp:LinkButton runat="server" Text="Reject" ID="LinkButton1"   CssClass="label label-sm label-danger" Visible='<%# Convert.ToInt32( Eval("Status"))==1?true:false %>' ></asp:LinkButton>
                                             
                                                <a onclick="<%# Eval("InterbranchEntryId","showLeter('voucherpreview.aspx?InterbranchEntryId={0}')") %>" class='label label-sm label-danger <%# Convert.ToInt32( Eval("Status"))==3?"disy":"disn" %>'>Preview</a>       

                                                
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
                    </div></div>

          
                </div>
            </div>
        </div>

   
    <asp:Literal runat="server" ID="UpdatePanels"></asp:Literal>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
      <script src="js/jquery.table2excel.js"></script>
    <script>
        function showLeter(str) {
            var popup;
            debugger;
            var wird = parseInt(((screen.width * 75) / 100.00).toFixed(0));
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

