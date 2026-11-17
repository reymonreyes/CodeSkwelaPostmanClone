using CodeSkwelaPostmanClone.Blazor.Shared;

namespace CodeSkwelaPostmanClone.Blazor.Components.Shared
{
    public class WorkflowActionState
    {
        public Action<WorkflowAction>? OnMoveAction { get; set; }
        public Action? OnCancelMoveAction { get; set; }
        public Action? OnCompleteMoveAction { get; set; }

        public void MoveAction(WorkflowAction action)
        {
            OnMoveAction?.Invoke(action);
        }

        public void CancelMoveAction()
        {
            OnCancelMoveAction?.Invoke();
        }

        public void CompleteMoveAction()
        {
            OnCompleteMoveAction?.Invoke();
        }
    }
}
