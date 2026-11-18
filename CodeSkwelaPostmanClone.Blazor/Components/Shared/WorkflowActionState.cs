using CodeSkwelaPostmanClone.Blazor.Shared;

namespace CodeSkwelaPostmanClone.Blazor.Components.Shared
{
    public class WorkflowActionState
    {
        public Action<WorkflowAction, int>? OnMoveAction { get; set; }
        public Action? OnCancelMoveAction { get; set; }
        public Action? OnCompleteMoveAction { get; set; }

        public void MoveAction(WorkflowAction action, int index)
        {
            OnMoveAction?.Invoke(action, index);
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
