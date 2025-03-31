namespace RonSijm.Syringe;

public abstract class CompleteEffect<TState, TAction> : EffectWithResult<TAction, TState> where TAction : ICompleteAction<TState>
{
    protected override Task<TState> HandleAsync(TAction action)
    {
        return Task.FromResult(action.Response);
    }
}