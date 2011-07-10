// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NinjectGlimpsePlugin.cs" company="">
//   
// </copyright>
// <summary>
//   The ninject glimpse plugin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Glimpse.Ninject
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;

	using Glimpse.Core.Extensibility;

	using global::Ninject;
	using global::Ninject.Modules;

	/// <summary>
	/// The ninject glimpse plugin.
	/// </summary>
	[GlimpsePlugin(false)]
	public class NinjectGlimpsePlugin : IGlimpsePlugin
	{
		#region Properties

		/// <summary>
		/// Gets Name.
		/// </summary>
		public string Name
		{
			get
			{
				return "Ninject v2";
			}
		}

		#endregion

		#region Implemented Interfaces

		#region IGlimpsePlugin

		/// <summary>
		/// The get data.
		/// </summary>
		/// <param name="context">
		/// The context.
		/// </param>
		/// <returns>
		/// The get data.
		/// </returns>
		public object GetData(HttpContextBase context)
		{
			var returnCollection = new Dictionary<string, object>();

			if (GetNinjectInstanceForGlimpseModule.CurrentKernel == null)
			{
				return "Unable to grab instance of the Ninject Kernel.";
			}

			IKernel kernel = GetNinjectInstanceForGlimpseModule.CurrentKernel;

			var modules =
				kernel.GetModules().OfType<NinjectModule>().Where(s => s.Name != "Glimpse.Ninject.NinjectGlipseLocationModule").
					ToDictionary<NinjectModule, string, object>(module => module.Name, module => module.Bindings);

			returnCollection.Add("Modules & Bindings", modules);
			returnCollection.Add("Kernel Settings", kernel.Settings);

			return returnCollection;
		}

		/// <summary>
		/// The setup init.
		/// </summary>
		public void SetupInit()
		{
		}

		#endregion

		#endregion
	}
}