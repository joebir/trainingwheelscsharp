using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainingWheelsCSharp.Startup))]
namespace TrainingWheelsCSharp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
