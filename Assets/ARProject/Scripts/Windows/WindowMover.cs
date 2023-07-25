using System.Collections;
using UnityEngine;

public class WindowMover : MonoBehaviour
{
	[Header("References On Windows")]
	[SerializeField] private RectTransform _sectionWindow;
	[SerializeField] private RectTransform _viewerWindow;
	[SerializeField] private RectTransform _windowBundle;
	
	[Header("Moving Parameters")]
	[SerializeField] private float _movingSpeed = 10f;
	
	private bool _isBlock;
	public bool IsBlock => _isBlock;
	
	private RectTransform _lastMenu;
	private RectTransform _newMenu;
	private readonly Vector2 _centralPosition = Vector2.zero;

	private int _maxWindowIndex;

	public void Initialize(int amountWindows)
	{
		_maxWindowIndex = amountWindows - 1;
		
		_lastMenu = _sectionWindow;
	}

	public void StartAnimation(RectTransform menu)
	{
		if (menu == _lastMenu || _isBlock)
			return;

		_newMenu = menu;

		StartCoroutine(PrepareToMove());	
	}

	private IEnumerator PrepareToMove()
	{
		_isBlock = true;

		_newMenu.gameObject.SetActive(true);

		Vector2 rightPosition = Vector2.zero;

		rightPosition.x = _newMenu.rect.width;
		
		_newMenu.anchoredPosition = rightPosition;
		_newMenu.SetSiblingIndex(_maxWindowIndex);

		yield return StartCoroutine(Move(_newMenu, _centralPosition));

		_isBlock = false;

		_lastMenu.gameObject.SetActive(false);
		_lastMenu = _newMenu;
	}

	private IEnumerator Move(RectTransform menu, Vector2 position)
	{
		while (position != menu.anchoredPosition)
		{
			menu.anchoredPosition = Vector2.MoveTowards(menu.anchoredPosition, position, _movingSpeed * Time.deltaTime);

			yield return null;
		}
	}

	public void OpenModelViewerMenu()
	{
		_viewerWindow.gameObject.SetActive(true);
		_windowBundle.gameObject.SetActive(false);
	}

	public void CloseModelViewerMenu()
	{
		_viewerWindow.gameObject.SetActive(false);
		_windowBundle.gameObject.SetActive(true);
	}
}
