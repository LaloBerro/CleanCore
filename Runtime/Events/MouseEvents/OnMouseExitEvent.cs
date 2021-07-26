namespace CleanCore.Events
{
	public class OnMouseExitEvent : MouseEvent
	{
        private void OnMouseExit()
        {
            InvokeMouseEvent();
        }
    }
}