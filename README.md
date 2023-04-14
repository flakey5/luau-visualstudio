# luau-visualstudio
[Luau](https://luau-lang.org/) support for Visual Studio.

## Overview
This repository holds two different extensions available on Visual Studio's marketplace:

 * [Luau TextMate Grammars](src/luau.visualstudio.grammar) - Provides basic syntax highlighting through TextMate files
 * [Luau Language Server](src/luau.visualstudio.lsp) - Language server client. Provides intellisense, code completion, etc.
    * Uses @JohnnyMorganz 's [language server](https://github.com/JohnnyMorganz/luau-lsp)

## Todo
 * Dynamic support for `.lua` files is currently broken
 * Support `.luarc`, documentation, and global type files
 * Add fast flag support?
 * Opt-in Roblox globals & api docs

## Licence stuff
This repository is under the MIT licence, which you can find a copy of in the [LICENCE](LICENCE) file.

Additionally, [`src/luau.visualstudio.lsp/luau-lsp.exe`](src/luau.visualstudio.lsp/luau-lsp.exe) is from
[https://github.com/JohnnyMorganz/luau-lsp](https://github.com/JohnnyMorganz/luau-lsp), which is also under the MIT licence.
[`src/luau.visualstudio.grammar/Syntaxes/luau.tmLanguage`](src/luau.visualstudio.grammar/Syntaxes/luau.tmLanguage) was based off the
tmLanguage file in that repository as well.
