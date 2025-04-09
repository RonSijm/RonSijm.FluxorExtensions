using RonSijm.Syringe.Models;

namespace RonSijm.Syringe;

public abstract class PageEffect<TPage>(PageEventType eventType) : IEffect
{
    protected abstract Task HandleAsync(PageEvent action, IDispatcher dispatcher);

    Task IEffect.HandleAsync(object action, IDispatcher dispatcher)
    {
        return HandleAsync((PageEvent)action, dispatcher);
    }

    public bool ShouldReactToAction(object action)
    {
        if (action is not PageEvent pageEvent)
        {
            return false;
        }

        if (pageEvent.Source != typeof(TPage))
        {
            return false;
        }

        return pageEvent.Type == eventType;
    }
}