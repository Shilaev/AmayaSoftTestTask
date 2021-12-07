using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_TargetText : MonoBehaviour
{
    private Text _targetText;

    private void Awake()
    {
        _targetText = GetComponentInChildren<Text>();
        _targetText.DOFade(0, 0);
    }

    public void SetTargetText(string targetString)
    {
        _targetText.text = string.Format("Find \"{0}\"", targetString);
    }

    public void FadeIn()
    {
        _targetText.DOFade(1, 2);
    }

    
}
