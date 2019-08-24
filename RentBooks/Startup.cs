using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentBooks.Startup))]
namespace RentBooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
