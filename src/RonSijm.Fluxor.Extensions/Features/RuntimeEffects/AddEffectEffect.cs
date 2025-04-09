using RonSijm.Syringe.Properties;

namespace RonSijm.Syringe;

public class AddEffectEffect : Effect<AddEffect>
{
    [Inject]
    public StoreAccessor Store { get; set; }

    public override Task HandleAsync(AddEffect action, IDispatcher dispatcher)
    {
        Store.AddEffect(action.Effect);

        return Task.CompletedTask;
    }
}