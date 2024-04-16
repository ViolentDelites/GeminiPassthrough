@using Security=ISB.FacilitiesIntegration.Application.Services.Security;
@using IDX=ISB.FacilitiesIntegration.Web.Pages.Modules.FSRM.Index;
@implements IDisposable
@inherits OwningComponentBase
<AppState @ref="AppState">
    <Application>
        <CascadingValue TValue="@(Security.IAuthorizationService)" Value="@(AuthService)">
            <Router AppAssembly="@typeof(App).Assembly" OnNavigateAsync="@(NavigateAsync)">
                <Navigating>
                    <TelerikLoaderContainer LoaderPosition="@(LoaderPosition.Top)" LoaderType="@LoaderType.InfiniteSpinner" Size="@(ThemeConstants.Loader.Size.Large)" ThemeColor="primary" Visible="@(true)">
                    </TelerikLoaderContainer>
                </Navigating>
                <Found Context="routeData">
                    <RouteView DefaultLayout="@typeof(MasterLayout)" RouteData="@(routeData)" />
                </Found>
                <NotFound>
                    <LayoutView Layout="@typeof(MasterLayout)">
                        <PageTitle>Not Found</PageTitle>
                    </LayoutView>
                </NotFound>
            </Router>
        </CascadingValue>
    </Application>
</AppState>

@code {
    [Inject]
    Security.IAuthorizationService AuthService { get; set; }
    [Inject]
    NavigationManager NavigationManager { get; set; }
    [Inject]
    Security.SecurityService SecService { get; set; }
    [Inject]
    protected ILogger<App> Logger { get; set; }

    private AppState AppState { get; set; }

    [Parameter]
    public string Cookie { get; set; }

    internal string EDIPI { get; private set; }

    protected override async Task OnInitializedAsync()
    {
        AppState = new AppState();
        EDIPI = String.Empty;
        try
        {
            EDIPI = SecService.ParseEDIPI(Cookie);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
        }
        AppState.OnChange += StateHasChanged;
        await base.OnInitializedAsync();
    }

    private async Task NavigateAsync(NavigationContext args)
    {
        bool shouldNavigate = false;
        if (!args.Path.Contains("Unauthorized"))
        {
            if (args.Path.Contains("FSRM") || args.Path.Contains("IRF") || args.Path.Contains("ADMIN"))
            {
                if (AppState.CurrentUser != null)
                {
                    if (args.Path.Contains("FSRM"))
                        shouldNavigate = !await AuthService.CheckNotAuthorizedForModule(typeof(IDX), AppState.CurrentUser, "FSRM");
                    else if (args.Path.Contains("ADMIN"))
                        shouldNavigate = !await AuthService.CheckNotAuthorizedForModule(typeof(Pages.Modules.Admin.Index), AppState.CurrentUser, "ADMIN");
                    if (!shouldNavigate)
                        NavigationManager.NavigateTo("/Unauthorized");
                }
                else
                    NavigationManager.NavigateTo("/Unauthorized");
            }
        }
    }
    private void Dispose()
    {
        AuthService.Dispose();
        SecService.Dispose();
        AppState.Dispose();
    }
}