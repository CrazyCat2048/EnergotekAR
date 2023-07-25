using UnityEngine;

public class OpenURLInBrowser : MonoBehaviour
{
    public void OpenUrl(string urlAdress)
    {
        Application.OpenURL(urlAdress);
    }
}
