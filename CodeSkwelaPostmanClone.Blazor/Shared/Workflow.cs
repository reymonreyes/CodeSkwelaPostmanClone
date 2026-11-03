using CodeSkwelaPostmanClone.Blazor.Core.Entities;
using MudBlazor;
using System.Collections;

namespace CodeSkwelaPostmanClone.Blazor.Shared
{
    public class Workflow : IEnumerable<WorkflowAction>
    {
        private List<WorkflowAction> _actions = new List<WorkflowAction>();
        private WorkflowAction _rootAction, _lastAction;

        public void AddAction(WorkflowAction action)
        {
            _actions.Add(action);
            //if (_rootAction is null)
            //{
            //    _rootAction = action;
            //}
            //else if (_lastAction is null)
            //{
            //    _rootAction.SetNextAction(action);
            //    _lastAction = action;
            //}
            //else
            //{
            //    _lastAction.SetNextAction(action);
            //    _lastAction = action;
            //}
        }

        public List<WorkflowAction> Actions { get{ return _actions; }}

        public async Task Run()
        {
            foreach (var action in _actions)
            {
                await action.Run(null);
            }

            //var currentAction = _rootAction;

            //while (currentAction is not null)
            //{
            //    await currentAction.Run(null);
            //    if (currentAction.HasNextAction())
            //        currentAction = currentAction.GetNextAction();
            //    else
            //        currentAction = null;
            //}
        }

        public WorkflowAction GetRootAction()
        {
            return _rootAction;
        }

        public IEnumerator<WorkflowAction> GetEnumerator()
        {
            return _actions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
