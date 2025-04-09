namespace RonSijm.Syringe;

public class AddEffect(IEffect effect)
{
    public IEffect Effect { get; } = effect;
}