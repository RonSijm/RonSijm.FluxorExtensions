namespace RonSijm.Syringe;

public interface IResponseAction<out TResponse> : IAction, IExceptionObject
{
    public TResponse Response { get; }
}