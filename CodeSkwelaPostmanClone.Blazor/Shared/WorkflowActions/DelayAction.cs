namespace CodeSkwelaPostmanClone.Blazor.Shared.WorkflowActions
{
    public class DelayAction : WorkflowAction, IWorkflowAction
    {
        private int _delayMs;

        public int DelayInMilliSeconds
        {
            get => _delayMs;
            set => _delayMs = value;
        }
        public DelayAction(string name, int delayMs = 1000, Func<string?, Task> callback = null) : base(name, callback)
        {
            _delayMs = delayMs;
        }

        public override async Task<string?> Run(string? parameters)
        {
            Console.WriteLine(this.Name);
            OnResponseOutput?.Invoke($"Delaying for {_delayMs} ms...");
            await Task.Delay(_delayMs);
            OnResponseOutput?.Invoke($"Completed delay of {_delayMs} ms...");
            return null;
        }
    }
}
