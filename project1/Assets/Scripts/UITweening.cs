using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UITweening : MonoBehaviour
{
    public bool changeColor;
    public bool changeSize;
    public bool fade;
    Image image;
    CanvasGroup title;

    private void Start()
    {
        if (fade)
        {
            title = this.GetComponent<CanvasGroup>();
            title.alpha = 0f;
            title.DOFade(1f, 0.8f).SetEase(Ease.InQuint);
        }
        if (changeSize)
        {
            AnimateButton();
        }
        if (changeColor)
        {
            image = this.GetComponent<Image>();
        }
    }

    private void Update()
    {
        if (changeColor) 
        {
            Invoke(() => colorChange(), 1f);
        }
    }
    void AnimateButton()
    {
        this.transform.localScale = Vector3.zero;
        Invoke(() => this.transform.DOScale(1f, 0.3f), 0.1f);
    }

    void colorChange()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        image.DOColor(color, 0.5f);
    }

    Coroutine Invoke(System.Action action, float duration)
    {
        return StartCoroutine(InvokeAfterTime(action, duration));
    }

    IEnumerator InvokeAfterTime(System.Action action, float duration)
    {
        yield return new WaitForSeconds(duration);
        action?.Invoke();
    }
}
