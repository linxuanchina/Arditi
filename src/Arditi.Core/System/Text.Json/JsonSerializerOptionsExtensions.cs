﻿using Arditi.Json;

namespace System.Text.Json;

public static class JsonSerializerOptionsExtensions
{
    public static JsonSerializerOptions AddApplicationExceptionConverter(this JsonSerializerOptions options)
    {
        options.Converters.Add(new ApplicationExceptionConverter());
        return options;
    }

    public static JsonSerializerOptions AddLongEpochTimeConverter(this JsonSerializerOptions options)
    {
        options.Converters.Add(
            new LongEpochTimeConverter()
        );
        return options;
    }

    public static JsonSerializerOptions AddEpochTimeConverter(this JsonSerializerOptions options)
    {
        options.Converters.Add(
            new EpochTimeConverter()
        );
        return options;
    }

    public static JsonSerializerOptions AddGuidConverter(this JsonSerializerOptions options)
    {
        options.Converters.Add(
            new GuidConverter()
        );
        return options;
    }
}
