using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LinePipeUI : MonoBehaviour
{
	public event Action<ModelData> OnClicked;
	
	private ModelData _modelData;
	private Button _button;
	private TextMeshProUGUI _name;

	private void Awake()
	{
		_button = GetComponent<Button>();
		_name = GetComponentInChildren<TextMeshProUGUI>();
	}

	public void Init(ModelData model)
	{
		_name.text = model.Name;

		_modelData = model;
		
		_button.onClick.AddListener(Clicked);
	}

	private void Clicked()
	{
		OnClicked?.Invoke(_modelData);
	}
	
	private void OnDisable()
	{
		_button.onClick.RemoveListener(Clicked);
	}
}
