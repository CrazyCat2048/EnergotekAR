using UnityEngine;

public class RequestHandler : MonoBehaviour
{
    [Header("Numbers")]
    [SerializeField] private int _numberFoundWindow;
    
    [Header("References")]
    [SerializeField] private FoundFigures _foundFigures;
    [SerializeField] private WindowChanger _windowChanger;
    [SerializeField] private RectTransform _textMessage;

    public void ApplyRequest(string request)
    {
        bool isInit = _foundFigures.InitScrollPanel(request);

        if (isInit)
        {
            _windowChanger.Change(_numberFoundWindow);
            
            _foundFigures.CreateLinesForPanels();

            return;
        }    
        
        _textMessage.gameObject.SetActive(true);
    }
}
