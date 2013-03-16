# Glimpse 1.x Plugin for Ninject v3.x

### What is Glimpse and Ninject?

Glimpse is an awesome open source Firebug for ASP.NET: http://getglimpse.com/

Ninject is an awesome open source dependency injector for .NET: http://ninject.org/

### What is this?

This Glimpse Plugin gives you a clearer view of your Ninject Modules, bindings and settings.

### Quick start

Simply drag and drop Ninject.Extensions.Glimpse.dll into your bin directory. It should automatically locate your Ninject container instance if it supports automatic extension loading.

### Manual Wireup

If you have ninject extension loading off, you'll need to manually add the Glimpse module to your new StandardKernel() creation call:

```C#	
private static IKernel CreateKernel()
{
	var kernel = new StandardKernel(new GetNinjectInstanceForGlimpseModule());
	
	// Other Registration ommitted
		
	return kernel;
}
```
	
OR

```C#	
private static void RegisterServices(IKernel kernel)
{
	// Load Specific Modules
	kernel.Load(new GetNinjectInstanceForGlimpseModule());
}       
```
