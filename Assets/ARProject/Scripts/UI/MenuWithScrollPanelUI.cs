using UnityEngine;

public class MenuWithScrollPanelUI : MonoBehaviour
{
    [SerializeField] private RectTransform _panel;

	private void OnEnable()
	{
		_panel.anchoredPosition = Vector2.zero;
	}
}
