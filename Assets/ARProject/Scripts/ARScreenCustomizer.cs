using UnityEngine;

public class ARScreenCustomizer : MonoBehaviour
{
    [Header("Screens Components")]
    [SerializeField] private SafeAreaUniversal _safeArea;
    [SerializeField] protected ScreenOrientionChanger orientionChanger;

    protected virtual void OnEnable()
    {
        orientionChanger.OnChanged += _safeArea.UpdateArea;
    }

    private void Start()
    {
        orientionChanger.Initialize();
        _safeArea.UpdateArea();
    }
    
    protected virtual void OnDisable()
    {
        orientionChanger.OnChanged += _safeArea.UpdateArea;
    }
}
