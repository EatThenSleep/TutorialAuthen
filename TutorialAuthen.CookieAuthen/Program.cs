
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace TutorialAuthen.CookieAuthen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add authen
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                //options.DefaultAuthenticateScheme = "second-cookies";
                //options.DefaultChallengeScheme = "second-cookies";
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme , options =>
                {
                    options.Cookie = new CookieBuilder()
                    {
                        Name = "CongVienBanhTrang"
                    };
                    options.LoginPath = "/api/authen/unauthorized";
                    options.LogoutPath = "/api/authen/logout";
                    options.AccessDeniedPath = "/api/authen/forbidden";

                    //options.Events.OnValidatePrincipal = (context) =>
                    //{
                    //    return Task.CompletedTask;
                    //};
                })
                .AddCookie("second-cookies" , options =>
                {
                    options.LoginPath = "/api/authen/unauthorized-v2";

                    //options.Events.OnValidatePrincipal = (context) =>
                    //{
                    //    return Task.CompletedTask;
                    //};
                });

                // xac thuc authen 2 lop
                //builder.Services.AddAuthorization(options =>
                //{
                //    var defautlAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                //        CookieAuthenticationDefaults.AuthenticationScheme,
                //        "second-cookies"
                //    );

                //    defautlAuthorizationPolicyBuilder = defautlAuthorizationPolicyBuilder
                //                                            .RequireAuthenticatedUser();
                //    options.DefaultPolicy = defautlAuthorizationPolicyBuilder.Build();
                //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
