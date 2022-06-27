# ServiceLifetimeExample


## Configuring Landing Page


Add a Name to the cshtml page to navigate to in this case "/"

{


page "/"
@model IndexModel
@{
    ViewData["Title"] = "Home page";
}

<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Learn about <a href="https://docs.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
</div>


}

Add this following code to the ConfigureServices Method of the Startup.cs or the prebuild code in the program.cs

{

 // AddPageRoute (Pagename, Route)
            services.AddRazorPages(options=>options.Conventions.AddPageRoute("/Homepage", "/"));





}

The Configuration of razor pages is based on the following facts.

The associations of URL paths to pages are determined by the page's location in the file system. The following table shows a Razor Page path and the matching URL:

|File name and path	| matching URL
|-------------------|---------------
|/Pages/Index.cshtml|	/ or /Index
|/Pages/Contact.cshtml|	/Contact
|/Pages/Store/Contact.cshtml	|/Store/Contact
|/Pages/Store/Index.cshtml|	/Store or /Store/Index

Notes:

The runtime looks for Razor Pages files in the Pages folder by default.
Index is the default page when a URL doesn't include a page.