using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PromptWindowUI : MonoBehaviour
{
	private CanvasGroup _canvasGroup;

	private void Awake()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
	}

	public void OpenWindow()
	{
		if (PlayerPrefs.GetString("FirstLoad") != "FirstLoad")
		{
			_canvasGroup.alpha = 1;

			PlayerPrefs.SetString("FirstLoad", "FirstLoad");
		}
		else
		{
			CloseWindow();
		}
	}

	public void CloseWindow()
	{
		_canvasGroup.alpha = 0;
		_canvasGroup.interactable = false;
		_canvasGroup.blocksRaycasts = false;
	}
}
