using System;
using UnityEngine;

public class ScrollLine : MonoBehaviour
{
    private WindowChanger _windowChanger;
    private ModelCard _leftCard;
    private ModelCard _rightCard;

    private bool _isInitialized = false;
    
    public void Init(ModelCard left, ModelCard right, WindowChanger menu)
    {
        _windowChanger = menu;

        _leftCard = Instantiate(left, transform);
        _rightCard = Instantiate(right, transform);

        SubscribeCards();

        _isInitialized = true;
    }

    private void SubscribeCards()
    {
        _leftCard.OnClicked += _windowChanger.LaunchModelViewer;
        _rightCard.OnClicked += _windowChanger.LaunchModelViewer;
    }

    private void OnEnable()
    {
        if(_isInitialized)
        {
            SubscribeCards();
        }
    }

    private void OnDisable()
    {
        _leftCard.OnClicked -= _windowChanger.LaunchModelViewer;
        _rightCard.OnClicked -= _windowChanger.LaunchModelViewer;
    }
}
