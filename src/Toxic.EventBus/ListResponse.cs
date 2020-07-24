using System.Collections.Generic;

namespace Toxic.EventBus
{
    public sealed class ListResponse<TResponseItem> : Response
    {
        public IEnumerable<TResponseItem> Response { get; set; }
    }
}