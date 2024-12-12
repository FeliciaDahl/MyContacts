
using Business.Factories;
using Business.Interfaces;

namespace Presentation.ConsoleApp.Dialogs;

public class MenuDialog(IContactService contactService) : IMenuDialog
{
    private readonly IContactService _contactService = contactService;

    public void Run()
    {

        var isRunning = true;
        do
        {
            Console.Clear();
            Console.WriteLine("-----MAIN MENU-----");
            Console.WriteLine("1. Add contact");
            Console.WriteLine("2. View contacts");
            Console.WriteLine("3. Remove contact");
            Console.WriteLine("q. Quit application");
            Console.WriteLine("-------------------");

            Console.Write("Please choose one option from the menu: ");
            var option = Console.ReadLine()!;

            switch (option.ToLower())
            {
                case "1":
                    AddContact();
                    break;

                case "2":
                    ShowContactList();
                    break;

                case "3":
                    Console.Clear();
                    break;

                case "q":
                    QuitOption();
                    break;

                default:
                    Console.Clear();
                    OutputDialog("Please enter a valid key");
                    Console.ReadKey();
                    break;
            }

        } while (isRunning);
    }
    public void AddContact()
    {
        var contact = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine("Enter first name : ");
        contact.FirstName = Console.ReadLine()!;

        Console.WriteLine("Enter last name : ");
        contact.LastName = Console.ReadLine()!;

        Console.WriteLine("Enter email : ");
        contact.Email = Console.ReadLine()!;

        Console.WriteLine("Enter phonenumber : ");
        contact.Phone = Console.ReadLine()!;

        Console.WriteLine("Enter andress : ");
        contact.Address = Console.ReadLine()!;

        Console.WriteLine("Enter postalcode : ");
        contact.PostalCode = Console.ReadLine()!;

        Console.WriteLine("Enter city : ");
        contact.City = Console.ReadLine()!;

        bool result = _contactService.AddContact(contact);

        if (result)
            OutputDialog("User was created");
        else
            OutputDialog("We could not create a user, please try again");

        Console.ReadKey();
    }

    public void ShowContactList()
    {
        var contacts = _contactService.GetAll();

        Console.Clear();
        if (!contacts.Any())
        {
            OutputDialog("No users were found in the list");
            return;
        }
        foreach (var user in contacts)
        {
            Console.WriteLine($"{"ID:",-15}{user.Id}");
            Console.WriteLine($"{"Name:",-15}{user.FullName}");
            Console.WriteLine($"{"Email:",-15}{user.Email}");
            Console.WriteLine($"{"Phone:",-15}{user.Phone}");
            Console.WriteLine($"{"Adress:",-15}{user.Address}");
            Console.WriteLine($"{"PostalCode:",-15}{user.PostalCode}");
            Console.WriteLine($"{"City:",-15}{user.City}");
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public void QuitOption()
    {
        Console.Clear();
        Console.WriteLine("Do you want to exit? y/n?");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
    }


    public void OutputDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();

    }
}
