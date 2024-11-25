using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedesSociaisApp.Application.Exceptions;

public class AppException : Exception
{
    public AppException(string mensagem)
        : base(mensagem)
    {
    }

    public AppException(string mensagem, Exception innerException)
        : base(mensagem, innerException)
    {
    }
}