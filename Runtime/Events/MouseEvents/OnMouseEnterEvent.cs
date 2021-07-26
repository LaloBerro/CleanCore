namespace CleanCore.Events
{
	public class OnMouseEnterEvent : MouseEvent
	{
        private void OnMouseEnter()
        {
            InvokeMouseEvent();
        }
    }
}