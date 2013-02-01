using System.Web.Routing;
using Bottles;
using FubuCore;
using FubuMVC.Core;
using FubuMVC.Core.UI.Elements;
using FubuMVC.Core.UI.Forms;
using FubuMVC.StructureMap;
using FubuMVC.TwitterBootstrap.Forms;
using FubuPersistence;
using FubuPersistence.RavenDb;
using HtmlTags.Conventions;
using StructureMap.Configuration.DSL;

namespace FubuInAction
{
    // Using a separate class for bootstrapping makes it much easier to reuse your application 
    // in testing scenarios with either SelfHost or OWIN/Katana hosting
    public class MyApplication : IApplicationSource
    {
        public FubuApplication BuildApplication()
        {
            // This is bootstrapping an application with all default FubuMVC conventions and
            // policies pulling actions from only this assembly for classes suffixed with
            // "Endpoint" or "Endpoints"
            return FubuApplication
				.For<MyFubuMvcPolicies>()
				.StructureMap<MyStructureMapRegistry>();



            // Fancier way if you want to specify your own policies:
            // return FubuApplication.For<MyFubuMvcPolicies>().StructureMap(new Container());


            // Here's an example of using StructureMap specific registration with a StructureMap Registry.  
            // return FubuApplication.For<MyFubuMvcPolicies>().StructureMap<MyStructureMapRegistry>();
        }
    }

    public class MyStructureMapRegistry : Registry
    {
        public MyStructureMapRegistry()
        {
            // StructureMap registration here
			IncludeRegistry<RavenDbRegistry>();
        }
    }

	public class HiddenEntityIdentifiers : IElementModifier
	{
		public bool Matches(ElementRequest token)
		{
			return token.Accessor.OwnerType.CanBeCastTo<IEntity>()
			       && token.Accessor.Name == "Id";
		}

		public void Modify(ElementRequest request)
		{
			request.CurrentTag.Attr("type", "hidden");
		}
	}
}