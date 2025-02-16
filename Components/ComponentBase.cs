using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace NinjaDesk.Components;

public class ComponentBase : Microsoft.AspNetCore.Components.ComponentBase, IAsyncDisposable
{
    [Inject]
    protected IJSRuntime JS { get; set; } = default!;

    [Parameter]
    public string Style { get; set; } = string.Empty;

    protected IJSObjectReference? JSModule { get; private set; }

    protected virtual string? JSFile { get; }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (!string.IsNullOrEmpty(JSFile) && firstRender)
        {
            JSModule = await JS.InvokeAsync<IJSObjectReference>("import", JSFile);
        }
    }

    public ValueTask DisposeAsync()
        => JSModule?.DisposeAsync() ?? ValueTask.CompletedTask;
}

