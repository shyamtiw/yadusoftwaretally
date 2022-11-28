<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="DiscountAnalysisReport.aspx.cs" Inherits="WebApp.admin.DiscountAnalysisReport" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">

  
    
        <div class="row">
            
            <div class="col-xs-12">
                <div class="box">
                  <div class="box-header with-border"   style="background: #0b0336!important; background-color: #0b0336!important;">
            <h3 class="box-title" style="color:white">Discount Analysis Report.</h3>
        </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <div class="row">
                   
                <div class="col-md-2">
                    <div class="form-group">
                        <label>Branch</label>
                        <asp:DropDownList runat="server" ID="BranchId" class="form-control"></asp:DropDownList>
                    </div>

                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <label>Staus</label>
                        <asp:DropDownList runat="server" ID="Status" class="form-control">
                              <asp:ListItem Text="All" Value="All"> </asp:ListItem>
                            <asp:ListItem Text="Pending" Value="Pending">

                            </asp:ListItem>
                            
                              <asp:ListItem Text="Complete" Value="Complete">

                            </asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
                            <div class="col-md-2">
                    <div class="form-group">
                        <label>Filter by Dt</label>
                        <asp:DropDownList runat="server" ID="FilterbyDt" class="form-control">
                              
                            <asp:ListItem Text="INV Date" Value="1">
                            </asp:ListItem>
                             <asp:ListItem Text="Do Date" Value="2">
                            </asp:ListItem>
                              <asp:ListItem Text="DeliveryDate" Value="3">
                            </asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <label>From Date</label>
                        <asp:TextBox runat="server" CssClass="form-control Date" ID="FromDate" placeholder="From Date"></asp:TextBox>
                        
                    </div>

                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <label>To Date</label>
                                                <asp:TextBox runat="server" CssClass="form-control Date" ID="ToDate" placeholder="To Date"></asp:TextBox>
                        
                    </div>

                </div>
                <div class="col-md-2">
                    
                        <label>Search</label>
                        <div class="input-group">
                           <table>
                               <tr>
                                   <td style="width:90%">
                                         <asp:TextBox runat="server" CssClass="form-control" ID="txtSearch"   placeholder="Search....." ></asp:TextBox>
                                       
                                   <td style="width:10%"> 
                                          <asp:LinkButton runat="server" ID="GetData"  CssClass="btn btn-primary"  OnClick="GetData_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                       </td>
                                   
                               </tr>
                           </table>
                            
                        </div>

                    

                </div>





            </div>

                       
                       


                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>



        </div>
            </div>
       
  


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
       


</asp:Content>
