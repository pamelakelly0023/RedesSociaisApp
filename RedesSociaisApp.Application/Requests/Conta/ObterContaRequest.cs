using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RedesSociaisApp.Application.Models;

namespace RedesSociaisApp.Application.Requests
{
    public record ObterContaRequest(int Id) : IRequest<ResultViewModel<ContaViewModel>>;
}