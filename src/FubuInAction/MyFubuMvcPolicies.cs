using FubuMVC.Core;
using FubuMVC.Core.UI;

namespace FubuInAction
{
	public class MyFubuMvcPolicies : FubuRegistry
	{
		public MyFubuMvcPolicies()
		{
			// This is a DSL to change or add new conventions, policies, or application settings
			Import<HtmlConventionRegistry>(x => x.Editors.Add(new HiddenEntityIdentifiers()));
		}
	}
}