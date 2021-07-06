using UnityEngine;
using UnityEngine.Events;

namespace CleanCore.Events
{
	public class MouseEvent : MonoBehaviour
	{
		[Header("Config Event")]
		[SerializeField] private UnityEvent onMouseEvent;

		protected void InvokeMouseEvent()
        {
			onMouseEvent?.Invoke();
        }
	}
}