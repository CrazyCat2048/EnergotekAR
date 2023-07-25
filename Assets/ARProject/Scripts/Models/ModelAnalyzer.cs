using UnityEngine;
using UnityEngine.UI;

public class ModelAnalyzer : MonoBehaviour
{
    [Header("References To Menu")]
    [SerializeField] private ViewerWindow _viewerMenu;

    public void Analyze(Model model)
    {
        ModelWithAnimator animatedModel;

        if (model.TryGetComponent(out animatedModel))
        {
            Button button = _viewerMenu.ActivateAnimationButton();
            
            button.onClick.AddListener(animatedModel.SelectAnimation);
        }
    }
}
