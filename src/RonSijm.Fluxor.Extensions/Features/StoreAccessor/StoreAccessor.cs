using RonSijm.Syringe.Properties;

namespace RonSijm.Syringe;
public class StoreAccessor
{
    private readonly Lazy<List<IEffect>> _effects;
    private readonly Lazy<object> _syncRoot;

    public StoreAccessor()
    {
        _effects = new Lazy<List<IEffect>>(() => Store.GetPrivateField<List<IEffect>>("Effects"));
        _syncRoot = new Lazy<object>(() => Store.GetPrivateField<object>("SyncRoot"));
    }

    [Inject]
    public Store Store { get; set; }

    public void AddEffect(IEffect effect)
    {
        Store.AddEffect(effect);
    }

    public void RemoveEffect(IEffect effect)
    {
        if (effect is null)
        {
            throw new ArgumentNullException(nameof(effect));
        }

        lock (_syncRoot)
        {
            _effects.Value.Remove(effect);
        }
    }
}