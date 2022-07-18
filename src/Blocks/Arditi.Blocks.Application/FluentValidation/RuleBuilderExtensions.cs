using Arditi.Application;

namespace FluentValidation;

public static class RuleBuilderExtensions
{
    public static IRuleBuilder<T, Pagination> SetPaginationValidator<T>(this IRuleBuilder<T, Pagination> builder) =>
        builder.SetValidator(new PaginationValidator());
}
