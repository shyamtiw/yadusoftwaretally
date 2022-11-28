<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit-Employee.aspx.cs" Inherits="WebApp.mobile.Edit_Employee" %>



<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>DSE Pending Booking</title>
    <meta name="description" content="Finapp HTML Mobile Template">
    <meta name="keywords"
        content="bootstrap, wallet, banking, fintech mobile template, cordova, phonegap, mobile, html, responsive" />
    <link rel="icon" type="image/png" href="assets/img/favicon.png" sizes="32x32">
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/icon/192x192.png">
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="manifest" href="__manifest.json">
    <style>
        .rcorners2 {
  border-radius: 10px;
  border: 2px solid #6236FF;
  padding: 10px; 
 margin-bottom:10px;
  
}
    </style>
</head>

<body>

    <!-- loader -->
    <div id="loader">
        <img src="assets/img/logo-icon.png" alt="icon" class="loading-icon">
    </div>
    <!-- * loader -->

   <form runat="server" id="forms">
       <asp:ScriptManager runat="server" ID="sdd" EnablePageMethods="true"></asp:ScriptManager>
        <!-- App Header -->
        <div class="appHeader">
            <div class="left">
                <a href="Admin_Dashbaord.aspx" class="headerButton">
                    <ion-icon name="chevron-back-outline"></ion-icon>
                </a>
            </div>
            <div class="pageTitle">
                <div>Pending Booking </div>
        </div>
        </div>
   
        <!-- * App Header -->


    <!-- App Capsule -->
    <div id="appCapsule">

         <!-- Transactions -->
        <div class="section mt-4">
            <div class="transactions">
                <SG:MessageMobile runat="server" ID="Message"></SG:MessageMobile>


                  <asp:Repeater runat="server" ID="Itemdata">
                    <ItemTemplate>
                       
                       
                           <div class="accordion rcorners2" id="accordionExample<%# Container.ItemIndex %>">
                <div class="accordion-item" >
                    <h2 class="accordion-header">
                        
                        <a class="accordion-button collapsed"  data-bs-toggle="collapse" data-bs-target="#accordion0<%# Container.ItemIndex %>" aria-expanded="false" style="font-size: small;">
                          <%# string.Format("{0} - {1} ({2})",Eval("MSPIN"),Eval("EmployeeName"),Eval("EmployeeCode"))%>
                            
                          
                        </a>
                         <a style="font-size:medium;" href="app-Employee-Master.aspx?EmployeeId=<%# Eval("EmployeeId") %>">Edit</a>
                    </h2>
                    <div id="accordion0<%# Container.ItemIndex %>" class="accordion-collapse collapse" data-bs-parent="#accordionExample<%# Container.ItemIndex %>" style="">
                          <asp:HiddenField runat="server" ID="EmployeeId" Value='<%# Eval("EmployeeId") %>' />
                        <div class="accordion-body">
                              <table>
                                           
                                        <tr>
                                            <td>
                                                <h4>Designation</h4>
                                            </td>
                                            <td>
                                                <h4>: </h4>
                                            </td>
                                            <td>
                                                <h4><%# Eval("Master.Name") %> </h4>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td>
                                                <h4>MobileNo</h4>
                                            </td>
                                            <td>
                                                <h4>: </h4>
                                            </td>
                                            <td>
                                                <h4><%# Eval("MobileNo")  %> </h4>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>Email-Id</h4>
                                            </td>
                                            <td>
                                                <h4>: </h4>
                                            </td>
                                            <td>
                                                <h4><%# Eval("EmailId")  %> </h4>
                                            </td>
                                        </tr>
                                        
                                  </table>
                        </div>
                    </div>
                </div>  
            </div>
                       
                       
                    </ItemTemplate>
                </asp:Repeater>

         
            </div>
        </div>
        <!-- * Transactions -->


           <!-- app footer -->
           <div class="appBottomMenu">
            <a  data-bs-toggle="modal" data-bs-target="#GetBookingData" class="item">
                <div class="col">
                    <ion-icon name="apps-outline"></ion-icon>
                    <h4 class="m-0">Get Booking Data</h4>
                </div>
            </a>
           
        
           <a href="Admin_Dashbaord.aspx" class="item">
                <div class="col">
                    <ion-icon name="pie-chart-outline"></ion-icon>
                    <h4 class="m-0">Home</h4>
                </div>
            </a>
        </div>
            <!-- * app footer -->

        </div>
        <!-- * App Capsule -->
        <!-- App Sidebar -->
     
        <!-- iOS Add to Home Action Sheet -->
         <div class="modal fade action-sheet" id="GetBookingData" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Filter</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">

                                 <div class="form-group basic">
                                <div class="input-wrapper">
                                    <label class="label" for="account2d">Location</label>
                                    <asp:DropDownList runat="server" ID="GodwnId" CssClass="form-control custom-select">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" Font-Bold="true" Font-Size="Smaller" InitialValue="Select" ControlToValidate="GodwnId" ValidationGroup="oks" runat="server" ErrorMessage="Please input"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            
                            <div class="form-group basic">
                                <asp:LinkButton runat="server" ID="btnGetBooking" class="btn btn-primary btn-block btn-lg" ValidationGroup="oks"
                                    OnClick="btnGetBooking_Click">Submit</asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

      


    </form>

        <script src="assets/js/lib/jquery-3.4.1.min.js"></script>
        <!-- Bootstrap-->
        <script src="assets/js/lib/popper.min.js"></script>
        <script src="assets/js/lib/bootstrap.bundle.min.js"></script>
        <!-- Ionicons -->
        <script src="https://unpkg.com/ionicons@5.4.0/dist/ionicons.js"></script>
        <%--<script src="https://unpkg.com/ionicons@4.5.10-0/dist/ionicons.js"></script>--%>
        <!-- Splide -->
        <script src="assets/js/plugins/splide/splide.min.js"></script>
        <!-- Base Js File -->
        <script src="assets/js/base.js"></script>
     <script type="text/javascript">
         var modalShow = false;
         $(document).ready(function () {
             if (modalShow) {
                 $("#GetBookingData").modal("show");
                 modalShow = false;
             }
             BindEventsto();

         });
         function callGodwn() {
             debugger;
             modalShow = true;
         }

         function BindEventsto() {

             debugger;
             $("div.messageBox").delay(5000).slideUp();
         }
     </script>
    </body>
</html>
