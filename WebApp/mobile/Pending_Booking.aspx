<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pending_Booking.aspx.cs" Inherits="WebApp.mobile.Pending_Booking" %>


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
</head>

<body>

    <!-- loader -->
    <div id="loader">
        <img src="assets/img/logo-icon.png" alt="icon" class="loading-icon">
    </div>
    <!-- * loader -->

   
        <!-- App Header -->
        <div class="appHeader">
            <div class="left">
                <a href="Booking_Dashbaord.aspx" class="headerButton">
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


                  <asp:Repeater runat="server" ID="ZeroPendingItem">
                    <ItemTemplate>
                       
                          <a href="<%# Eval("BookingId","app-transaction-detail.aspx?BookingId={0}") %>" class="item">
                              <%--<a href="<%# (( Eval("MODEL_CD").ToString()=="CE" ||  Eval("MODEL_CD").ToString()=="WA" ||  Eval("MODEL_CD").ToString()=="ER" ) && Eval("GE1").ToString()=="CNG"?"#":  Eval("BookingId","app-transaction-detail.aspx?BookingId={0}")) %>" class="item">--%>
                            <div class="detail">
                                <div>

                                    <%-- <strong style="color:red"><%# (( Eval("MODEL_CD").ToString()=="CE" ||  Eval("MODEL_CD").ToString()=="ER" ||  Eval("MODEL_CD").ToString()=="CI" ) && Eval("GE1").ToString()=="CNG"?"Non Discount Modal":  "") %>  </strong>--%>

                                        <strong><%# Eval("Cust_Name") %> ( <%# Eval("Cust_ID") %> )  </strong>
                                        <h4>Booking No         : <%# Eval("Trans_id") %></h4>
                                        <h4>Booking Date         : <%# Eval("Trans_Date") %></h4>
                                        <h4>Variant Detail : <%# Eval("Variant_Name") %> </h4>
                                        <h4>Variant Color       : <%# Eval("Color_Name") %></h4>
                                        <h4>Fuel Type         : <%# Eval("GE1") %></h4>
                                      <h4>Buyer Type         : <%# Eval("GE4") %></h4>
                                        <h4>Enquiry Source         : <%# Eval("GE6") %></h4>
                                        <h4>Evaluation   Status      : <%# Eval("GE9") %></h4>

                                    </div>
                            </div>
                             </a>
                       
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater runat="server" ID="LoopItem">
                    <ItemTemplate>
                       
                           <a href="<%# Eval("BookingId","app-transaction-detail.aspx?BookingId={0}") %>" class="item">
                            <div class="detail">
                                <div>
                                        <h4><%# Eval("Cust_Name") %> ( <%# Eval("Cust_ID") %> )  </h4>
                                        <h4>Booking No         : <%# Eval("Trans_id") %></h4>
                                        <h4>Booking Date         : <%# Eval("Trans_Date") %></h4>
                                        <h4>Variant Detail : <%# Eval("Variant_Name") %> </h4>
                                        <h4>Variant Color       : <%# Eval("Color_Name") %></h4>
                                        <h4>Fuel Type         : <%# Eval("GE1") %></h4>
                                        <h4>Buyer Type         : <%# Eval("GE4") %></h4>
                                        <h4>Enquiry Source         : <%# Eval("GE6") %></h4>
                                        <h4>Evaluation   Status      : <%# Eval("GE9") %></h4>
                                        <h4><%=Request.QueryString["status"].ToString()=="3"?"Reject":Request.QueryString["status"].ToString()=="4"?"Approve":"Request" %> Amount: <%# Eval("Amount") %></h4>
                                    <% if (Request.QueryString["status"].ToString() == "2")
                                        {%>
                                    <h4>Request To: <%# Eval("RequestToname") %></h4>

                                    <% }
                                    else
                                    {  %>
                                        <h4><%=Request.QueryString["status"].ToString() == "3" ? "Reject By" : Request.QueryString["status"].ToString() == "4" ? "Approve By" : "Request" %> Name:   <%# Eval("Approvername") %></h4>
                                    <%} %>

                                      <h4><%# WebApp.LIBS.Common.ConvertInt( Request.QueryString["status"]) == 2?"Recommend Date":WebApp.LIBS.Common.ConvertInt( Request.QueryString["status"]) == 3 ? "Reject Date" : WebApp.LIBS.Common.ConvertInt( Request.QueryString["status"]) == 4 ? "Approve Date" : "Request Date" %>  : <%# Eval("Approverdate") %></h4>
                                       
                                      <h4><%# WebApp.LIBS.Common.ConvertInt( Request.QueryString["status"]) == 2?"Recommend  Reason":WebApp.LIBS.Common.ConvertInt( Request.QueryString["status"]) == 3 ? "Reject Reason" : WebApp.LIBS.Common.ConvertInt( Request.QueryString["status"]) == 4 ? "Approve Reason" : "Request Reason" %>  : <%# Eval("ApproverRemark") %></h4>
                                            


                                    </div>
                            </div>
                             </a>
                        
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <!-- * Transactions -->


           <!-- app footer -->
            <div class="appFooter">
                <div class="footer-title">
                    Copyright © Navy-GEN 2021. All Rights Reserved.
           
                </div>
            </div>
            <!-- * app footer -->

        </div>
        <!-- * App Capsule -->
        <!-- App Sidebar -->
        <div class="modal fade panelbox panelbox-left" id="sidebarPanel" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <!-- profile box -->
                        <div class="profileBox pt-2 pb-2">
                            <div class="image-wrapper">
                                
                            </div>
                            <div class="in">
                                <strong>Admin</strong>
                                <div class="text-muted">129580</div>
                            </div>
                            <a href="#" class="btn btn-link btn-icon sidebar-close" data-bs-dismiss="modal">
                                <ion-icon name="close-outline"></ion-icon>
                            </a>
                        </div>
                        <!-- * profile box -->

                        <!-- action group -->
                        <div class="action-group">
                            <a href="index.html" class="action-button">
                                <div class="in">
                                    <div class="iconbox">
                                        <ion-icon name="add-outline"></ion-icon>
                                    </div>
                                    Central-1
                           
                                </div>
                            </a>
                            <a href="index.html" class="action-button">
                                <div class="in">
                                    <div class="iconbox">
                                        <ion-icon name="arrow-down-outline"></ion-icon>
                                    </div>
                                    Central-2
                           
                                </div>
                            </a>
                            <a href="index.html" class="action-button">
                                <div class="in">
                                    <div class="iconbox">
                                        <ion-icon name="arrow-forward-outline"></ion-icon>
                                    </div>
                                    Central-3
                           
                                </div>
                            </a>
                            <a href="app-cards.html" class="action-button">
                                <div class="in">
                                    <div class="iconbox">
                                        <ion-icon name="card-outline"></ion-icon>
                                    </div>
                                    Central-4
                           
                                </div>
                            </a>
                        </div>
                        <!-- * action group -->

                        <!-- menu -->
                        <div class="listview-title mt-1">Menu</div>
                        <ul class="listview flush transparent no-line image-listview">
                            <li>
                                <a href="index.html" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="pie-chart-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        Sales Performance
                                   
                                    <span class="badge badge-primary">10</span>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="app-pages.html" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="document-text-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        Service Performance
                               
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="MSIL_Receivable.aspx" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="apps-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        Maruti Claims
                               
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="BSC_NSC_Dashboard.aspx" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="card-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        Balance Score Card 
                               
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="BSC_NSC_Dashboard.aspx" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="card-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        Nexa Score Card
                               
                                    </div>
                                </a>
                            </li>
                        </ul>
                        <!-- * menu -->

                        <!-- others -->
                        <div class="listview-title mt-1">Others</div>
                        <ul class="listview flush transparent no-line image-listview">
                            <li>
                                <a href="#" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="settings-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        Insurance
                               
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="component-messages.html" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="chatbubble-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        Bodyshop Claims
                               
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="component-add-to-home.aspx" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="log-out-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        Add to Home Screen
                               
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="app-login.html" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="log-out-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        Log out
                               
                                    </div>
                                </a>
                            </li>


                        </ul>
                        <!-- * others -->

                    </div>
                </div>
            </div>
        </div>
        <!-- * App Sidebar -->
        <!-- iOS Add to Home Action Sheet -->
        <div class="modal inset fade action-sheet ios-add-to-home" id="ios-add-to-home-screen" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Add to Home Screen</h5>
                        <a href="#" class="close-button" data-bs-dismiss="modal">
                            <ion-icon name="close"></ion-icon>
                        </a>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content text-center">
                            <div class="mb-1">
                                <img src="assets/img/icon/192x192.png" alt="image" class="imaged w64 mb-2">
                            </div>
                            <div>
                                Install <strong>Navy-GEN</strong> on your iPhone's home screen.
                       
                            </div>
                            <div>
                                Tap
                            <ion-icon name="share-outline"></ion-icon>
                                and Add to homescreen.
                       
                            </div>
                            <div class="mt-2">
                                <button class="btn btn-primary btn-block" data-bs-dismiss="modal">CLOSE</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>


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
         $(document).ready(function () {
             BindEventsto();
         });


         function BindEventsto() {

             debugger;
             $("div.messageBox").delay(5000).slideUp();
         }
     </script>
    </body>
</html>
