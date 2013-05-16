<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        안녕하세요 <b><%: Page.User.Identity.Name %></b>님!
        [ <%: Html.ActionLink("로그오프", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("로그온", "LogOn", "Account") %> ]
<%
    }
%>
