namespace Toxic.EventBus
{
    public sealed class ObjectResponse<TResponse> : Response
    {
        public TResponse Response { get; set; }
    }
}