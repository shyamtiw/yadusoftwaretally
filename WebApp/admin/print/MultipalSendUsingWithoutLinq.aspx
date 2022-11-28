<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultipalSendUsingWithoutLinq.aspx.cs" Inherits="WebApp.admin.print.MultipalSendUsingWithoutLinq" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2family=Ubuntu:wght@300&display=swap" rel="stylesheet">
    

    <style>

        body {
  
   font-family: 'Ubuntu', sans-serif;
}
page {
  background: white;
  display: block;
  margin: 0 auto;
  
}
page[size="A4"] {  
  width: 21cm;
  height: 29.7cm; 
}

@media print {
  body, page {
    margin: 0;
  
  }
}

        /*body {
            width: 21cm;
            height: 7.9cm;
           
        }*/

        .topdiv {
            <!-- border-left: 1px solid #e3faf2; -->
            border-collapse: collapse;
            border-style: solid;
            border-width: 1px;
            width: 99%;
            height: 33%;
        }

        h1 {
            font-size: 40px;
            padding: 0px 0px 10px 0px;
            margin: 0px 0px 0px 0px;
        }

        h2 {
            font-size: 30px;
            padding: 0px 0px 10px 0px;
            margin: 0px 0px 0px 0px;
        }

        h3 {
            font-size: 20px;
            padding: 0px 0px 10px 0px;
            margin: 0px 0px 0px 0px;
        }

        h4 {
            font-size: 15px;
            padding: 0px 0px 10px 0px;
            margin: 0px 0px 0px 0px;
        }

        p {
            font-size: 12px;
            padding: 0px 0px 10px 0px;
            margin: 0px 0px 0px 0px;
        }

        .p1 {
            font-size: 10px;
            padding: 10px 0px 10px 0px;
            margin: 0px 0px 0px 0px;
        }


        u.dotted {
            border-bottom: 1px dashed #999;
            text-decoration: none;
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <page size="A4">
            <asp:Repeater runat="server" ID="itemloop">
                <ItemTemplate>
        <div class="topdiv"  style="text-align:left;margin-right:5px">
            <table style="width: 100%">
                <tr>
                   
                    
                    <td style="width: 100%">
                        <h4 style="text-align: center">||INSURANCE COUPON(<%# Eval("Name") %>)||</h4>
                        <h2 style="text-align: center;  width:100%;  border-collapse: collapse;border-style: solid;border-width: 1px;" ><%= Request.QueryString["CompName"].ToString() %></h2>
                        <div style="width:100%"> </div>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 40%">
                                    <p><b>Coupon No :</b><u class="dotted"><%# Eval("Code") %></u></p>
                                </td>
                                <td style="width: 20%">
                                     <p  style="text-align: left;"><b>Issue Date :</b><u class="dotted"><%# Convert.ToDateTime( Eval("IssueDate")).ToString("dd/MM/yyyy") %></u> </p>
                                </td>
                                <td style="width: 20%">
                                    <p style="text-align: right;"><b>Valid upto </b>:<u class="dotted"><%# Convert.ToDateTime( Eval("PolicyExpiryDate")).ToString("dd/MM/yyyy") %></u></p>
                                </td>
                            </tr>
                        </table>

                        <table style="width: 100%">
                            <tr>
                                <td style="width: 40%">
                                   <p><b>Customer Name :</b><u class="dotted"> <%# Eval("CustomerName") %></u></p>
                                </td>
                                <td style="width: 20%">
                                     <p  style="text-align: left;"><b>Mobile No. :</b><u class="dotted"> <%# Eval("MobNo") %></u> </p>
                                </td>
                                <td style="width: 20%">
                                     <p  style="text-align: right;"><b>Regn No. :</b><u class="dotted"><%# Eval("VehicleRegnNo") %></u> </p>
                                </td>
                            </tr>
                        </table>
                  <table style="width: 100%">
                            <tr>
                                <td style="width: 40%">
                                   <p><b>Advisor Name:</b><u class="dotted"><%# Eval("DealersExecutive") %></u></p>
                                </td>
                                <td style="width: 20%">
                                     <p  style="text-align: left;"><b>Chassis No.:</b><u class="dotted"><%# Eval("ChassisNo") %></u> </p>
                                </td>
                                <td style="width: 20%">
                                     <p  style="text-align: right;"><b>Engine No. :</b><u class="dotted"> <%# Eval("EngineNo") %></u> </p>
                                </td>
                            </tr>
                        </table>

                       
                      
                        <h4 style="text-align: center; padding-bottom: 0px">Avail Discount</h4>
                        <p style="text-align: center; padding-bottom: 0px">||<%# Eval("Description") %>||</p>
                           <br />
                        <br />
                           <%--<svg id="barcode"></svg>--%>
                           <br />

                        <table style="width: 100%">
                            <tr>
                                <td style="width: 60%">

                                    <p>
                                         <br/>
                                        *This is an one time offer can't be clubbed with other offers.<br />
                                        *This coupon is only valid at all <%= Request.QueryString["CompName"].ToString() %>  Authorised Workshop.
                                        <br />
                                        *Please present this coupon at the time of job card opening. 

                                    </p>
                                </td>
                                <td style="width: 40%">
                                    <h3 style="text-align: right; padding-bottom: 0px">
                                        
                                        <br />
                                        <%= Request.QueryString["CompName"].ToString() %></h3>
                                </td>
                            </tr>
                        </table>

                      
                    </td>

                </tr>
            </table>

        </div>
                    <hr />
                    </ItemTemplate>
                </asp:Repeater>
            </page>
    </form>
</body>

    <script src="JsBarcode.code128.min.js"></script>

    <script>
        JsBarcode("#barcode", "1234", {
            format: "pharmacode",
            lineColor: "#0aa",
            width: 4,
            height: 40,
            displayValue: false
        });
    </script>

</html>
