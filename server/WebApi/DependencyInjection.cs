using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace WebApi {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure (
            this IServiceCollection services, IConfiguration configuration
        ) {
            string env = configuration.GetSection("Environment").Value!;
            string ConnectionString = configuration.GetSection($"ConnectionStrings:ConnectionString_{env}").Value!;

            AppContext.SetSwitch ( "Npgsql.EnableLegacyTimestampBehavior", true );
            services.AddDbContext<ApplicationDbContext> ( options => {
                options.UseNpgsql ( ConnectionString );
            } );

            services.AddScoped<IUnitOfWork, UnitOfWork> ();
            services.AddScoped( typeof( IRepository<> ), typeof ( Repository<> ) );
            services.AddScoped<IDataService, DataService> ();

            var mapperConfig = new AutoMapper.MapperConfiguration(o => o.AddProfile(new AutoMapperProfile() ));
            var mapper = mapperConfig.CreateMapper ();
            services.AddSingleton ( mapper );

            services.AddControllers ().AddJsonOptions ( j => j.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles );

            return services;
        }
    }
}
