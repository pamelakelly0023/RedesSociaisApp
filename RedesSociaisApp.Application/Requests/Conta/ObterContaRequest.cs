using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RedesSociaisApp.Application.Models;

namespace RedesSociaisApp.Application.Requests
{
    public class ObterContaRequest : IRequest<ResultViewModel<ContaViewModel>>
    {
        public int ContaId { get; set; }
    }
}