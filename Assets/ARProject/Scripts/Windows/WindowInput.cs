using System;
using UnityEngine;

public class WindowInput : MonoBehaviour
{
	public event Action OnEscapeDowned;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			EscapeDowned();
		}
	}

	private void EscapeDowned()
	{
		OnEscapeDowned?.Invoke();
	}
}
