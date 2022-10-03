using CHEMTECH_API.DATA;
using CHEMTECH_API.ENTIDADES;
using CHEMTECH_API.ENTIDADES.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHEMTECH_API.ENDPOINTS
{
    public static class CIDADEEndpoint
    {
        public static void MapCIDADEEndpoint(this WebApplication app)
        {
            app.MapGet("/v1/cidades", async (int CID_COD) =>
            {
                List<ParametroValor> pv = new()
                {
                    new ParametroValor("@CID_COD", CID_COD)
                };
                var result = await Persistencia.ExecutarSql<CIDADE>(@"[dbo].[usp_CIDADESelect]", pv, tipoconsulta: TipoConsulta.STORED_PROCEDURE);
                return result.ToList() is not null || !result.ToList().Any() ? Results.Ok(result.ToList()) : Results.NoContent();
            }).WithTags("CIDADE").Produces<IEnumerable<CIDADE>>();

            app.MapGet("/v1/cidadesPorNome", async (string NOME) =>
            {
                List<ParametroValor> pv = new()
                {
                    new ParametroValor("@NOME", NOME)
                };
                var result = await Persistencia.ExecutarSql<CIDADE>(@"[dbo].[usp_SelectCidadePorNome]", pv, tipoconsulta: TipoConsulta.STORED_PROCEDURE);
                return result.ToList() is not null || !result.ToList().Any() ? Results.Ok(result.ToList()) : Results.NoContent();
            }).WithTags("CIDADE").Produces<IEnumerable<CIDADE>>();

            app.MapGet("/v1/cidadesPorEstado", async (string ESTADO) =>
            {
                List<ParametroValor> pv = new()
                {
                    new ParametroValor("@ESTADO", ESTADO)
                };
                var result = await Persistencia.ExecutarSql<CIDADE>(@"[dbo].[usp_SelectCidadePorEstado]", pv, tipoconsulta: TipoConsulta.STORED_PROCEDURE);
                return result.ToList() is not null || !result.ToList().Any() ? Results.Ok(result.ToList()) : Results.NoContent();
            }).WithTags("CIDADE").Produces<IEnumerable<CIDADE>>();

            app.MapPost("/v1/cidadesInstert", async (CIDADEVIEW model) =>
            {
                var cidade = model.MapTo();
                if (!model.IsValid)
                    return Results.BadRequest(model.Notifications);
                List<ParametroValor> pv = new()
                {
                    new ParametroValor("@NOME", cidade.NOME),
                    new ParametroValor("@ESTADO", cidade.ESTADO)
                };
                var result = await Persistencia.ExecutarSql<CIDADE>(@"[dbo].[usp_CIDADEInsert]", pv, tipoconsulta: TipoConsulta.STORED_PROCEDURE);
                var obj = result.FirstOrDefault();
                return Results.Created($"/v1/cidades/{obj?.CID_COD}", obj);
            }).WithTags("CIDADE").Produces<CIDADE>();

            app.MapPut("/v1/cidadesUpdate", async (CIDADUPDATEVIEW model) =>
            {
                var cidade = model.MapTo();
                if (!model.IsValid)
                    return Results.BadRequest(model.Notifications);
                List<ParametroValor> pv = new()
                {
                    new ParametroValor("@CID_COD", cidade.CID_COD),
                    new ParametroValor("@NOME", cidade.NOME),
                    new ParametroValor("@ESTADO", cidade.ESTADO)
                };
                var result = await Persistencia.ExecutarSql<CIDADE>(@"[dbo].[usp_CIDADEUpdate]", pv, tipoconsulta: TipoConsulta.STORED_PROCEDURE);
                var obj = result.FirstOrDefault();
                return Results.Created($"/v1/cidades/{obj?.CID_COD}", obj);
            }).WithTags("CIDADE").Produces<CIDADE>();

            app.MapDelete("/v1/cidadesDelete", (int CID_COD) =>
            {
                List<ParametroValor> pv = new()
                {
                    new ParametroValor("@CID_COD", CID_COD)
                };
                Persistencia.ExecutarSqlSemRetorno(@"[dbo].[usp_CIDADEDelete]", pv, tipoconsulta: TipoConsulta.STORED_PROCEDURE);
                return Results.Ok();
            }).WithTags("CIDADE");
        }
    }
}
