namespace RonSijm.Syringe;

public interface IRequestAction<out TRequest> : IAction
{
    public TRequest Request { get; }
}