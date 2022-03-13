﻿using System;
using HandyControl.Themes;

namespace HandyControlDemo.Data;

internal class AppConfig
{
    public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}AppConfig.json";

    public string Lang { get; set; } = "en";

    public ApplicationTheme Theme { get; set; }
}
