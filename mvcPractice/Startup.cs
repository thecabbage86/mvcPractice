using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcPractice.Startup))]
namespace mvcPractice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
