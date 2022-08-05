﻿using JavaScriptEngineSwitcher.Core;
using JavaScriptEngineSwitcher.Jurassic;
using JavaScriptEngineSwitcher.Node;
using System;

namespace Ansible.VisualStudio.LanguageServer
{
    public class Loader
    {
        public Loader()
        {
            IJsEngine engine = new NodeJsEngine(new NodeSettings { UseBuiltinLibrary = true});
            engine.ExecuteFile("SpawnServer.js");
        }
    }
}
