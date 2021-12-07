using UnityEngine;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    private string _identifier;
    private Sprite _sprite;
    private GameObject _content;
    private ParticleSystem _FX;

    private void Awake()
    {
        _content = transform.GetChild(0).gameObject;
        _FX = GetComponentInChildren<ParticleSystem>();
        StartigTween();
    }

    public void SetCellIdentifier(string identifier)
    {
        _identifier = identifier;
        gameObject.name = _identifier;
    }

    public void SetCellSprite(Sprite sprite)
    {
        _sprite = sprite;
        _content.GetComponent<SpriteRenderer>().sprite = _sprite;
    }

    public void ClickBounce()
    {
        _content.transform.DOMoveX(_content.transform.position.x + 0.1f, 0.3f).SetEase(Ease.InElastic).SetLoops(2,LoopType.Yoyo);
    }

    public void PlayFX()
    {
        _FX.Play();
    }

    public void StartigTween()
    {
        transform.DOScale(0, 0);
        transform.DOScale(1, 1.5f).SetEase(Ease.InBounce);
    }

}
