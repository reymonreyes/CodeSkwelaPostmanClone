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

        public void Run()
        {
            var currentAction = _rootAction;
            do
            {
                currentAction.Run(null);
                if (currentAction.HasNextAction())
                    currentAction = currentAction.GetNextAction();
                else
                    currentAction = null;
            }
            while (currentAction is not null);
        }
    }

    public class WorkflowAction : IWorkflowAction
    {
        private WorkflowAction _nextAction;

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
