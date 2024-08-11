using System.Text.RegularExpressions;

namespace EMPN0990_Scenario2.Models
{
    public class Partner
    {
        int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string ContactEmail { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public List<string> Specializations { get; set; } = List<string>();

        private static List<T> List<T>()
        {
            throw new NotImplementedException();
        }

        // add methods to add and remove specializations
        public void AddSpecialization(string specialization)
        {
            if (specialization != null && specialization != string.Empty)
            {
                Specializations.Add(specialization);
            }
        }
        public void RemoveSpecialization(string specialization)
        {
            if (specialization != null && specialization != string.Empty)
            {
                Specializations.Remove(specialization);
            }
        }

        // add methods to set address with validation that input is not empty/null
        public void SetAddress(string address)
        {
            if (address != null && address != string.Empty)
            {
                Address = address;
            }
        }

        // add regex validation for email
        public void SetContactEmail(string email)
        {
            if (email != null && email != string.Empty && Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                ContactEmail = email;
            }
        }


        public Partner() { }
    }
}
