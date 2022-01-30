﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.Bot.Builder;

namespace GGroupp.Infra.Bot.Builder;

public static partial class TurnContextExtensions
{
    public static string EncodeText(this ITurnContext? turnContext, [AllowNull] string source)
    {
        if (string.IsNullOrEmpty(source))
        {
            return string.Empty;
        }

        if (turnContext is null || turnContext.IsNotTelegramChannel())
        {
            return source;
        }

        var encodedString = source;
        foreach(var regItem in RegexReplacement)
        {
            encodedString = regItem.Key.Replace(encodedString, regItem.Value);
        }
        return encodedString;
    }
}