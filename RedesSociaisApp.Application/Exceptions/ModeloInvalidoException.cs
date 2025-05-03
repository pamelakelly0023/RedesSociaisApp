using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedesSociaisApp.Application.Exceptions;

public sealed class ModeloInvalidoException : Exception
{
    public ModeloInvalidoException(Dictionary<string, IEnumerable<string>> erros)
        : base("Dados inválidos")
        => Erros = erros;

    public Dictionary<string, IEnumerable<string>> Erros { get; }
}
