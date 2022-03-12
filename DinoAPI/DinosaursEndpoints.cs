using DinoAPI.Responses;

namespace DinoAPI;

internal static class DinosaursEndpoints
{
    internal static IEndpointRouteBuilder AddDinosaursEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/dinosaurs/{filter:alpha}", (string filter) =>
        {
            string[] dinosaurs_genera = DinosaursData.GetDinosaursGenera();

            IEnumerable<GetDinosaursResponse> dinosaurs = dinosaurs_genera
            .Where(dinosaur_genera => dinosaur_genera.ToLower().StartsWith(filter.ToLower()))
            .Select(dinosaur_genera =>
                new GetDinosaursResponse
                (
                    Genera: dinosaur_genera
                )
            );

            return dinosaurs;
        })
        .WithName("GetDinosaurs");

        return endpoints;
    }
}
