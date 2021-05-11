using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ParkBee.Assessment.API.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace ParkBee.Assessment.API
{
    public class Startup
    {
        #region Private Fields
        private IConfiguration _configuration;
        #endregion

        #region Constructor
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        } 
        #endregion

        #region Public Methods
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = _configuration["Jwt:Issuer"],
                        ValidAudience = _configuration["Jwt:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]))
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ParkBee.Assessment"
                });
            });

            services.Configure<JwtSettings>(_configuration.GetSection("Jwt"));
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("parkbee"));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AddTestData(context);

            app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ParkBee.Assessment API V1"));
        } 
        #endregion

        #region Private Methods
        private static void AddTestData(ApplicationDbContext context)
        {
            //This is dummy data that I am inserting into the In Memery Database.
            //IP Addresses are local ip's on PJ's home network.
            context.Garages.Add(new Garage()
            {
                ID = 2, //This is explicitly the same as the id returning from the jwt token (GarageID)
                Name = "Waterfront",
                Address = "Mr.Treublaan 7, 1097 DP Amsterdam, Netherlands",
                StatusTypeID = 0, //Unknown

                Doors = new Doors()
                {
                    new Door(){ ID = 1, Name = "North Gate", IPAddress = "192.168.0.102"}, //NOTE - Make sure to update the local ip's to desired local ip for testing.
                    new Door(){ ID = 2, Name = "South Gate", IPAddress = "192.168.0.101"}, //NOTE - Make sure to update the local ip's to desired local ip for testing.
                    new Door(){ ID = 3, Name = "Main Gate", IPAddress = "www.google.co.za"},
                    new Door(){ ID = 4, Name = "Side Door", IPAddress = "www.google.co.za"},
                    new Door(){ ID = 5, Name = "Boom One", IPAddress = "www.google.co.za"},
                }
            });
            context.SaveChanges();
        } 
        #endregion
    }
}