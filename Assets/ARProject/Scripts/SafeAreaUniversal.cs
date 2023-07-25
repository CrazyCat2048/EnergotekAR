using UnityEngine;

public class SafeAreaUniversal : MonoBehaviour
{
	private RectTransform _rect;

	private ScreenOrientation _lastOrientation = ScreenOrientation.AutoRotation;

	private void Awake()
	{
		_rect = GetComponent<RectTransform>();
	}

	public void UpdateArea()
	{
		var safeArea = Screen.safeArea;

		var anchorMin = safeArea.position;
		var anchorMax = safeArea.position + safeArea.size;

		anchorMin.x /= Screen.width;
		anchorMin.y /= Screen.height;
		anchorMax.x /= Screen.width;
		anchorMax.y /= Screen.height;

		_rect.anchorMin = anchorMin;
		_rect.anchorMax = anchorMax;
	}
}
