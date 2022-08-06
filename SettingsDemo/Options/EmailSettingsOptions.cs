namespace SettingsDemo.Options;

public class EmailSettingsOptions
{
    public bool EnableSending { get; set; }
    public int TimeoutInSeconds { get; set; }
    public string[] SmtpServers { get; set; }
    public EmailAdminOptions EmailAdmin { get; set; }
}

public class EmailAdminOptions
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}