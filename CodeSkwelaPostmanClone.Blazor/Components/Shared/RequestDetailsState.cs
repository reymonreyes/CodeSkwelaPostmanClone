using CodeSkwelaPostmanClone.Blazor.Core.Entities;

namespace CodeSkwelaPostmanClone.Blazor.Components.Shared
{
    public class RequestDetailsState
    {
        public Action<int>? OnRequestDeleted { get; set; }
        public Action<Core.Entities.RequestSettings>? OnRequestAdded { get; set; }
        public void DeleteRequest(int requestId)
        {
            OnRequestDeleted?.Invoke(requestId);
        }

        public void AddRequest(RequestSettings request)
        {
            OnRequestAdded?.Invoke(request);
        }
    }
}
