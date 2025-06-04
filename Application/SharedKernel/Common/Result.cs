using System.Runtime.CompilerServices;

namespace Application.SharedKernel.Common;

public class Result<T> : ResultBase
{
    public T? Data { get; }

    private Result(bool isSuccess, string? message, T? data, string? errorCode)
        : base(isSuccess, message, errorCode)
    {
        Data = data;
    }


    private static void Log<TOrigin>(string message, Action<string> logAction, string caller, string file, int line)
    {
        var logger = ResultLoggerContext.Get<TOrigin>();
        logAction.Invoke($"{message} | Origem: {Path.GetFileName(file)} > {caller}() @L{line}");
    }


    public static Result<T> Success<TOrigin>(
        T data,
        string? message = null,
        [CallerMemberName] string caller = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        var msg = message ?? "Operação realizada com sucesso.";
        Log<TOrigin>(msg, l => ResultLoggerContext.Get<TOrigin>()?.LogInformation(l), caller, file, line);
        return new(true, msg, data, null);
    }


    public static Result<T> Failure<TOrigin>(
        string message,
        string? errorCode = null,
        [CallerMemberName] string caller = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        Log<TOrigin>(message, l => ResultLoggerContext.Get<TOrigin>()?.LogWarning(l), caller, file, line);
        return new(false, message, default, errorCode);
    }


    public static Result<T> NotFound<TOrigin>(
        string? message = "Recurso não encontrado.",
        string? errorCode = "NOT_FOUND",
        [CallerMemberName] string caller = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        Log<TOrigin>(message!, l => ResultLoggerContext.Get<TOrigin>()?.LogWarning(l), caller, file, line);
        return new(false, message, default, errorCode);
    }


    public static Result<T> Unauthorized<TOrigin>(
        string? message = "Acesso não autorizado.",
        string? errorCode = "UNAUTHORIZED",
        [CallerMemberName] string caller = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        Log<TOrigin>(message!, l => ResultLoggerContext.Get<TOrigin>()?.LogWarning(l), caller, file, line);
        return new(false, message, default, errorCode);
    }
    public static Result<T> Forbidden<TOrigin>(
    string? message = "Acesso negado.",
    string? errorCode = "FORBIDDEN",
    [CallerMemberName] string caller = "",
    [CallerFilePath] string file = "",
    [CallerLineNumber] int line = 0)
    {
        Log<TOrigin>(message!, l => ResultLoggerContext.Get<TOrigin>()?.LogWarning(l), caller, file, line);
        return new(false, message, default, errorCode);
    }


    public static Result<T> Conflict<TOrigin>(
        string? message = "Conflito de estado.",
        string? errorCode = "CONFLICT",
        [CallerMemberName] string caller = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        Log<TOrigin>(message!, l => ResultLoggerContext.Get<TOrigin>()?.LogWarning(l), caller, file, line);
        return new(false, message, default, errorCode);
    }


    public static Result<T> Unprocessable<TOrigin>(
        string? message = "Dados inválidos.",
        string? errorCode = "UNPROCESSABLE_ENTITY",
        [CallerMemberName] string caller = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        Log<TOrigin>(message!, l => ResultLoggerContext.Get<TOrigin>()?.LogWarning(l), caller, file, line);
        return new(false, message, default, errorCode);
    }


    public static Result<T> InternalError<TOrigin>(
        string? message = "Erro interno do servidor.",
        string? errorCode = "INTERNAL_SERVER_ERROR",
        [CallerMemberName] string caller = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        Log<TOrigin>(message!, l => ResultLoggerContext.Get<TOrigin>()?.LogError(l), caller, file, line);
        return new(false, message, default, errorCode);
    }

}
