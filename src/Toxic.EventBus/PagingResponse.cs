using System.Collections.Generic;

namespace Toxic.EventBus
{
    public sealed class PagingResponse<TResponseItem> : Response
    {
        public int Total { get; set; }
        public IEnumerable<TResponseItem> Response { get; set; }
    }
}