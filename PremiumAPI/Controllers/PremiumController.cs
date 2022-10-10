using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;

namespace PremiumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {

        private readonly IWebHostEnvironment _environment;

        public PremiumController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public IEnumerable<PremiumClass> Get([FromBody] PremiumParam model)
        {
            IEnumerable<PremiumModel> premiumClasses = LoadData();

            var query = from p in premiumClasses
                        where p.Plan.Contains(model.Plan) &&
                              (p.State == model.State || p.State.Equals("*")) &&
                              (p.MonthOfBirth.Equals(model.DateOfBirth?.ToString("MMMM", new CultureInfo("en-US")))
                              || p.MonthOfBirth.Equals("*")) &&
                              (p.AgeStart <= model.Age && model.Age <= p.AgeEnd)
                        select new PremiumClass { Carrier = p.Carrier, Premium = p.Premium };

            return query.ToList();
        }

        [NonAction]
        public IEnumerable<PremiumModel> LoadData()
        {
            var fullpath = Path.Combine(_environment.ContentRootPath, "Data/data.json");
            var jsonData = System.IO.File.ReadAllText(fullpath);
            var premiums = JsonConvert.DeserializeObject<List<PremiumModel>>(jsonData);
            return premiums;
        }

    }
}
