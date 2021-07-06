namespace CleanCore.Events
{
	public class OnMouseDownEvent : MouseEvent
	{
        private void OnMouseDown()
        {
            InvokeMouseEvent();
        }
    }
}