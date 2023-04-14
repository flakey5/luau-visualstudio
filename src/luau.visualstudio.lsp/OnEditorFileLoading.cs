using Microsoft;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using luau.visualstudio.lsp.options;

namespace luau.visualstudio.lsp {
    /// <summary>
    /// Exists for adding .lua files into the registry if LuauGeneralOptions.supportLuaFiles is true
    /// </summary>
    [Export(typeof(EditorOptionDefinition))]
    internal sealed partial class OnEditorFileLoading : EditorOptionDefinition<string> {
        public static readonly EditorOptionKey<string> OPTION_KEY = new EditorOptionKey<string>("Luau file extensions");
        public override EditorOptionKey<string> Key => OnEditorFileLoading.OPTION_KEY;

        [ImportingConstructor]
        public OnEditorFileLoading(
            LuauGeneralOptions options,
            IContentTypeRegistryService contentTypeRegistry,
            IFileExtensionRegistryService fileExtensionRegistry
        ) {
            Requires.NotNull(options, nameof(options));
            if (!options.supportLuaFiles)
                return;

            Requires.NotNull(contentTypeRegistry, nameof(contentTypeRegistry));
            Requires.NotNull(fileExtensionRegistry, nameof(fileExtensionRegistry));

            IContentType contentType = contentTypeRegistry.GetContentType(Constants.CONTENT_TYPE);
            fileExtensionRegistry.AddFileExtension(".lua", contentType);
        }
    }
}
