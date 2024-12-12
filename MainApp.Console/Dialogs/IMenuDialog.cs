namespace Presentation.ConsoleApp.Dialogs
{
    public interface IMenuDialog
    {
        void AddContact();
        void OutputDialog(string message);
        void QuitOption();
        void Run();
        void ShowContactList();
    }
}