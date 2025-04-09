namespace RonSijm.Syringe;

public abstract class CompleteEffect<TState, TAction> : EffectWithResult<TAction, TState> where TAction : IResponseAction<TState>
{
    protected override Task<TState> HandleAsync(TAction action)
    {
        return Task.FromResult(action.Response);
    }
}