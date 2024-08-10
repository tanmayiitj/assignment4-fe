using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Partner
{
    public int PartnerID { get; set; }
    public string PartnerName { get; set; }

    public bool firstTime = true;
    
    private bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        return Regex.IsMatch(email, pattern);
    }

    private string _partnerContactEmail;
    public string PartnerContactEmail
    {
        get { return _partnerContactEmail; }
        set
        {
            if (IsValidEmail(value))
            {
                _partnerContactEmail = value;
            }
            else
            {
                Console.WriteLine("Invalid email format for PartnerContactEmail.");
            }
        }
    }

    private string _partnerGeography;
    public string PartnerGeography
    {
        get { return _partnerGeography; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (_partnerGeography != value && !firstTime)
                {
                    Console.WriteLine($"Updating PartnerGeography from '{_partnerGeography}' to '{value}'");
                }
                _partnerGeography = value;
            }
            else
            {
                Console.WriteLine("PartnerGeography cannot be empty or whitespace.");
            }
        }
    }

    public string[] PartnerSpecializations { get; set; }

    public Partner(int partnerID, string partnerName, string partnerContactEmail, string partnerGeography, string[] partnerSpecializations)
    {
        PartnerID = partnerID;
        PartnerName = partnerName;
        PartnerContactEmail = partnerContactEmail;
        PartnerGeography = partnerGeography;
        PartnerSpecializations = partnerSpecializations;
        firstTime = false;
    }

    public void AddSpecialization(string specialization)
    {
        if (!PartnerSpecializations.Contains(specialization))
        {
            PartnerSpecializations = PartnerSpecializations.Concat(new[] { specialization }).ToArray();
            Console.WriteLine($"Added specialization: {specialization}");
        }
        else
        {
            Console.WriteLine($"Specialization '{specialization}' already exists.");
        }
    }

    public void RemoveSpecialization(string specialization)
    {
        if (PartnerSpecializations.Contains(specialization))
        {
            PartnerSpecializations = PartnerSpecializations.Where(s => s != specialization).ToArray();
            Console.WriteLine($"Removed specialization: {specialization}");
        }
        else
        {
            Console.WriteLine($"Specialization '{specialization}' not found.");
        }
    }
}

public class PartnerAccountManager
{
    public int EmployeeID { get; set; }

    private bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        return Regex.IsMatch(email, pattern);
    }

    private string _email;
    public string Email
    {
        get { return _email; }
        set
        {
            if (IsValidEmail(value))
            {
                _email = value;
            }
            else
            {
                Console.WriteLine("Invalid email format for Email.");
            }
        }
    }

    private string _managerEmail;
    public string ManagerEmail
    {
        get { return _managerEmail; }
        set
        {
            if (IsValidEmail(value))
            {
                _managerEmail = value;
            }
            else
            {
                Console.WriteLine("Invalid email format for ManagerEmail.");
            }
        }
    }

    public string Specialization { get; set; }

    public PartnerAccountManager(int employeeID, string email, string managerEmail, string specialization)
    {
        EmployeeID = employeeID;
        Email = email;
        ManagerEmail = managerEmail;
        Specialization = specialization;
    }
}

public class ManagedPartner : Partner
{
    public DateTime ManagedFrom { get; set; }
    public PartnerAccountManager PartnerAccountManager { get; set; }

    public ManagedPartner(int partnerID, string partnerName, string partnerContactEmail, string partnerGeography,
                            string[] partnerSpecializations, DateTime managedFrom, PartnerAccountManager partnerAccountManager)
        : base(partnerID, partnerName, partnerContactEmail, partnerGeography, partnerSpecializations)
    {
        ManagedFrom = managedFrom;
        PartnerAccountManager = partnerAccountManager;
    }

    public void UpdatePartnerAccountManager(PartnerAccountManager newManager)
    {
        if (newManager != null
            && !string.IsNullOrEmpty(newManager.Email)
            && !string.IsNullOrEmpty(newManager.ManagerEmail)
            && !string.IsNullOrEmpty(newManager.Specialization))
        {
            PartnerAccountManager = newManager;
            Console.WriteLine("Partner Account Manager updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid Partner Account Manager information. Update failed.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Create an instance of the Partner class with different example
        Partner myPartner = new Partner(
            2024,
            "Innovative Solutions",
            "contact@innovativesolutions.com",
            "San Francisco",
            new[] { "Cloud Computing", "Data Analytics" }
        );

        // Display information about the partner
        Console.WriteLine("********** Partner Details **********");
        Console.WriteLine($"Partner ID: {myPartner.PartnerID}");
        Console.WriteLine($"Partner Name: {myPartner.PartnerName}");
        Console.WriteLine($"Partner Email: {myPartner.PartnerContactEmail}");
        Console.WriteLine($"Partner Geography: {myPartner.PartnerGeography}");
        Console.WriteLine("Specializations:");
        foreach (var specialization in myPartner.PartnerSpecializations)
        {
            Console.WriteLine($"- {specialization}");
        }
        Console.WriteLine();

        // Update geography and test methods
        myPartner.PartnerGeography = "Los Angeles";
        myPartner.AddSpecialization("AI & ML");
        myPartner.RemoveSpecialization("Data Analytics");

        // Display updated information
        Console.WriteLine("********** Updated Partner Details **********");
        Console.WriteLine($"Partner ID: {myPartner.PartnerID}");
        Console.WriteLine($"Partner Name: {myPartner.PartnerName}");
        Console.WriteLine($"Partner Email: {myPartner.PartnerContactEmail}");
        Console.WriteLine($"Partner Geography: {myPartner.PartnerGeography}");
        Console.WriteLine("Specializations:");
        foreach (var specialization in myPartner.PartnerSpecializations)
        {
            Console.WriteLine($"- {specialization}");
        }
        Console.WriteLine();

        // Create and display information about PartnerAccountManager
        PartnerAccountManager accountManager = new PartnerAccountManager(
            98765,
            "manager@innovativesolutions.com",
            "director@innovativesolutions.com",
            "Account Management"
        );

        Console.WriteLine("********** Partner Account Manager Details **********");
        Console.WriteLine($"Employee ID: {accountManager.EmployeeID}");
        Console.WriteLine($"Email: {accountManager.Email}");
        Console.WriteLine($"Manager Email: {accountManager.ManagerEmail}");
        Console.WriteLine($"Specialization: {accountManager.Specialization}");
        Console.WriteLine();

        // Create and display information about ManagedPartner
        ManagedPartner managedPartner = new ManagedPartner(
            2024,
            "Innovative Solutions",
            "contact@innovativesolutions.com",
            "San Francisco",
            new[] { "Cloud Computing", "Data Analytics" },
            DateTime.Now,
            new PartnerAccountManager(98765, "manager@innovativesolutions.com", "director@innovativesolutions.com", "Account Management")
        );

        Console.WriteLine("********** Managed Partner Details **********");
        Console.WriteLine($"Partner ID: {managedPartner.PartnerID}");
        Console.WriteLine($"Partner Name: {managedPartner.PartnerName}");
        Console.WriteLine($"Partner Email: {managedPartner.PartnerContactEmail}");
        Console.WriteLine($"Partner Geography: {managedPartner.PartnerGeography}");
        Console.WriteLine($"Managed From: {managedPartner.ManagedFrom}");
        Console.WriteLine("Specializations:");
        foreach (var specialization in managedPartner.PartnerSpecializations)
        {
            Console.WriteLine($"- {specialization}");
        }
        Console.WriteLine();

        // Display and update Partner Account Manager for ManagedPartner
        Console.WriteLine("********** Managed Partner Account Manager Details **********");
        Console.WriteLine($"Employee ID: {managedPartner.PartnerAccountManager.EmployeeID}");
        Console.WriteLine($"Email: {managedPartner.PartnerAccountManager.Email}");
        Console.WriteLine($"Manager Email: {managedPartner.PartnerAccountManager.ManagerEmail}");
        Console.WriteLine($"Specialization: {managedPartner.PartnerAccountManager.Specialization}");

        // Update PartnerAccountManager
        managedPartner.UpdatePartnerAccountManager(new PartnerAccountManager(
            54321, 
            "newmanager@innovativesolutions.com", 
            "newdirector@innovativesolutions.com", 
            "New Management"
        ));

        // Display updated Partner Account Manager information
        Console.WriteLine();
        Console.WriteLine("********** Updated Managed Partner Account Manager Details **********");
        Console.WriteLine($"Employee ID: {managedPartner.PartnerAccountManager.EmployeeID}");
        Console.WriteLine($"Email: {managedPartner.PartnerAccountManager.Email}");
        Console.WriteLine($"Manager Email: {managedPartner.PartnerAccountManager.ManagerEmail}");
        Console.WriteLine($"Specialization: {managedPartner.PartnerAccountManager.Specialization}");
    }
}
