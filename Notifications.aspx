<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Notifications.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <div style="margin-left:2%; margin-right:2%;">            
            <div id="notDiv" class="col-sm-6" style="margin-left:10%;">            
                <h4 style="margin-top:2%;padding-bottom:10px; " class="text-primary">My Notifications</h4>                        
                <div class="cls" runat="server" id="MyServerControlDiv"></div>
            </div>
        </div>    
</asp:Content>

