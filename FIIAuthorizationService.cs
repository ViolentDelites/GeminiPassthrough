using ISB.FacilitiesIntegration.Application.Extensions.Attributes;
using ISB.FacilitiesIntegration.Persistence.DTOs.FI;
namespace ISB.FacilitiesIntegration.Application.Services.Security;

public interface IAuthorizationService
{
    Task<bool> CheckNotAuthorizedForModule(Type t, UserDTO CurrentUser, string module = "");
    Task<bool> CheckNotAuthorizedForView(Type t, UserDTO CurrentUser, string module = "", string view = "");
    Task<List<string>> CheckTypeCodeAuthorization(UserDTO CurrentUser);
    Task<bool> CheckNotAuthorizedForEdit(UserDTO CurrentUser, string module = "");
    Task<bool> CheckNotAuthorizedForWorkflowEdit(UserDTO CurrentUser, string view, string workflowStatus);
    Task<bool> CheckNotAuthorizedForDelete(UserDTO CurrentUser, string module = "", string subModule = "");
    void Dispose();
}
public class AuthorizationService : IAuthorizationService, IDisposable
{
    public async Task<bool> CheckNotAuthorizedForModule(Type t, UserDTO CurrentUser, string module = "")
    {
        if (CurrentUser != null)
        {
            if (CurrentUser.Roles.Any(x => x.Role.Contains("Super")))
                return false;
            if (CurrentUser.Roles.Any(x => x.Role.Contains("NoAccess")))
                return true;
            RolesAttribute authorization = Attribute.GetCustomAttribute(t, typeof(RolesAttribute)) as RolesAttribute;
            if (authorization != null)
            {
                List<string> authorizedRoles = authorization.Roles.ToList();
                return !CurrentUser.Roles.Any(x => authorizedRoles.Any(y => x.Role.Contains(y)) && x.Role.Contains(module));
            }
            return true;
        }
        else
            return true;

    }
    public async Task<bool> CheckNotAuthorizedForView(Type t, UserDTO CurrentUser, string module = "", string section = "")
    {
        if (CurrentUser != null)
        {

            if (CurrentUser.Roles.Any(x => x.Role.Contains("Super")))
                return false;
            if (CurrentUser.Roles.Any(x => x.Role.Contains("NoAccess")))
                return true;
            RolesAttribute authorization = Attribute.GetCustomAttribute(t, typeof(RolesAttribute)) as RolesAttribute;
            if (authorization != null)
            {
                List<string> authorizedRoles = authorization.Roles.ToList();
                if (section == "MCICOM")
                    return !CurrentUser.Roles.Any(x => authorizedRoles.Any(y => x.Role.Contains(y)) && x.Role.Contains(module) && x.Role.Contains("HQ"));
                if (section == "Regional")
                    return !CurrentUser.Roles.Any(x => authorizedRoles.Any(y => x.Role.Contains(y)) && x.Role.Contains(module) && x.IsRegion);
            }
            return true;
        }
        else
            return true;
    }
    public async Task<List<string>> CheckTypeCodeAuthorization(UserDTO CurrentUser)
    {
        List<string> authorizedTypes = new List<string>();
        List<string> envStrings = new List<string> { "ENV1", "ENV2", "ENV3", "ME1", "ME2", "ME3" };
        List<string> regStrings = new List<string> { "DEMO", "M", "R", "STUD" };
        List<string?> roleAreas = CurrentUser.Roles.Select(x => x.TypeCode).Distinct().ToList();
        if(roleAreas != null)
        {
            if (roleAreas.Contains("FRCS"))
                authorizedTypes.Add("FRCS");
            if (roleAreas.Contains("ENV"))
                authorizedTypes.AddRange(envStrings);
            if (roleAreas.Contains("REG"))
                authorizedTypes.AddRange(regStrings);

        }
        return authorizedTypes;
    }
    public async Task<bool> CheckNotAuthorizedForEdit(UserDTO CurrentUser, string module = "")
    {
        if (CurrentUser != null)
        {
            if (CurrentUser.Roles.Any(x => x.Role.Contains("Super")))
                return false;
            if (CurrentUser.Roles.Any(x => x.Role.Contains("NoAccess")))
                return true;
            return CurrentUser.Roles.Any(x => x.Role.Contains("ReadOnly") && x.Role.Contains(module));
        }
        else
            return true;
    }
    public async Task<bool> CheckNotAuthorizedForWorkflowEdit(UserDTO CurrentUser, string section, string workflowStatus)
    {
        if (CurrentUser.Roles.Any(x => x.Role.Contains("Super")))
            return false;
        if (CurrentUser.Roles.Any(x => x.Role.Contains("NoAccess")))
            return true;
        if (workflowStatus is null)
            return false;
        else if (workflowStatus.Contains("APPROVE"))
            return true;
        if (section == "Installation")
            if ((workflowStatus.Contains("RC") || workflowStatus.Contains("HQ"))
                && !workflowStatus.Contains("RETURN"))
                return true;
            else return false;
        else if (section == "Regional")
            if (workflowStatus.Contains("HQ") && !workflowStatus.Contains("RETURN"))
                return true;
            else
                return false;
        else if (section == "Mcicom")
            //if (workflowStatus.Contains("HQ"))
            //    return false;
            //else
                return false;
        else return true;
    }
    public async Task<bool> CheckNotAuthorizedForDelete(UserDTO CurrentUser, string module = "", string subModule = "")
    {
        switch (subModule)
        {
            case "NPV":
                if (CurrentUser.Roles.Any(x => x.Role.Contains("Super")))
                    return false;
                else
                    return true;
                break;
            default:
                return false;
                break;
        }
        //if (CurrentUser.Roles.Any(x => x.Role.Contains("Super")))
        //    return false;
        //if (CurrentUser.Roles.Any(x => x.Role.Contains("NoAccess")))
        //    return true;
        //return CurrentUser.Roles.Any(x => x.Role.Contains("ReadOnly") && x.Role.Contains(module));
    }
    public void Dispose()
    {
    }
}