using CGV.Contracts.Genre.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGV.Contracts.Genre.Requests
{
    public class GetAllGenresRequest : IRequest<GetAllGenresResponse>
    {
    }
}
