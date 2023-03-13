using System;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
	[ApiController] // isn't necessary , but gives better developer experience as it has aut returning some errors and all
	[Route("api/cities")] //you can do [Route("api/[controller]")] also  
    public class CitiesController : ControllerBase //controller base has common methods that the model needs
	{
		[HttpGet] // instead of [HttpGet("api/cities")] we have used api/cities in the route
        public ActionResult<IEnumerable<CityDto>> GetCities()  // to return list of cities
		{
            return Ok(CitiesDataStore.Current.Cities);

    //        return new JsonResult(CitiesDataStore.Current.Cities
				////new List<object>{
				////	new { id = 1, Name = "New York City" },
				////	new { id = 2, Name = "Antwrep" }


				////}
    //            );
		}

        [HttpGet("{id}")]

        public ActionResult<CityDto> GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);//status code can be sent and also other stuff then we can send like HTML
        }


        //public JsonResult GetCity(int id)
        //{
        //    return new JsonResult(
        //        CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));
        //}

        //[HttpGet("api/towns")]
        //public JsonResult GetTowns()  // to return list of cities
        //{
        //    return new JsonResult(
        //        new List<object>{
        //            new { id = 4, Name = "Kanakapura" },
        //            new { id = 5, Name = "Sirsi" }


        //        });
        //}
    }

}