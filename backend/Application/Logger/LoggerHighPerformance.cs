using Microsoft.Extensions.Logging;

namespace Application.Logger
{
    public static class LoggerHighPerformance
    {
        private static readonly Action<ILogger, string, Exception?> _iniciando = LoggerMessage.Define<string>(LogLevel.Information, new EventId(1000, nameof(Iniciando)), "{classe} - Início.");
        private static readonly Action<ILogger, string, Exception?> _finalizado = LoggerMessage.Define<string>(LogLevel.Information, new EventId(1001, nameof(Finalizado)), "{classe} - Finalizado.");
        private static readonly Action<ILogger, string, Exception?> _erro = LoggerMessage.Define<string>(LogLevel.Error, new EventId(1002, nameof(Erro)), "{classe} - Erro.");

        public static void Iniciando(this ILogger logger, string classe)
        {
            _iniciando(logger, classe, null);
        }
        public static void Finalizado(this ILogger logger, string classe)
        {
            _finalizado(logger, classe, null);
        }
        public static void Erro(this ILogger logger, string classe, Exception e)
        {
            _erro(logger, classe, e);
        }
    }
}
