using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float pulseScale = 1.1f;
    public float pulseDuration = 0.3f;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartPulse();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetScale();
    }

    private void StartPulse()
    {
        transform.DOScale(pulseScale, pulseDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void ResetScale()
    {
        transform.DOKill();
        transform.DOScale(originalScale, pulseDuration).SetEase(Ease.OutQuad);
    }
}