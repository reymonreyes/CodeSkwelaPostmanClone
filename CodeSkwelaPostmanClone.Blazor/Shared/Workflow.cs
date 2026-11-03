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
        }

        public List<WorkflowAction> Actions { get{ return _actions; }}

        public async Task Run()
        {
            foreach (var action in _actions)
            {
                await action.Run(null);
            }            
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
        private List<WorkflowAction> _childActions = new List<WorkflowAction>();
        public List<WorkflowAction> ChildActions { get; set; } = new List<WorkflowAction>();
        public Func<string?, Task> OnResponseOutput { get; set; }

        public WorkflowAction(string name, Func<string?, Task> callback = null)
        {
            Name = name;
            OnResponseOutput += callback;
        }

        public string Name { get; set; }
        
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
