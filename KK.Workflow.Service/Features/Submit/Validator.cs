using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DD.Tata.Buku.Shared.Fault;
using DD.Tata.Buku.Shared.Logs;
using DD.TataBuku.Shared.Fault;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace KK.Workflow.Service.Features.Submit
{
    public class Validator : AbstractValidator<Request>, IRequestValidator<Request>
    {
        private readonly IApiLogger _apiLogger;

        public Validator(IApiLogger apiLogger)
        {
            _apiLogger = apiLogger;
            RuleFor(x => x.ModuleName)
                .NotEmpty()
                .WithMessage("ReferenceKey can't be empty!");
            RuleFor(x => x.RequestDate)
                .LessThan(DateTime.UtcNow.Date)
                .WithMessage("ReferenceKey can't be empty!");
            RuleFor(x => x.UserFullName)
                .NotEmpty()
                .WithMessage("UserFullName can't be empty!")
                .MaximumLength(64)
                .WithMessage("UserFullName max length is 64");
            RuleFor(x => x.DocumentNumber)
                .NotEmpty()
                .WithMessage("DocumentNumber can't be empty!")
                .MaximumLength(64)
                .WithMessage("DocumentNumber max length is 64");
            RuleFor(x => x.ActionName)
                .NotEmpty()
                .WithMessage("ActionName can't be empty!");
        }
        public new async Task<ValidationResult> Validate(Request request)
        {
            var result = await ValidateAsync(request);
            if (result.IsValid) return ValidationResult.Ok();
            _apiLogger.Log(
                $"Following fields are mandatory: {string.Join(", ", result.Errors.Select(x => x.ErrorMessage))}",
                LogLevel.Warning, 0, result.Errors);
            throw new ApiException(HttpStatusCode.BadRequest,
                $"The request is invalid. {string.Join(",", result.Errors.Select(x => x.ErrorMessage))}", 2);
        }

        public int Order { get; } = 1;
    }
}
