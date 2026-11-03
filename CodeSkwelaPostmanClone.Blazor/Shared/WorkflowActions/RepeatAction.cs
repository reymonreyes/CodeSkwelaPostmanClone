using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CodeSkwelaPostmanClone.Blazor.Shared.WorkflowActions
{
    public class RepeatAction : WorkflowAction, IWorkflowAction
    {
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
            Console.WriteLine(this.Name);
            OnResponseOutput?.Invoke($"Repeating for {_repeatCount} times...");
            for (int i = 0; i < _repeatCount; i++)
            {
                OnResponseOutput?.Invoke($"Iteration {i + 1} of {_repeatCount}...");

                var stack = new Stack<WorkflowAction>();
                stack.Push(this);

                while (stack.Count > 0)
                {
                    var current = stack.Pop();

                    if (current != this)
                        await current.Run(null);

                    foreach (var child in current.ChildActions.Reverse<WorkflowAction>())
                    {
                        stack.Push(child);
                    }
                }                
            }
            OnResponseOutput?.Invoke($"Completed repeating for {_repeatCount} times...");
            return null;
        }
    }    
}
