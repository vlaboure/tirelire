using applicationTirelire.DataAccess;
using applicationTirelire.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(applicationTirelire.Startup))]
namespace applicationTirelire
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Repository<Role> repFournisseur = new EFRepository<Role>();
        }
    }
}
