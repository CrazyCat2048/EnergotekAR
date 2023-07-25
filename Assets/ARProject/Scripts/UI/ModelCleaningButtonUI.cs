using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup), typeof(Button))]
public class ModelCleaningButtonUI : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private Button _button;

	private void Awake()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
		_button = GetComponent<Button>();
	}

	private void Start()
	{
		Diactivate();
	}

	public void Activate(ModelSpawner spawner)
	{
		_button.onClick.AddListener(spawner.ClearWindow);
		_button.onClick.AddListener(Diactivate);

		_canvasGroup.alpha = 1;
		_canvasGroup.interactable = true;
	}

	public void Diactivate()
	{
		_canvasGroup.alpha = 0;
		_canvasGroup.interactable = false;
	}

	private void OnEnable()
	{
		_button.onClick.RemoveAllListeners();
	}
}
