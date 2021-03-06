﻿using BeatSaberMarkupLanguage.Parser;
using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace BeatSaberMarkupLanguage.Macros
{
    public class AsHostMacro : BSMLMacro
    {
        public override string[] Aliases => new[] { "as-host" };

        public override Dictionary<string, string[]> Props => new Dictionary<string, string[]>()
        {
            { "host", new[]{"host"} },
        };

        public override void Execute(XmlNode node, GameObject parent, Dictionary<string, string> data, BSMLParserParams parserParams)
        {
            if (data.TryGetValue("host", out string host))
            {
                if (!parserParams.values.TryGetValue(host, out BSMLValue value))
                    throw new Exception("host '" + host + "' not found");
                BSMLParser.instance.Parse(node, parent, value.GetValue());
            }
        }
    }
}
