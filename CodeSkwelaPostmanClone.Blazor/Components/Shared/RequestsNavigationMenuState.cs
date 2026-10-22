namespace CodeSkwelaPostmanClone.Blazor.Components.Shared
{
    public class RequestsNavigationMenuState
    {
        public Action<int>? OnRequestSelected { get; set; }
        private int _selectedRequest;
        public int SelectedRequest {
            get { return _selectedRequest; }
            set {
                _selectedRequest = value;
                OnRequestSelected?.Invoke(_selectedRequest);
            }
        }
    }
}
