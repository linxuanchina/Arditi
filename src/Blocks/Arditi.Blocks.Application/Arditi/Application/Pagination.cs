using FluentValidation;

namespace Arditi.Application;

public sealed record Pagination(int Index, int Size, int? Total = null);

public sealed class PaginationValidator : AbstractValidator<Pagination>
{
    public PaginationValidator()
    {
        RuleFor(pagination => pagination.Index)
            .GreaterThan(0);
        RuleFor(pagination => pagination.Size)
            .GreaterThanOrEqualTo(10)
            .LessThanOrEqualTo(100)
            .Must(size => size % 10 == 0);
    }
}
