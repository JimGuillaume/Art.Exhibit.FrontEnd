using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Art.Exhibit.FrontEnd.Application.Interfaces.Services;
using Art.Exhibit.FrontEnd.Application.Services;

namespace Art.Exhibit.FrontEnd.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IShipmentService, ShipmentService>();
        services.AddScoped<IItemReviewService, ItemReviewService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISubmissionService, SubmissionService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<ISaleService, SaleService>();

        return services;
    }
}