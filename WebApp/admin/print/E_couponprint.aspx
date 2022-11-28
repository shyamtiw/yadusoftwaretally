<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E_couponprint.aspx.cs" Inherits="WebApp.admin.print.E_couponprint" %>

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
            height: 100%;
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


        <div class="topdiv"  style="text-align:left;margin-right:5px">
            <table style="width: 100%">
                <tr>
                   
                    
                    <td style="width: 100%">
                        <h4 style="text-align: center">||INSURANCE COUPON(<asp:Literal runat="server"  ID="CouponName"></asp:Literal>)||</h4>
                        <h2 style="text-align: center;  width:100%;  border-collapse: collapse;border-style: solid;border-width: 1px;" > <asp:Literal runat="server"  ID="CompName3"></asp:Literal></h2>
                        <div style="width:100%"> </div>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 40%">
                                    <p><b>Coupon No :</b><u class="dotted">  <asp:Literal runat="server"  ID="Code"></asp:Literal></u></p>
                                </td>
                                <td style="width: 20%">
                                     <p  style="text-align: left;"><b>Issue Date :</b><u class="dotted"> <asp:Literal runat="server"  ID="IssueDate"></asp:Literal></u> </p>
                                </td>
                                <td style="width: 20%">
                                    <p style="text-align: right;"><b>Valid upto </b>:<u class="dotted"> <asp:Literal runat="server"  ID="ValidDate"></asp:Literal></u></p>
                                </td>
                            </tr>
                        </table>

                        <table style="width: 100%">
                            <tr>
                                <td style="width: 40%">
                                   <p><b>Customer Name :</b><u class="dotted"> <asp:Literal runat="server"  ID="CustomerName"></asp:Literal></u></p>
                                </td>
                                <td style="width: 20%">
                                     <p  style="text-align: left;"><b>Mobile No. :</b><u class="dotted"><asp:Literal runat="server"  ID="MobileNo"></asp:Literal></u> </p>
                                </td>
                                <td style="width: 20%">
                                     <p  style="text-align: right;"><b>Regn No. :</b><u class="dotted"><asp:Literal runat="server"  ID="regNo"></asp:Literal></u> </p>
                                </td>
                            </tr>
                        </table>
                  <table style="width: 100%">
                            <tr>
                                <td style="width: 40%">
                                   <p><b>Advisor Name:</b><u class="dotted"> <asp:Literal runat="server"  ID="AdvisorName"></asp:Literal></u></p>
                                </td>
                                <td style="width: 20%">
                                     <p  style="text-align: left;"><b>Chassis No.:</b><u class="dotted"> <asp:Literal runat="server"  ID="Chassis"></asp:Literal></u> </p>
                                </td>
                                <td style="width: 20%">
                                     <p  style="text-align: right;"><b>Engine No. :</b><u class="dotted"> <asp:Literal runat="server"  ID="EngineNo"></asp:Literal></u> </p>
                                </td>
                            </tr>
                        </table>

                       
                      
                        <h4 style="text-align: center; padding-bottom: 0px">Avail Discount</h4>
                        <p style="text-align: center; padding-bottom: 0px">||<asp:Literal runat="server"  ID="CoupenDiscount"></asp:Literal>||</p>
                           <br />
                           <br />
                           <br />

                        <table style="width: 100%">
                            <tr>
                                <td style="width: 60%">

                                    <p>
                                         <br/>
                                        *This is an one time offer can't be clubbed with other offers.<br />
                                        *This coupon is only valid at all <asp:Literal runat="server"  ID="CompName1"></asp:Literal>  Authorised Workshop.
                                        <br />
                                        *Please present this coupon at the time of job card opening. 

                                    </p>
                                </td>
                                <td style="width: 40%">
                                    <h3 style="text-align: right; padding-bottom: 0px">
                                        
                                        <br />
                                        <asp:Literal runat="server"  ID="CompName2"></asp:Literal></h3>
                                </td>
                            </tr>
                        </table>

                      
                    </td>

                </tr>
            </table>

        </div>
            </page>
    </form>
</body>
</html>
