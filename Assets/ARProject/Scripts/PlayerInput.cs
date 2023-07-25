using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	private enum InputType
	{
		Mouse,
		Touch,
	}
	
	[Header("Type")]
	[SerializeField] private InputType _currentType = InputType.Mouse;

	public event Action<Vector2> OnTouched;
	
	private Vector2 _mouseLastPosition;

	private void Update()
	{
		CheckInput();
	}

	private void CheckInput()
	{
		switch (_currentType)
		{
			case InputType.Mouse:
				CheckMouse();
				
				break;
			
			case InputType.Touch:
				CheckTouch();

				break;
		}
	}

	private void CheckTouch()
	{
		if (Input.touchCount == 0 || Input.touchCount >= 2)
		{
			OnTouched?.Invoke(Vector2.zero);
			
			return;
		}
		
		Touch touch = Input.GetTouch(0);

		OnTouched?.Invoke(touch.deltaPosition.normalized);
	}

	private void CheckMouse()
	{
		if (Input.GetMouseButton(0))
		{
			Vector2 mouseDelta = (Vector2)Input.mousePosition - _mouseLastPosition;
			
			_mouseLastPosition = Input.mousePosition;
			mouseDelta.x = -mouseDelta.x;

			OnTouched?.Invoke(mouseDelta.normalized);

			return;
		}
		
		OnTouched?.Invoke(Vector2.zero);
	}
}
