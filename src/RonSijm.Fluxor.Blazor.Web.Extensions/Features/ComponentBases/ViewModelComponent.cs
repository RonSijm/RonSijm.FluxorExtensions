using RonSijm.Syringe.Models;

namespace RonSijm.Syringe;

public abstract class ViewModelComponent<TViewModel> : FluxorDispatcherComponent
{
    private readonly Lazy<bool> _dispatchFirstTimeOnAfterRender;
    private readonly Lazy<bool> _dispatchOnAfterRender;
    private readonly Lazy<bool> _dispatchOnInitialized;

    protected ViewModelComponent()
    {
        _dispatchOnAfterRender = new Lazy<bool>(() => ViewModel is IDispatchOnAfterRender);
        _dispatchFirstTimeOnAfterRender = new Lazy<bool>(() => ViewModel is IDispatchFirstTimeOnAfterRender);
        _dispatchOnInitialized = new Lazy<bool>(() => ViewModel is IDispatchOnInitialized);
    }

    [Inject] public IState<TViewModel> ViewModelState { set; get; }

    protected TViewModel ViewModel => ViewModelState.Value;

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (_dispatchFirstTimeOnAfterRender.Value)
            {
                Dispatcher.Dispatch(new PageEvent(PageEventType.FirstTimeOnAfterRender, GetType()));
            }
        }
        else
        {
            if (_dispatchOnAfterRender.Value)
            {
                Dispatcher.Dispatch(new PageEvent(PageEventType.OnAfterRender, GetType()));
            }
        }

        return base.OnAfterRenderAsync(firstRender);
    }

    protected override Task OnInitializedAsync()
    {
        if (_dispatchOnInitialized.Value)
        {
            Dispatcher.Dispatch(new PageEvent(PageEventType.OnInitialized, GetType()));
        }

        return base.OnInitializedAsync();
    }
}