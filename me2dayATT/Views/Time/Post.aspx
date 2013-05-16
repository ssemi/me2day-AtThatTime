<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<% Html.BeginForm(null, null, FormMethod.Post, new {  });  %>
<div id="leftLength" style="float:right;">150</div>
<% for (int i = DateTime.Now.AddYears(-1).Year ; i>= 2007; i--) { %>
<input type="radio" class="year" name="year" id="year_<%= i %>" value="<%= i %>" <%= i == ViewData["year"].ToInt32() ? "checked=\"checked\"" : string.Empty %> /> <label for="year_<%= i %>" style="display:inline;"><%= i %></label>
<% } %>
<br />
<!--
<textarea rows="6" cols="100" id="preText" name="preText" style="width:70%;"><%= ViewData["outputString"] %></textarea>
<br />
-->
<pre>
<%= ViewData["outputString"] %>
</pre>
me2ATT <span id="yyear"><%= ViewData["year"] %></span> <input type="text" name="tag" value="" /> 추가 Tag 를 붙일 수 있어요
<br />
<input type="submit" class="btn btn-primary btn-medium" value="Post my me2day &raquo;" >
<% Html.EndForm(); %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
<script type="text/javascript">
    (function ($) {
        $("input.year").click(function () {
            var msg = $.ajax({ url: "./getPost", type: 'post', data: "year=" + this.value, async: false }).responseText;
            $("pre").html(msg);
            changePreview();
            $("#yyear").text(this.value);
        });
        $("#preText").keyup(function () {
            $("PRE").html($(this).val());
            changePreview();
        });
        $("form").submit(function () {
            if (parseInt($("#leftLength").text(), 0) < 0) {
                return confirm('글이 너무 길어서 150자를 초과합니다. 뒷 부분은 등록이 안되요.\n\n그래도 진행하시겠습니까?');
            }
            else if ($("pre").text().length > 5)
                return true;
            else {
                alert('글이 없어서 등록이 안되어요.\n다른 년도를 선택해보세요');
                return false;
            }

        });
        changePreview();
    })(jQuery);

    function changePreview() {
        var postValueText = $("#preText").val();
        var postValue = $("PRE").text();
        if (hasExpression(postValue)) {
            $("PRE").html(replaceAll(postValue));
        }
        var textValue = $("PRE").html().replace(/<[^>]+>/g, "").replace(/<\/[^>]+>/g, "");
        var leftLength = 150 - textValue.length;
        $("#leftLength").text(leftLength);

    }

    function hasExpression(A) {
        var link_regex = /\"(.*?)\":(http[s]?:\/\/[^\s]*)(\s|$)([!]{0,})/;
        if (link_regex.test(A)) return true;
        else return false;
    }
    function replaceAll(A) {
        var link_regex = /\"(.*?)\":(http[s]?:\/\/[^\s]*)(\s|$)([!]{0,})/;
        var exists = true;
        var resText = A;
        if (link_regex.test(resText)) {
            while (exists) {
                resText = resText.replace(link_regex, "<a href='$2' title='$1' target='_blank'>$1</a>");
                exists = link_regex.test(resText);
            }
        }
        return resText;
    } 
</script>
</asp:Content>
