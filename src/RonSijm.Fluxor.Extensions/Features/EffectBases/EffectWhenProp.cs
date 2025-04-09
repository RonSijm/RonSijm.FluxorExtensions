namespace RonSijm.Syringe;

[UsedImplicitly(ImplicitUseTargetFlags.WithInheritors)]
public abstract class EffectWhenProp<TTriggerAction> : EffectWhen<TTriggerAction>
{
    protected abstract Func<TTriggerAction, bool> When { get; }

    protected override bool ShouldReactToAction(TTriggerAction action)
    {
        return When(action);
    }
}