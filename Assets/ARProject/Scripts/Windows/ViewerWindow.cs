using UnityEngine;
using UnityEngine.UI;

public class ViewerWindow : MonoBehaviour
{
    [Header("Refrences On Components")]
    [SerializeField] private Button _animationButton;
    [SerializeField] private CharacteristicsButtonUI _characteristicksButton;
    [SerializeField] private CanvasGroup _clearButton;
    
	public void ActivateMenu(string url)
    {
        _characteristicksButton.Activate(url);
    }

    public Button ActivateAnimationButton()
    {
        _animationButton.interactable = true;
        
        if(_clearButton)
            _clearButton.alpha = 1;

        return _animationButton;
    }

    public void DiactivateMenu()
    {
        _characteristicksButton.Diactivate();

        _animationButton.interactable = false;
        
        if(_clearButton)
            _clearButton.alpha = 0;
    }
}
