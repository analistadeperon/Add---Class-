@model Mvc_Consultas.Models.ProdutoModel
@{
    ViewBag.Title = "Index";
}
@using PagedList.Mvc;
@{
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
}
@using (Html.BeginForm("Index", "Produto", FormMethod.Get))
{
    @Html.ValidationSummary(false)
    <div style="border-bottom:1px solid #bbb"><h1>Procurar Produto</h1></div>
    <table style="border:0px; width:500px;">
        <tr>
            <td>
                <div class="editor-label">
                    @Html.LabelFor(model => model.Nome)
                </div>
                <div class="editor-field">
                    @Html.EditorFor(model => model.Nome)
                    @Html.ValidationMessageFor(model => model.Nome)
                </div>
            </td>
            <td>
                <div class="editor-label">
                    @Html.LabelFor(model => model.Preco)
                </div>
                <div class="editor-field">
                    @Html.EditorFor(model => model.Preco)
                    @Html.ValidationMessageFor(model => model.Preco)
                </div>
            </td>
            <td style="vertical-align:bottom;">
                <input name="BotaoProcurar" type="submit" value="Procurar" />
            </td>
        </tr>
    </table>
    if (Model.ProcuraResultados != null && Model.ProcuraResultados.Count > 0)
    {
        <table class="table" style=" width:500px;">
            <tr>
                <th>ID</th>
                <th>Produto</th>
                <th>Qtde</th>
                <th>Preco</th>
            </tr>
            @foreach (var product in Model.ProcuraResultados)
            {
                <tr>
                    <td>@product.Id</td>
                    <td>@product.Nome</td>
                    <td>@product.Quantidade</td>
                    <td>@product.Preco</td>
                </tr>
            }
        </table>
        @Html.PagedListPager(Model.ProcuraResultados,page => Url.Action("Index", new RouteValueDictionary()
          {
               { "Pagina", page },
               { "Nome", Model.Nome },
               { "Preco", Model.Preco }
          }),
          PagedListRenderOptions.PageNumbersOnly)
    }
}
