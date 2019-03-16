<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GnvNotifications.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<div  id="DivGnNot" class="jumbotron" style="margin-left:2%; margin-right:2%;">                               
         <asp:Label ID="Label2" runat="server" Style="margin-left:30%;font-size:24px;" Text="Generate Notification" CssClass="text-primary"></asp:Label>        <br />
                <asp:Label ID="Label1" runat="server" Style="font-size:20px;" Text="Vendor Id" CssClass="text-primary"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>          
                 <br/>                                            
                 <asp:TextBox ID="TextBox1" runat="server" style="color:#e0e0e0 !important;" CssClass="txtbx btn-block"></asp:TextBox>                                                                
                 <asp:Label ID="LblDesc" runat="server" Style="font-size:20px;" Text="Description" CssClass="text-primary"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtAreaComplaint"></asp:RequiredFieldValidator>          
                 <br />         
                 <asp:TextBox ID="TxtAreaComplaint" TextMode="MultiLine" runat="server"  style="margin-top:5px; height:250px; color:#e0e0e0 !important;" CssClass="txtbx btn-block"></asp:TextBox>                                      
                 <asp:Button ID="BtnRaise" runat="server" Text="Send" CausesValidation="true" Style="margin-top:8px;" onclick="BtnRaise_Click" CssClass="btn btn-primary btn-block" />                  
            <div class="cls" runat="server" id="MyServerControlDiv"></div>            
         </div>
</asp:Content>

