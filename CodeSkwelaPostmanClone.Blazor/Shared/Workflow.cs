using CodeSkwelaPostmanClone.Blazor.Core.Entities;
using MudBlazor;

namespace CodeSkwelaPostmanClone.Blazor.Shared
{
    public class Workflow
    {
        private WorkflowAction _rootAction, _lastAction;

        public void AddAction(WorkflowAction action)
        {
            if (_rootAction is null)
            {
                _rootAction = action;
            }
            else if (_lastAction is null)
            {
                _rootAction.SetNextAction(action);
                _lastAction = action;
            }
            else
            {
                _lastAction.SetNextAction(action);
                _lastAction = action;
            }
        }

        public async Task Run()
        {
            var currentAction = _rootAction;
            do
            {
                await currentAction.Run(null);
                if (currentAction.HasNextAction())
                    currentAction = currentAction.GetNextAction();
                else
                    currentAction = null;
            }
            while (currentAction is not null);
        }

        public WorkflowAction GetRootAction()
        {
            return _rootAction;
        }
    }

    public class WorkflowAction : IWorkflowAction
    {
        private WorkflowAction _nextAction;
        public Func<string?, Task> OnResponseOutput { get; set; }

        public WorkflowAction(string name, Func<string?, Task> callback = null)
        {
            Name = name;
            OnResponseOutput += callback;
        }

        public string Name { get; set; }

        public void SetNextAction(WorkflowAction action)
        {
            _nextAction = action;
        }

        public WorkflowAction GetNextAction()
        {
            return _nextAction;
        }

        public bool HasNextAction()
        {
            var result = _nextAction is not null;
            return result;
        }

        public virtual Task<string?> Run(string? parameters)
        {
            return null;
        }
    }    

    public interface IWorkflowAction
    {
        Task<string?> Run(string? parameters);
    }    
}
