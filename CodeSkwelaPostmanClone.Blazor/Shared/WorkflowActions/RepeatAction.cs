using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CodeSkwelaPostmanClone.Blazor.Shared.WorkflowActions
{
    public class RepeatAction : WorkflowAction, IWorkflowAction
    {
        private DateTime _startTime;
        private int _repeatCount;

        public int RepeatCount
        {
            get => _repeatCount;
            set => _repeatCount = value;
        }
        public RepeatAction(string name, int repeatCount, Func<string?, Task> callback = null) : base(name, callback)
        {
            _repeatCount = repeatCount;
        }

        public override async Task<string?> Run(string? parameters)
        {
            _startTime = DateTime.Now;
            OnResponseOutput?.Invoke($"Repeating for {_repeatCount} times... [Start: {_startTime.ToFileTime()} ]");           
            
            for (int i = 0; i < _repeatCount; i++)
            {
                OnResponseOutput?.Invoke($"{i + 1} of {_repeatCount}...[Time: {DateTime.Now.ToFileTime()}]");

                foreach (var action in ChildActions)
                {
                    await action.Run(null);
                }
            }

            OnResponseOutput?.Invoke($"Completed repeating for {_repeatCount} times... [End: {_startTime.ToFileTime()} ]");
            
            return null;
        }        
    }    
}
