using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class sizeAnimator : MonoBehaviour
{
    public bool isUsingRect = false;
    public Vector3 sizeToAdd = Vector3.one*2;
    public float timeToMax = 0.1f, timeToNormal = 0.4f;
    public Ease maxEase, normalEase;


    private Vector3 defaultSize;
    private Sequence sequence;

    private void Awake()
    {
        defaultSize = transform.localScale;
    }

    public void AnimateSize()
    {
        sequence = DOTween.Sequence();
        if (!isUsingRect)
        {
            sequence.Append(transform.DOScale(defaultSize + sizeToAdd, timeToNormal).SetEase(maxEase))
                .Append(transform.DOScale(defaultSize, timeToNormal).SetEase(normalEase));
        }
        else
        {
            var rect = GetComponent<RectTransform>();
            sequence.Append(DOTween.To(() => rect.localScale, x => rect.localScale = x, defaultSize + sizeToAdd, timeToMax).SetEase(maxEase))
                    .Append(DOTween.To(() => rect.localScale, x => rect.localScale = x, defaultSize, timeToNormal).SetEase(normalEase));
        }
    }

}
