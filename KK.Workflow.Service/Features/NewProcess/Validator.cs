using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DD.Tata.Buku.Shared.Fault;
using DD.TataBuku.Shared.Fault;

namespace KK.Workflow.Service.Features.NewProcess
{
    public class Validator : IRequestValidator<Request>
    {
        public Task<ValidationResult> Validate(Request request)
        {
            throw new NotImplementedException();
        }

        public int Order { get; } = 1;
    }
}
