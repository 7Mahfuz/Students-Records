using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Students_Record_Web.Startup))]
namespace Students_Record_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
