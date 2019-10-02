<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BakeHome.aspx.cs" Inherits="BakeSoft.BakeHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Bakery Soft</title>  </head>
<body style="font-family: Arial,'Helvetica Neue',Helvetica,sans-serif;">
    <form id="form1" runat="server">
    <div>
   <div style="width:100%;background-color:lightgray;height:50px;">
      
       <strong><center><h2>Bakery Billing</h2></center></strong>
     
   </div>
        <br />
   <div style="width:100%">
       <div style="width:70%;float:left;">
           <strong><center><h3>Billing address</h3></center></strong>
       </div>
       <div style="width: 25%;float: right;margin-right: 5%;">
           <strong><h3><center>Your Cart</center></h3></strong>
           <hr />
           <table style="width:100%;">
               <tr>
                   <th align="left"><strong>Item</center></strong></th>
                   <th><strong><center>Quantity</center></strong></th>
                   <th><strong><center>Price</center></strong></th>
               </tr>
               <tr>
                   <td colspan="3"></td>
               </tr>
               <tr>
                   <td><asp:Label ID="lblFirstItemName" runat="server" Font-Bold="true" Text="0.00"></asp:Label></td> <%--Vegemite Scroll--%>
                   <td><center>10</center></td>
                   <td><center><asp:Label ID="lblFirsttItem" runat="server" Font-Bold="true" Text="0.00"></asp:Label></center></td>
               </tr>
                <tr>
                   <td><asp:Label ID="lblSecondtItemName" runat="server" Font-Bold="true" Text="0.00"></asp:Label></td>  <%--Blueberry Muffin--%>
                   <td><center>14</center></td>
                   <td><center><asp:Label ID="lblSecondtItem" runat="server" Font-Bold="true" Text="0.00"></asp:Label></center></td>
               </tr>
                <tr>
                   <td><asp:Label ID="lblThirdItemName" runat="server" Font-Bold="true" Text="0.00"></asp:Label></td> <%--Croissant--%>
                   <td><center>13</center></td>
                   <td><center><asp:Label ID="lblThirdItem" runat="server" Font-Bold="true" Text="0.00"></asp:Label></center></td>
               </tr>
                <tr>
                   <td colspan="3"><hr /></td>
               </tr>
                <tr>
                   <td colspan="2"><strong><center>Total Amount</center></strong></td>
                    <td><asp:Label ID="lblTotalAount" runat="server" Font-Bold="true" Text="0.00/-"></asp:Label></td>
               </tr>
           </table>
       </div>
   </div>
    </div>
    </form>
</body>
</html>
