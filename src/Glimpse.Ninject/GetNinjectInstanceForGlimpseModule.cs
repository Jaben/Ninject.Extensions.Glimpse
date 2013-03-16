// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetNinjectInstanceForGlimpseModule.cs" company="">
//   
// </copyright>
// <summary>
//   The ninject glipse location module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
//
using Ninject;
using Ninject.Modules;

namespace Glimpse.Ninject
{
	
	/// <summary>
	/// The ninject glipse location module.
	/// </summary>
	public class GetNinjectInstanceForGlimpseModule : NinjectModule
	{
		#region Properties

		/// <summary>
		/// Gets CurrentKernel.
		/// </summary>
		internal static IKernel CurrentKernel { get; private set; }

		#endregion

		#region Public Methods

		/// <summary>
		/// Loads the module into the kernel.
		/// </summary>
		public override void Load()
		{
			// get an instance of the kernel...
			CurrentKernel = this.Kernel;
		}

		#endregion
	}
}