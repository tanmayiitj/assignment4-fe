using System.Text.RegularExpressions;

namespace EMPN0990_Scenario2.Models
{
    public class PartnerAccountManager
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string ManagerEmail { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;

        // add methods to set email, manager email with validation that input is not empty/null and regex validation for email

        public void SetEmail(string email)
        {
            if (email != null && email != string.Empty && Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                Email = email;
            }
        }

        public void SetManagerEmail(string managerEmail)
        {
            if (managerEmail != null && managerEmail != string.Empty && Regex.IsMatch(managerEmail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                ManagerEmail = managerEmail;
            }
        }

        public PartnerAccountManager() { }
    }
}
