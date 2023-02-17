using Microsoft.VisualStudio.LanguageServer.Client;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansible.VisualStudio
{
#pragma warning disable 649
    public class AnsibleContentDefinition
    {
        [Export]
        [Name("ansible")]
        [BaseDefinition(CodeRemoteContentDefinition.CodeRemoteContentTypeName)]
        internal static ContentTypeDefinition AnsibleContentTypeDefinition;

        [Export]
        [FileExtension(".ansible")]
        [ContentType("ansible")]
        internal static FileExtensionToContentTypeDefinition AnsibleFileExtensionDefinition;
    }
#pragma warning restore 649
}
