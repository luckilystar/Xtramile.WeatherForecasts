using System.Collections.Generic;
using Xtramile.WeatherForecasts.Library.Dtos;

namespace Xtramile.WeatherForecasts.Library.Responses
{
    public class GetAllCitiesResponse:BaseResponse<List<CityDto>>
    {
        public GetAllCitiesResponse(List<CityDto> cities):base(cities) { }
    }
}
