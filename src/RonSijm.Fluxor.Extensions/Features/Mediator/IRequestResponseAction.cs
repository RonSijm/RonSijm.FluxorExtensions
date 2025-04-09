namespace RonSijm.Syringe;

public interface IRequestResponseAction<out TRequest, out TResponse> : IRequestAction<TRequest>, IResponseAction<TResponse>, IRequestResponseExceptionObject
{
    object IRequestResponseObject.BaseRequest => Request;
    object IRequestResponseObject.BaseResponse => Response;
}