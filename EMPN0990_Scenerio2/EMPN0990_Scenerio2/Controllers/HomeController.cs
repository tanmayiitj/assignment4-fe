using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using EMPN0990_Scenerio2.Models;

namespace EMPN0990_Scenerio2.Controllers{
     public class HomeController : Controller
    {
        private static List<Employee> _employeesCache = new List<Employee>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            if (_employeesCache.Count == 0)
            {
                await PopulateEmployeesCache();
            }

            return View(_employeesCache);
        }

        private async Task PopulateEmployeesCache()
        {
            string baseURL = "https://dummy.restapiexample.com/api/v1/employees";
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseURL);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(data);
                _employeesCache = JsonConvert.DeserializeObject<List<Employee>>(json["data"].ToString());
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GetEmployee(int id)
        {
            Employee employee = _employeesCache.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                return Json(employee);
            }
            else
            {
                return Json("Employee not found");
            }
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeesCache.Add(employee);
            return Json(employee);
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            Employee existingEmployee = _employeesCache.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Employee_name = employee.Employee_name;
                existingEmployee.Employee_salary = employee.Employee_salary;
                existingEmployee.Employee_age = employee.Employee_age;
                existingEmployee.Profile_image = employee.Profile_image;
                return Json(existingEmployee);
            }
            else
            {
                return Json("Employee not found");
            }
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            Employee employeeToRemove = _employeesCache.FirstOrDefault(e => e.Id == id);
            if (employeeToRemove != null)
            {
                _employeesCache.Remove(employeeToRemove);
                return Json("Employee deleted");
            }
            else
            {
                return Json("Employee not found");
            }
        }
    }
}

