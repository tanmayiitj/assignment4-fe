using EMPN0990_Scenerio2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;



using Microsoft.AspNetCore.Mvc;




namespace EMPN0990_Scenario2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // GET: api/<ValuesController>

        string baseURL = "https://dummy.restapiexample.com/api/v1/employees";

        // get all employees by calling https://dummy.restapiexample.com/api/v1/employees 
        // and return only the data array of Employee objects
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            System.Diagnostics.Debug.WriteLine(baseURL);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var employees = JsonConvert.DeserializeObject<List<Employee>>(data);
                    Console.WriteLine(employees);
                    return Ok(employees);
                }
                return BadRequest();

            }
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
