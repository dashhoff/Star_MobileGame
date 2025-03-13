using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Panel : MonoBehaviour
{
    [SerializeField] private Image _backgroud;
    [SerializeField] private GameObject _panel;

    [SerializeField] private float _openAlpha;

    [SerializeField] private float _openDuration;
    [SerializeField] private float _closeDuration;

    public void Open()
    {
        _backgroud.gameObject.SetActive(true);

        DOTween.Sequence()
            .SetUpdate(true)
            .Append(_backgroud.DOFade(_openAlpha, _openDuration))
            .OnComplete(() => 
            {
                //_panel.SetActive(true);
            });
    }

    public void Close()
    {
        //_panel.SetActive(false);

        DOTween.Sequence()
            .SetUpdate(true)
            .Append(_backgroud.DOFade(0, _closeDuration)).OnComplete(() =>
            {
                _backgroud.gameObject.SetActive(false);
            });
    }
}