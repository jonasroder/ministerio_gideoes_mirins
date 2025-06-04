using Infrastructure.SharedKernel.Logger;

namespace Application.SharedKernel.Common;

public static class ResultLoggerContext
{
    private static object? _logger;

    public static void Set<T>(BaseLogger<T> logger) => _logger = logger;

    public static BaseLogger<T>? Get<T>() => _logger as BaseLogger<T>;

    public static void Clear() => _logger = null;
}
