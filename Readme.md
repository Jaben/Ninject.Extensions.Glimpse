# Glimpse Plugin for Ninject v2.x

### What is Glimpse and Ninject?

Glimpse is an awesome open source Firebug for ASP.NET: http://getglimpse.com/

Ninject is an awesome open source dependency injector for .NET: http://ninject.org/

### What is this?

This Glimpse Plugin gives you a clearer view of your Ninject Modules, bindings and settings.

### Quick start

Simply drag and drop Ninject.Extensions.Glimpse.dll into your bin directory. It will automatically locator your Ninject container instance that is automatically loading extensions.

### Manual Wireup

If you have ninject extension loading off, you'll need to manually add the Glimpse module to your new StandardKernel() creation call:

	var kernel = new StandardKernel(KernelOptions, new GeneralModule(), new Ninject.Extensions.Glimpse.GetNinjectInstanceForGlimpseModule());

	
Althought, that kind of defeats the purpose of loose design. ;)