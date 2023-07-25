using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(CanvasGroup))]
public class CharacteristicsButtonUI : MonoBehaviour
{
	[Header("Refrences On Components")]
	[SerializeField] private OpenURLInBrowser _openURL;

	private Button _button;
	private CanvasGroup _canvasGroup;

	private string _requere;

	private void Awake()
	{
		_button = GetComponent<Button>();
		_canvasGroup = GetComponent<CanvasGroup>();
	}

	private void OnEnable()
	{
		_button.onClick.AddListener(delegate { _openURL.OpenUrl(_requere); });
	}

	public void Activate(string urlRequere)
	{
		_canvasGroup.interactable = true;
		_canvasGroup.alpha = 1;

		_requere = urlRequere;
	}

	public void Diactivate()
	{
		_canvasGroup.interactable = false;
		_canvasGroup.alpha = 0;
	}

	private void OnDisable()
	{
		_button.onClick.RemoveListener(delegate { _openURL.OpenUrl(_requere); });
	}
}
