using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ModelWithAnimator : MonoBehaviour
{
    [Header("Rotation Parameters")]
    [SerializeField] private string _nameOpenCloseAnimation = "IsOpen";
    
    private Animator _animator;

    private bool _modelIsOpened = false;

	private void Awake()
	{
        _animator = GetComponent<Animator>();
    }
    
    public void SelectAnimation()
    {
        if (CheckAnimationsOnWork())
            return;
        
        _modelIsOpened = !_modelIsOpened;

        _animator.SetBool(_nameOpenCloseAnimation, _modelIsOpened);
    }

    private bool CheckAnimationsOnWork()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_nameOpenCloseAnimation))
            return true;

        return false;
    }
}