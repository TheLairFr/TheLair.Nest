using Blazored.LocalStorage;
using TheLair.BlazorApp.StateManagement;

namespace TheLair.Nest.Web.Client.Logic.StateManager;

public class NestStateManager : SessionStateManager<NestState, NestSessionState>
{
    public NestStateManager(ISyncLocalStorageService localStorage) : base(localStorage)
    {
    }

    protected override NestState BuildState()
    {
        return (new NestState
        {

        });
    }

    protected override NestSessionState SessionStateBuilder()
    {
        return (new NestSessionState
        {

        });
    }
}