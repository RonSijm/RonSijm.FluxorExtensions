using RonSijm.Syringe.Properties;

namespace RonSijm.Syringe;

public class RemoveEffectEffect : Effect<RemoveEffect>
{
    [Inject]
    public StoreAccessor Store { get; set; }

    public override Task HandleAsync(RemoveEffect action, IDispatcher dispatcher)
    {
        Store.RemoveEffect(action.Effect);

        return Task.CompletedTask;
    }
}