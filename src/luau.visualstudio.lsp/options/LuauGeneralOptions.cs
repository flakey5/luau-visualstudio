using System.ComponentModel;
using Microsoft.VisualStudio.Shell;

namespace luau.visualstudio.lsp.options {
    public class LuauGeneralOptions : DialogPage {
        [DisplayName("Support .lua files")]
        [Description("Support files with the .lua extension in addition to .luau files. Requires restart")]
        public bool supportLuaFiles { get; set; } = true;
    }
}
