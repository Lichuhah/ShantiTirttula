using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Managers;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Server.Api.Controllers;

[Route("api/test-data")]
[ApiController]
public class TestDataController : Controller
{
    [HttpGet]
    public bool TestData()
    {
        SensorDataManager man = new SensorDataManager();
        Random rnd = new Random(DateTime.UtcNow.Millisecond);
        IAuth auth = new AuthManager().Get(2);
        ISensor sensor = new SensorManager().Get(2);
        DateTime startData = DateTime.UtcNow - TimeSpan.FromHours(22);
        DateTime endData = DateTime.UtcNow;
        SensorData data;
        int value = 1800;
        for (DateTime i = startData; i < DateTime.Parse("May 9. 2023"); i += TimeSpan.FromMinutes(1))
        {
             data = new SensorData();
             data.DateTime = i;
             data.Auth = auth;
             data.Sensor = sensor;
             data.Value = value;
             value += (1 - rnd.Next(10) / 10);
             man.Save(data);
        }

        value = Convert.ToInt32(man.All().Where(x => x.Sensor == sensor).OrderByDescending((x => x.Id)).First().Value);
        for (DateTime i = DateTime.Parse("May 9. 2023"); value > 1850; i += TimeSpan.FromMinutes(1))
        {
            value -= 10;
            data = new SensorData();
            data.DateTime = i;
            data.Auth = auth;
            data.Sensor = sensor;
            data.Value = value;
            man.Save(data);
        }
        
        value = Convert.ToInt32(man.All().Where(x => x.Sensor == sensor).OrderByDescending((x => x.Id)).First().Value);
        int r = 1;
        for (DateTime i = man.All().Where(x=>x.Sensor==sensor).OrderByDescending((x=>x.Id)).First().DateTime; i < endData; i += TimeSpan.FromMinutes(1))
        {
            
            if (value > 1850)
            {
                r = -10;
            }
            if (value < 1750)
            {
                r = 1;
            }
            value += r;
            data = new SensorData();
            data.DateTime = i;
            data.Auth = auth;
            data.Sensor = sensor;
            data.Value = value;
            man.Save(data);
        }
        
        return true;
    }
}