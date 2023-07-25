using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button), typeof(Image))]
public class SearchButtonUI : MonoBehaviour
{
	[Header("Refrences")]
	[SerializeField] private RequestHandler _requestHandler;
	[SerializeField] private TMP_InputField _inputField;
	[SerializeField] private RectTransform _textMessage;

	[Header("Colors")]
	[SerializeField] private Color _standartColor;
	[SerializeField] private Color _blockColor;

	private Button _button;
	private Image _image;

	private string _request;

	private void Awake()
	{
		_button = GetComponent<Button>();
		_image = GetComponent<Image>();
	}

	private void OnEnable()
	{
		_inputField.onValueChanged.AddListener(ValueChanged); 
		_inputField.onDeselect.AddListener(Deselected); 
		_inputField.onSelect.AddListener(HideTextMessage);
		
		_button.onClick.AddListener(SendRequest);
	}

	private void Start()
	{
		DisableAndHide();
	}

	private void ValueChanged(string request)
	{
		if (string.IsNullOrWhiteSpace(request))
		{
			DisableAndHide();
			
			return;
		}

		_image.color = _standartColor;

		_button.interactable = true;

		_request = request;
	}

	private void DisableAndHide()
	{
		_image.color = _blockColor;

		_button.interactable = false;
	}

	private void Deselected(string request)
	{
		_request = request;
		
		_button.onClick?.Invoke();
		
		SendRequest();
	}

	private void SendRequest()
	{
		if (!_button.interactable)
			return;
		
		_requestHandler.ApplyRequest(_request);
	}

	private void HideTextMessage(string text)
	{
		if (!_textMessage.gameObject.activeSelf)
			return;
		
		_textMessage.gameObject.SetActive(false);
	}
}
