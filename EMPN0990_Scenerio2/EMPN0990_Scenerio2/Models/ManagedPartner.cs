using System.Text.RegularExpressions;

namespace EMPN0990_Scenario2.Models
{
    public class ManagedPartner
    {
        public DateTime ManagedFrom { get; set; } = DateTime.Now;

        public PartnerAccountManager AccountManager { get; set; } = new PartnerAccountManager();

        // add method to set PartnerAccountManager wiht all the checks that we did in PartnerAccountManager class
        public void SetPartnerAccountManager(PartnerAccountManager accountManager)
        {
            if (accountManager != null
            && accountManager.Email != string.Empty
            && Regex.IsMatch(accountManager.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
            && accountManager.ManagerEmail != string.Empty
            && Regex.IsMatch(accountManager.ManagerEmail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
            && accountManager.Specialization != string.Empty)
            {
                AccountManager = accountManager;
            }
        }

    }
}
