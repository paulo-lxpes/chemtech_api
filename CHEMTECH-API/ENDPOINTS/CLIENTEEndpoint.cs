using CHEMTECH_API.DATA;
using CHEMTECH_API.ENTIDADES.ModelViews;
using CHEMTECH_API.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHEMTECH_API.ENDPOINTS
{
    public static class CLIENTEEndpoint
    {
        public static void MapCLIENTEEndpoint(this WebApplication app)
        {
            app.MapGet("/v1/clientes", async (int CLI_COD) =>
            {
                List<ParametroValor> pv = new()
                {
                    new ParametroValor("@CLI_COD", CLI_COD)
                };
                var result = await Persistencia.ExecutarSql<CLIENTE>(@"[dbo].[usp_CLIENTESelect]", pv, tipoconsulta: TipoConsulta.STORED_PROCEDURE);
                return result.ToList() is not null || !result.ToList().Any() ? Results.Ok(result.ToList()) : Results.NoContent();
            }).WithTags("CLIENTE").Produces<IEnumerable<CLIENTE>>();

            app.MapGet("/v1/clientesPorNome", async (string NOME) =>
            {
                List<ParametroValor> pv = new()
                {
                    new ParametroValor("@NOME", NOME)
                };
                var result = await Persistencia.ExecutarSql<CLIENTE>(@"[dbo].[usp_SelectPorNomeCliente]", pv, tipoconsulta: TipoConsulta.STORED_PROCEDURE);
                return result.ToList() is not null || !result.ToList().Any() ? Results.Ok(result.ToList()) : Results.NoContent();
            }).WithTags("CLIENTE").Produces<IEnumerable<CLIENTE>>();

            app.MapPost("/v1/clientesInstert", async (CLIENTEVIEW model) =>
            {
                var cliente = model.MapTo();
                if (!model.IsValid)
                    return Results.BadRequest(model.Notifications);
                List<ParametroValor> pv = new()
                {
                    new ParametroValor("@NOME", cliente.NOME),
                    new ParametroValor("@SEXO", cliente.SEXO),
                    new ParametroValor("@DATA_NASCIMENTO", cliente.DATA_NASCIMENTO),
                    new ParametroValor("@IDADE", cliente.IDADE),
                    new ParametroValor("@CID_COD", cliente.CID_COD)
                };
                var result = await Persistencia.ExecutarSql<CLIENTE>(@"[dbo].[usp_CLIENTEInsert]", pv, tipoconsulta: TipoConsulta.STORED_PROCEDURE);
                var obj = result.FirstOrDefault();
                return Results.Created($"/v1/clientes/{obj?.CLI_COD}", obj);
            }).WithTags("CLIENTE").Produces<CLIENTE>();

            app.MapPut("/v1/clientesUpdate", async (CLIENTEUPDATEVIEW model) =>
            {
                var cliente = model.MapTo();
                if (!model.IsValid)
                    return Results.BadRequest(model.Notifications);
                List<ParametroValor> pv = new()
                {
                    new ParametroValor("@CLI_COD", cliente.CLI_COD),
                    new ParametroValor("@NOME", cliente.NOME),
                    new ParametroValor("@SEXO", cliente.SEXO),
                    new ParametroValor("@DATA_NASCIMENTO", cliente.DATA_NASCIMENTO),
                    new ParametroValor("@IDADE", cliente.IDADE),
                    new ParametroValor("@CID_COD", cliente.CID_COD)
                };
                var result = await Persistencia.ExecutarSql<CLIENTE>(@"[dbo].[usp_CLIENTEUpdate]", pv, tipoconsulta: TipoConsulta.STORED_PROCEDURE);
                var obj = result.FirstOrDefault();
                return Results.Created($"/v1/clientes/{obj?.CLI_COD}", obj);
            }).WithTags("CLIENTE").Produces<CLIENTE>();

            app.MapPut("/v1/clientesUpdateNome", async (CLIENTEUPDATENOMEVIEW model) =>
            {
                var cliente = model.MapTo();
                if (!model.IsValid)
                    return Results.BadRequest(model.Notifications);
                List<ParametroValor> pv = new()
                {
                    new ParametroValor("@CLI_COD", cliente.CLI_COD),
                    new ParametroValor("@NOME", cliente.NOME),
                };
                var result = await Persistencia.ExecutarSql<CLIENTE>(@"[dbo].[usp_UpdateNomeCliente]", pv, tipoconsulta: TipoConsulta.STORED_PROCEDURE);
                var obj = result.FirstOrDefault();
                return Results.Created($"/v1/clientes/{obj?.CLI_COD}", obj);
            }).WithTags("CLIENTE").Produces<CLIENTE>();

            app.MapDelete("/v1/clientesDelete", (int CLI_COD) =>
            {
                List<ParametroValor> pv = new()
                {
                    new ParametroValor("@CLI_COD", CLI_COD)
                };
                Persistencia.ExecutarSqlSemRetorno(@"[dbo].[usp_CLIENTEDelete]", pv, tipoconsulta: TipoConsulta.STORED_PROCEDURE);
                return Results.Ok();
            }).WithTags("CLIENTE");
        }
    }
}
