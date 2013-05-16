<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero-unit">
    <h1>일년전 오늘. 당신은 무엇을 했나요?</h1>
    <br>
    <p>지금 로그인 하세요</p>
    <% Html.BeginForm(null, null, FormMethod.Post, new { @class = "form-horizontal" });  %>
        <input type="submit" class="btn btn-primary btn-large" value="Log In &raquo;" >
    <% Html.EndForm(); %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
<script type="text/javascript">
    (function ($) {
        var userId = '<%= ViewData["me2dayid"] %>'
        , $userID = $("#me2dayid")

        if (userId !== '') {
            $userID.val(userId);
            $("#RememberMe").attr("checked", true);
        } else if (userId === '') {
            $userID.focus();
        } 

    })(jQuery);
</script>
</asp:Content>
