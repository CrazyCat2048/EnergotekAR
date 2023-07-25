using System;
using System.Collections.Generic;
using UnityEngine;

public class WindowChanger : MonoBehaviour
{
	[Header("Widnows")]
	[SerializeField] private RectTransform _section;
	[SerializeField] private RectTransform _subsection;
	[SerializeField] private RectTransform _viewer;
	[SerializeField] private RectTransform _search;
	[SerializeField] private RectTransform _found;
	[SerializeField] private RectTransform _background;
	
	[Header("References")]
	[SerializeField] private WindowMover _windowMover;
	[SerializeField] private WindowInput _windowInput;
	[SerializeField] private ModelSpawner _modelSpawner;

	public event Action OnVieverModelWindowEnabled;
	public event Action OnVieverModelWindowDisabled;
	
	private Dictionary<int, RectTransform> _windows = new Dictionary<int, RectTransform>();
	private Stack<int> _previousWindows = new Stack<int>();

	private int _currentNumber = -1;
	
	private void Start()
	{
		_windowInput.OnEscapeDowned += ChangeBack;
		
		_windows.Add(0, _section);
		_windows.Add(1, _subsection);
		_windows.Add(2, _search);
		_windows.Add(3, _found);
		_windows.Add(4, _viewer);
		
		_windowMover.Initialize(_windows.Count - 1);
		
		Change(0);
	}

	public void Change(int windowNumber)
	{
		if (!_windows.TryGetValue(windowNumber, out RectTransform window))
			return;

		if (windowNumber != _currentNumber)
			_previousWindows.Push(windowNumber);

		_currentNumber = windowNumber;
		
		_windowMover.StartAnimation(window);
	}

	private void ChangeBack()
	{
		if (_windowMover.IsBlock || _previousWindows.Count == 1)
			return;

		if (_previousWindows.Peek() == 4)
		{
			HideModelViewer();

			return;
		}

		_previousWindows.Pop();

		Change(_previousWindows.Peek());
	}
	
	public void LaunchModelViewer(string model)
	{
		_previousWindows.Push(4);

		_currentNumber = _previousWindows.Peek();
		
		_windowMover.OpenModelViewerMenu();
		
		_background.gameObject.SetActive(false);

		_modelSpawner.CreateModel(model);
		
		OnVieverModelWindowEnabled?.Invoke();
	}

	public void HideModelViewer()
	{
		_previousWindows.Pop();

		_currentNumber = _previousWindows.Peek();
		
		_windowMover.CloseModelViewerMenu();
		
		_background.gameObject.SetActive(true);

		_modelSpawner.ClearWindow();
		
		OnVieverModelWindowDisabled?.Invoke();
	}

	public void ChangeOnMain()
	{
		if (_windowMover.IsBlock || _currentNumber == 0)
			return;

		_previousWindows.Clear();

		_currentNumber = -1;
				
		Change(0);
	}
}
