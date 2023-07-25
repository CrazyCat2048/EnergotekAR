using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ModelCard : MonoBehaviour
{
    [SerializeField] private string _name;

    public string Name => _name;
    
    public event Action<string> OnClicked;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        OnClicked?.Invoke(_name);
    }
	
    private void OnDisable()
    {
        _button.onClick.RemoveListener(Clicked);
    }
}
