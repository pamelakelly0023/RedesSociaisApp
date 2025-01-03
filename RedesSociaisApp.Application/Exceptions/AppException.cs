using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedesSociaisApp.Application.Exceptions;

public class AppException(IList<string> errors) : Exception(string.Join(", ", errors))
{
    public IList<string> Errors { get; set; } = errors;
}