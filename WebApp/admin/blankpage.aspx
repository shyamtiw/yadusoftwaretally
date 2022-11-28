<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="blankpage.aspx.cs" Inherits="WebApp.admin.blankpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">





    <div class="row" style="padding-left: 10px!important; padding-right: 10px!important">



        <div class="nav-tabs-custom">
            <ul class="nav nav-tabs">
                <li class="active"><a href="#tab_1" data-toggle="tab" aria-expanded="true"><b>
                    <asp:Literal runat="server" ID="HeadFinance" Text="Retail Performance"></asp:Literal></b></a></li>
                <li class=""><a href="#tab_2" data-toggle="tab" aria-expanded="false"><b>
                    <asp:Literal runat="server" ID="Enabler_Performance" Text="Enabler Performance"></asp:Literal></b></a></li>
                <li class=""><a href="#tab_3" data-toggle="tab" aria-expanded="false"><b>
                    <asp:Literal runat="server" ID="Finance_Performance" Text="Finance Performance"></asp:Literal></b></a></li>

                <li class="pull-right"><a href="#" title="Parameter Selector" class="text-muted" onclick="ShowModal()"><i class="fa fa-gear"></i></a></li>
            </ul>
            <div class="tab-content" style="height: 200px;">
                <div class="tab-pane active" id="tab_1">
                    <div class="col-md-12">
                        <div class="box box-default">

                            <!-- /.box-header -->
                            <div class="box-body" style='background-color: #ecf0f5; border: 1px solid #0b0336!important;'>
                                <div class="row">
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-aqua"><i class="fa fa-envelope-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">Retail</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="Retail"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-green"><i class="fa fa-flag-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">RTL Cancel</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="RTLCancel"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-yellow"><i class="fa fa-files-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">Net. Retail</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="Netretail"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-md-2 col-sm-4 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-red"><i class="fa fa-star-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">Exchange</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="InHouseFinance"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <div class="col-md-2 col-sm-4 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-red"><i class="fa fa-star-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">Corporate</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="SelfFinance"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-aqua"><i class="fa fa-star-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">MSR</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="CashRetail"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->
                                </div>

                                <div class="row">
                                    <center>
                           
                     
             <table class="">
<tr>
<td>
    <asp:LinkButton runat="server" ID="MTD" CssClass="btn btn-block btn-success btn-flat" OnClick="MTD_Click">MTD</asp:LinkButton>
                    
                  </td>
<td>
    <asp:LinkButton runat="server" ID="Ytd" CssClass="btn btn-block btn-info btn-flat" OnClick="Ytd_Click">YTD</asp:LinkButton>
         
                  </td>

</tr>
</table>
                              
                       </center>
                                </div>

                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                    </div>
                </div>
                <div class="tab-pane" id="tab_2">

                    <div class="col-md-12">
                        <div class="box box-default">

                            <!-- /.box-header -->
                            <div class="box-body" style='background-color: #ecf0f5; border: 1px solid #0b0336!important;'>
                                <div class="row">
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-aqua"><i class="fa fa-envelope-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">Retail</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="Retail_Enabler"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-green"><i class="fa fa-flag-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">RTL Cancel</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="RTLCancel_Enabler"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-yellow"><i class="fa fa-files-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">Net. Retail</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="NetRetail_Enabler"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-md-2 col-sm-4 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-red"><i class="fa fa-star-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">EW</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="Ew_Enabler"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <div class="col-md-2 col-sm-4 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-red"><i class="fa fa-star-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">Mi</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="MI_Enabler"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-aqua"><i class="fa fa-star-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">MGA</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="MGA_Enabler"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <div class="row">
                                    <center>
                           
                     
            <table class="">
<tr>
<td>
    <asp:LinkButton runat="server" ID="MTD_Enabler" CssClass="btn btn-block btn-success btn-flat" OnClick="MTD_Enabler_Click">MTD</asp:LinkButton>
                    
                  </td>
<td>
    <asp:LinkButton runat="server" ID="Ytd_Enabler" CssClass="btn btn-block btn-info btn-flat" OnClick="Ytd_Enabler_Click">YTD</asp:LinkButton>
         
                  </td>

</tr>
</table>
                              
                       </center>
                                </div>

                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                    </div>

                </div>
                <div class="tab-pane" id="tab_3">

                    <div class="col-md-12">
                        <div class="box box-default">

                            <!-- /.box-header -->
                            <div class="box-body" style='background-color: #ecf0f5; border: 1px solid #0b0336!important;'>
                                <div class="row">
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <a href="BNDReportAsondate.aspx">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua"><i class="fa fa-envelope-o"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">BND</span>
                                                    <span class="info-box-number">
                                                        <asp:Literal runat="server" ID="BND_Finance"></asp:Literal></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                        </a>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-green"><i class="fa fa-flag-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">Delivered</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="Delivered_Finance"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->

                                    <!-- /.col -->
                                    <div class="col-md-2 col-sm-4 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-red"><i class="fa fa-star-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">In House</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="InHouse_Finance"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <div class="col-md-2 col-sm-4 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-red"><i class="fa fa-star-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">Self Finance</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="SelfFinance_Finance"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-aqua"><i class="fa fa-star-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">Cash Retail</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="CashRetail_Finance"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <div class="info-box">
                                            <span class="info-box-icon bg-yellow"><i class="fa fa-files-o"></i></span>

                                            <div class="info-box-content">
                                                <span class="info-box-text">DSA</span>
                                                <span class="info-box-number">
                                                    <asp:Literal runat="server" ID="DSA_Finance"></asp:Literal></span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->
                                </div>


                                <div class="row">
                                    <center>
                           
                     
            <table class="">
<tr>
<td>
    <asp:LinkButton runat="server" ID="MTD_Finance" CssClass="btn btn-block btn-success btn-flat" OnClick="MTD_Finance_Click">MTD</asp:LinkButton>
                    
                  </td>
<td>
    <asp:LinkButton runat="server" ID="Ytd_Finance" CssClass="btn btn-block btn-info btn-flat" OnClick="Ytd_Finance_Click">YTD</asp:LinkButton>
         
                  </td>

</tr>
</table>
                              
                       </center>
                                </div>
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                    </div>
                </div>
            </div>
        </div>







    </div>
    
    <div class="modal modal-info fade in" id="ParameterSelectionModal">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">×</span></button>
                <h4 class="modal-title">Dashboard Filter Section</h4>
              </div>
              <div class="modal-body">
                           <div class="row">
                                <div class="col-md-12">
                                    <label>Region</label>
                                    <asp:ListBox ID="Region" runat="server" SelectionMode="Multiple" CssClass="form-control"  ></asp:ListBox>
                                </div>
                                <div class="col-md-12">
                                    <label>Chanel</label>
                                    <asp:ListBox ID="Chanel" runat="server" SelectionMode="Multiple" CssClass="form-control"  ></asp:ListBox>
                                </div>

                                <div class="col-md-12">
                                    <label>Branch</label>
                                    <asp:ListBox ID="BranchId" runat="server" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                                </div>
                               

                        

                                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-outline"  data-dismiss="modal">Save changes</button>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">

    <script>
        function ShowModal() {
            $("#ParameterSelectionModal").modal("show");
        }
    </script>
</asp:Content>
