using ISB.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
namespace ISB.FacilitiesIntegration.Application.Services.Security;

public class SecurityService: IDisposable
{
    [Inject]
    protected ILogger<SecurityService> Logger { get; set; }

    public string ParseEDIPI(string subject)
    {
        string edipi = string.Empty;

        if (!String.IsNullOrWhiteSpace(subject))
        {
            //Extract common name from subject
            try
            {
                edipi = CACParser.GetEDIPI(subject);
                edipi = EncryptEDIPI(edipi);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                edipi = ParseEDIPIRegex(subject);
            }
        }

        return edipi;
    }

    public string EncryptEDIPI(string edipi)
    {
        return Encryption.EncryptString(edipi);
    }
    private string ParseEDIPIRegex(string subject)
    {
        string edipi = string.Empty;

        if (!string.IsNullOrWhiteSpace(subject))
        {
            try
            {
                Match match = Regex.Match(subject, "CN=([^,]+)");
                if (match.Success)
                {
                    string[] values = match.Value.Split('.');
                    edipi = values[values.Length - 1];
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
        }
        edipi = EncryptEDIPI(edipi);
        return edipi;
    }
    public void Dispose()
    {
    }
}
