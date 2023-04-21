using Data.AppCommandDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RedisRest.Model;


namespace RedisRest.Controllers;

[ApiController]
[Route("[controller]")]
public class CommandController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IDistributedCache _cache;
    private readonly AppCommandDbContext _context;

    public CommandController(
        ILogger<WeatherForecastController> logger,
        IDistributedCache cache, AppCommandDbContext context)
    {
        _logger = logger;
        _cache = cache;
        _context = context;
    }

   [HttpGet("Macmiils")]
    public async Task<IActionResult> Get(){
         List<Macmiilka>  macmiilList = new();
       var cacheCategory = _cache.GetString("macmiil");
      
       if(!string.IsNullOrEmpty(cacheCategory)){
         macmiilList = JsonConvert.DeserializeObject<List<Macmiilka>>(cacheCategory);
         DistributedCacheEntryOptions options = new();
         options.SetAbsoluteExpiration(new TimeSpan(0,15,seconds: 0));
       }
       else{
        macmiilList = _context.Macmiilkas.ToList();
        _cache.SetString("macmiil", JsonConvert.SerializeObject(macmiilList));

       }
       return Ok(macmiilList);
    }

   
}
