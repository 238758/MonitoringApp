using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorMonitoring.Data;

public class UserLogin : INotifyPropertyChanged
{
    private string? _loggedInUserName;
    private readonly IConfiguration _config;

    public string? LoggedInUserName
    {
        get { return _loggedInUserName; }
        set
        {
            if (value != _loggedInUserName)
            {
                _loggedInUserName = value;
                NotifyPropertyChanged();
            }
        }
    }

    public (string email, string pw) ValidUser { get; set; } 

    public UserLogin(IConfiguration config)
    {
        _config = config;

        ValidUser = (_config["Users:email"], _config["Users:password"]);
    }

    #region PropertyChanged

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    #endregion
}
