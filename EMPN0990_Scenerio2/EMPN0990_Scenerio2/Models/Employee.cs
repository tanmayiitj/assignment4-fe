namespace EMPN0990_Scenerio2.Models
{
    public class Employee
    {
        public int Id { get; set; } = 0;
        public string Employee_name { get; set; } = string.Empty;
        public int Employee_age { get; set; } = 0;

        public string Profile_image { get; set; } = string.Empty;

        public int Employee_salary { get; set; } = 0;

        public Employee() { }
    }
}
