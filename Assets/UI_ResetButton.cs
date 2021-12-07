using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_ResetButton : MonoBehaviour
{
    private Button _restartButton;
    [SerializeField] Image _restartBG;
    private void Awake()
    {
        _restartButton = GetComponentInChildren<Button>();
        HideRestartButton();
    }

    public void ShowRestartScreen()
    {
        _restartButton.gameObject.SetActive(true);
        _restartBG.DOFade(0.75f, 4f);
    }

    public void HideRestartButton()
    {
        _restartButton.gameObject.SetActive(false);
        _restartBG.DOComplete();
        _restartBG.DOFade(0, 0);
    }
}
