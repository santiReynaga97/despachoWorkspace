﻿namespace ContpaqiNube.Despachos.Management.Application.Common.Models.Results;

public class ErrorResult : Result
{
    public ErrorResult(string message) : base(false, message)
    {
    }

    public ErrorResult(bool success) : base(false)
    {
    }
}