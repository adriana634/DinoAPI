using DinoAPI.Responses;
using Microsoft.Extensions.Caching.Memory;

namespace DinoAPI
{
    internal static class DinosaursEndpoints
    {
        internal static IEndpointRouteBuilder AddDinosaursEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/dinosaurs/{filter:alpha}", (string filter, IMemoryCache cache) =>
            {
                IEnumerable<GetDinosaursResponse> dinosaurs;

                bool in_cache = cache.TryGetValue(filter, out dinosaurs);

                if (in_cache == true)
                {
                    return dinosaurs;
                } 
                else
                {
                    string[] dinosaurs_genera = DinosaursData.GetDinosaursGenera();

                    dinosaurs = dinosaurs_genera
                    .Where(dinosaur_genera => dinosaur_genera.ToLower().StartsWith(filter.ToLower()))
                    .Select(dinosaur_genera =>
                        new GetDinosaursResponse
                        (
                            Genera: dinosaur_genera
                        )
                    );

                    cache.Set(filter, dinosaurs);

                    return dinosaurs;
                }
            })
            .WithName("GetDinosaurs");

            return endpoints;
        }
    }
}
