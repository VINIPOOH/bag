using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalamandrBag;
using SalamandrBag.animal;
using SalamandrBag.animal.impl;
using SalamandrBag.impl;

namespace WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IAnimalFactory>(new AnimalFactory());
            services.AddSingleton(new DefaultBagFactory().GetBagService());



//            var mapperAPIConfig = new MapperConfiguration(opt => opt.AddProfile<ModelDtoMaper>());
//            IMapper mapperAPI = new Mapper(mapperAPIConfig);
//            services.AddSingleton(mapperAPI);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Bag}/{action=Index}/{id?}");
            });
        }
    }
}