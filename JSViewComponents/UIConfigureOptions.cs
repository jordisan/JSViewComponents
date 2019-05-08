using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using System;

namespace JSViewComponents
{
    /// <summary>
    /// To access resources (.js, .css) in this library from outer projects
    /// </summary>
    public class UIConfigureOptions : IPostConfigureOptions<StaticFileOptions>
    {
        public UIConfigureOptions(IHostingEnvironment environment)
        {
            Environment = environment;
        }
        public IHostingEnvironment Environment { get; }

        public void PostConfigure(string name, StaticFileOptions options)
        {
            const string RESOURCES_FOLDER = "Resources";

            name = name ?? throw new ArgumentNullException(nameof(name));
            options = options ?? throw new ArgumentNullException(nameof(options));

            // Basic initialization in case the options weren't initialized by any other component
            options.ContentTypeProvider = options.ContentTypeProvider ?? new FileExtensionContentTypeProvider();
            if (options.FileProvider == null && Environment.WebRootFileProvider == null)
            {
                throw new InvalidOperationException("Missing FileProvider.");
            }

            options.FileProvider = options.FileProvider ?? Environment.WebRootFileProvider;

            // Use the files that are embedded in the assembly.
            options.FileProvider = new CompositeFileProvider(
                options.FileProvider,
                new ManifestEmbeddedFileProvider(GetType().Assembly, RESOURCES_FOLDER)
            );

            Environment.WebRootFileProvider = options.FileProvider; // required to make asp-append-version work as it uses the WebRootFileProvider. https://github.com/aspnet/Mvc/issues/7459
        }
    }
}
