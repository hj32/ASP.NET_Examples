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