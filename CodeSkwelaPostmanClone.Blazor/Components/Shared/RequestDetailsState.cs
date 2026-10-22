namespace CodeSkwelaPostmanClone.Blazor.Components.Shared
{
    public class RequestDetailsState
    {
        public Action<int>? OnRequestDeleted { get; set; }
        public void DeleteRequest(int requestId)
        {
            OnRequestDeleted?.Invoke(requestId);
        }
    }
}
