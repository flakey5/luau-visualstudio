using Microsoft.VisualStudio.LanguageServer.Client;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace luau.visualstudio.lsp {
    internal static class ContentTypes {
        [Export]
        [Name(Constants.CONTENT_TYPE)]
        [BaseDefinition(CodeRemoteContentDefinition.CodeRemoteContentTypeName)]
        internal static ContentTypeDefinition CONTENT_TYPE_DEFINITION { get; set; }

        [Export]
        [FileExtension(".luau")]
        [ContentType(Constants.CONTENT_TYPE)]
        internal static FileExtensionToContentTypeDefinition FILE_EXTENSION_DEFINITION { get; set; }
    }
}
