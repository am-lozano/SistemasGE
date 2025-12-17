using System.Reflection;
using System.Xml.Linq;

@model PlantaWithNombreCategoriaDTO
<h2>@Model.planta.nombre</h2>
<p>@Model.planta.descripcion</p>
<p>Categoría: @Model.nombreCategoria </ p >
< form method = "post" >
< input type = "hidden" name = "id" value = "@Model.planta.id" />
< input type = "number" step = "0.01" name = "precioNuevo" />
< button type = "submit" > Guardar </ button >
</ form >
@if(ViewBag.Error != null){< p > @ViewBag.Error </ p >}
