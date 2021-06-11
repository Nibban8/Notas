#### ASP.NET Web Application (.NET Framework) -> Api

#### Instalar y usar CORS

- Install-Package Microsoft.AspNet.WebApi.Cors -Version 5.2.7
- EnableCorsAttribute cors = new EnableCorsAttribute("_", "_", "\*");
- config.EnableCors(cors);

#### Pasos

- Hacer Scaffold
- Crear Modelos
- Crear Controllers
- Agregar cors en App_start -> WebApiConfig.cs
