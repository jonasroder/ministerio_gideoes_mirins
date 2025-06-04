namespace Infrastructure.SharedKernel.Logger
{
    public interface ICorrelationIdGenerator
    {
        string Get();
        void Set(string correlationId);
    }
}
