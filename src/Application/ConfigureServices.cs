using System.Reflection;
using MRA.Jobs.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MRA.Jobs.Application.Contracts.VacancyCategories.Queries;

namespace MRA.Jobs.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(typeof(ConfigureServices).Assembly);
        services.AddMediatR(typeof(Features.VacancyCategories.Queries.GetVacancyCategoriesQueryHandler));
        services.AddMediatR(typeof(Features.VacancyCategories.Queries.GetByIdVacancyCategoriesQueryHandler));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

        return services;
    }
}
