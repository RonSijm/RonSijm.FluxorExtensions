﻿namespace RonSijm.Syringe;

[FeatureState]
public abstract record CompleteAction<TRequest, TResponse>(TRequest Request, TResponse Response) : IRequestResponseAction<TRequest, TResponse>
{
    public Exception Exception { get; set; }
}