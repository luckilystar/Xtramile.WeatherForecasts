using System.Collections.Generic;
using Xtramile.WeatherForecasts.Library.Dtos;

namespace Xtramile.WeatherForecasts.Library.Responses
{
    public class GetAllCountriesResponse: BaseResponse<List<CountryDto>>
    {
        public GetAllCountriesResponse(List<CountryDto> countries):base(countries) { }
    }
}
