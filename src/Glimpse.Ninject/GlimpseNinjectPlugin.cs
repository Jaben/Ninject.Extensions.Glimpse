// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlimpseNinjectPlugin.cs" company="">
//   
// </copyright>
// <summary>
//   The ninject glimpse plugin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
//
using System.Collections.Generic;
using System.Linq;
//
using Glimpse.Core.Extensibility;
//
using Ninject;
using Ninject.Modules;

namespace Glimpse.Ninject
{
    /// <summary>
	/// The ninject glimpse plugin.
	/// </summary>
	public class GlimpseNinjectPlugin : TabBase, IDocumentation
	{
	    public override object GetData(ITabContext context)
	    {
            var returnCollection = new Dictionary<string, object>();

            if (GetNinjectInstanceForGlimpseModule.CurrentKernel == null)
            {
                return "Unable to grab instance of the Ninject Kernel.";
            }

            IKernel kernel = GetNinjectInstanceForGlimpseModule.CurrentKernel;

            var modules =
                kernel.GetModules().OfType<NinjectModule>().Where(s => s.Name != "Ninject.Extensions.Glimpse.GetNinjectInstanceForGlimpseModule").
                    ToDictionary<NinjectModule, string, object>(module => module.Name, module => module.Bindings);

            returnCollection.Add("Modules & Bindings", modules);
            returnCollection.Add("Kernel Settings", kernel.Settings);

            return returnCollection;
	    }

	    public override string Name
	    {
            get { return "Ninject"; }
	    }

	    public string DocumentationUri
	    {
            get { return "https://github.com/segilbert/Ninject.Extensions.Glimpse/blob/glimpseupgrade/Readme.md"; }
	    }
	}
}