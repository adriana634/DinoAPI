namespace DinoAPI;

internal static class DinoEndpoints
{
    private static async Task<IResult> GetAllDinosaurs(IDinosaurData data)
    {
        try
        {
            IEnumerable<DinosaurModel> response = await data.GetAllDinosaurs();
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetDinosaur(int id, IDinosaurData data)
    {
        try
        {
            DinosaurModel? response = await data.GetDinosaur(id);
            if (response == null) return Results.NotFound();
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> SearchDinosaurs(string criteria, IDinosaurData data)
    {
        try
        {
            IEnumerable<DinosaurModel> response = await data.SearchDinosaurs(criteria);
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    internal static WebApplication ConfigureDinoEndpoints(this WebApplication app)
    {
        app.MapGet("/dinosaurs", GetAllDinosaurs);
        app.MapGet("/dinosaur/{id:int}", GetDinosaur);
        app.MapGet("/dinosaurs/{criteria:alpha}", SearchDinosaurs);

        return app;
    }
}
