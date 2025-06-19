using UnityEngine;

public class TitleAnimator : MonoBehaviour
{
    public Transform titleTransform;
    public AnimationCurve scaleCurve;
    public float animationDuration = 2f;

    private Vector3 originalScale;
    private float elapsedTime;

    private void Start()
    {
        originalScale = titleTransform.localScale;
        titleTransform.localScale = originalScale * scaleCurve.Evaluate(0);
    }

    private void Update()
    {
        if (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animationDuration;

            float scaleFactor = scaleCurve.Evaluate(t);
            titleTransform.localScale = originalScale * scaleFactor;
        }
    }
}