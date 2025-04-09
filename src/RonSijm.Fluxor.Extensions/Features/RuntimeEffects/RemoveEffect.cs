namespace RonSijm.Syringe;

public class RemoveEffect(IEffect effect)
{
    public IEffect Effect { get; } = effect;
}