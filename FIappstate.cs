@inject ProtectedSessionStorage Session
@inject ProtectedLocalStorage Local
@inject IJSRuntime JsInterop
@implements IDisposable
<CascadingValue Value="@(this)">
    <Notifications>
        <TelerikLoaderContainer LoaderPosition="@(LoaderPosition.Top)" LoaderType="@LoaderType.InfiniteSpinner" Size="@(ThemeConstants.Loader.Size.Large)" ThemeColor="primary" Visible="@(Loading)">
        </TelerikLoaderContainer>
        @Application
    </Notifications>
</CascadingValue>


@code {
    [Inject]
    protected AppServices.Security.IUserService UserService { get; set; }
    [Inject]
    protected FI_Repositories.IUserRepository UserRepo { get; set; }
    [Inject]
    protected FI_Repositories.ILookupCodeRepository CodeRepo { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    protected ILogger<AppState> Logger { get; set; }
    [Parameter]
    public RenderFragment? Application { get; set; }
    public NotificationUtility Notifier { get; set; }
    public event Action OnChange;
    internal FI_DTOs.UserDTO? CurrentUser { get; private set; }
    internal string pid { get; private set; } = "";
    internal int ActiveSubModule { get; set; }
    internal List<string> AllowedSpecialPrograms { get; set; }
    private bool Loading { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        var app = Application.Target as App;
        string EDIPI = String.Empty;
        string CACstring = String.Empty;
        if (app != null)
        {
            EDIPI = app.EDIPI;
            CACstring = app.Cookie;
            await SetSessionAsync("EDIPI", EDIPI);
            await SetSessionAsync("CACstring", CACstring != null ? CACstring : "");
        }
        string viewMode = await GetLocalAsync<string>("viewMode");
        if (viewMode == null)
        {
            viewMode = "dark";
            await SetLocalAsync<string>("viewMode", "dark");
        }
        this.OnChange += StateHasChanged;
        await JsInterop.InvokeVoidAsync("themeChanger.changeCss", viewMode);
        await base.OnInitializedAsync();
    }


    public async Task ChangeLoading()
    {
        Loading = !await IsLoading();
        NotifyStateChanged();
    }
    public async ValueTask<bool> IsLoading()
    {
        return Loading;
    }
    #region SessionStorage
    public async ValueTask SetSessionAsync<T>(string key, T value)
    {
        try
        {
            await Session.SetAsync(key, value);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
        }
    }
    public async ValueTask<T> GetSessionAsync<T>(string key)
    {
        try
        {
            var result = await Session.GetAsync<T>(key);
            return result.Value;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return default(T);
        }
    }
    #endregion

    #region LocalStorage
    public async ValueTask SetLocalAsync<T>(string key, T value)
    {
        try
        {
            await Local.SetAsync(key, value);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
        }
    }
    public async ValueTask<T> GetLocalAsync<T>(string key)
    {
        try
        {
            var result = await Local.GetAsync<T>(key);
            return result.Value;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return default(T);
        }
    }

    #endregion

    #region User
    protected async Task SetCurrentUser(string pid, string cacString)
    {
        var userTask = await UserRepo.GetUserByEDIPI(pid);
        if (userTask.Id is 0)
            userTask = await UserService.AddNewUserByCacString(cacString);
        if (userTask.Roles.Count is 0)
            userTask = await UserService.AddNewUserToDefaultRole(userTask);
        CurrentUser = userTask;
        var sessionTask = SetSessionAsync("currentUser", CurrentUser);
        await sessionTask;
    }
    public async Task<FI_DTOs.UserDTO> GetCurrentUser(bool isDebug = false)
    {
        string cacString = "";
        if (!isDebug && pid != "")
        {
            var sessionTask = await GetSessionAsync<FI_DTOs.UserDTO>("currentUser");
            if (sessionTask != null)
            {
                CurrentUser = sessionTask as FI_DTOs.UserDTO;
                return CurrentUser;
            }
        }
        if (isDebug)
        {
            cacString = await GetSessionAsync<string>("CACstring");
            string dPid = await GetSessionAsync<string>("debugEDIPI");
            await SetCurrentUser(dPid, cacString);
        }
        else
        {
            pid = await GetSessionAsync<string>("EDIPI");
            cacString = await GetSessionAsync<string>("CACstring");
            if (!isDebug && CurrentUser != null || CurrentUser != null && CurrentUser.EDIPI == pid)
                return CurrentUser;
            else
                await SetCurrentUser(pid, cacString);

        }
        return CurrentUser;
    }
    public async Task ClearCurrentUser()
    {
        CurrentUser = null;
        pid = "";
        await Session.DeleteAsync("EDIPI");
        await Session.DeleteAsync("debugEDIPI");
        await Session.DeleteAsync("currentUser");
    }

    #endregion

    #region SubModule
    public async Task SetActiveSubModule(string subModule)
    {
        try
        {
            var task = await CodeRepo.GetByCodeAndName("SubModule", subModule);
            ActiveSubModule = task.Id;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
        }
    }
    public async Task<string> GetActiveSubModule()
    {
        string aSM = "";
        try
        {
            if (ActiveSubModule != 0)
            {
                var task = await CodeRepo.GetByIdAsync(new FI_DTOs.LookupCodeDTO(), ActiveSubModule) as FI_DTOs.LookupCodeDTO;
                aSM = task.Name;
            }
            else
            {
                aSM = "NPV";
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
        }
        return aSM;
    }

    #endregion
    private void NotifyStateChanged() => OnChange?.Invoke();
    public void Dispose()
    {
        UserRepo.Dispose();
        CodeRepo.Dispose();
        this.OnChange -= StateHasChanged;
    }

}