using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UI_LoadingScree : MonoBehaviour
{
    private EventsHandler _events;
    [SerializeField] private Image _loadScreen;

    private void Awake()
    {
        _events = GetComponentInParent<EventsHandler>();
    }

    private void RestartGame()
    {
        _events.RestartGame();
    }

    public void FakeLoadingScreen()
    {
        _loadScreen.DOFade(1, 1.5f).OnComplete(FadeOut);
    }

    private void FadeOut()
    {
        _events.RestartGame();
        _loadScreen.DOComplete();
        _loadScreen.DOFade(0, 1.5f).OnComplete(DisableLoadScreen);
    }

    private void DisableLoadScreen()
    {
        _loadScreen.gameObject.SetActive(false);
    }
}
