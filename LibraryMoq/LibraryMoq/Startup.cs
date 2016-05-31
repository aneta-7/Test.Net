using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryMoq.Startup))]
namespace LibraryMoq
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
