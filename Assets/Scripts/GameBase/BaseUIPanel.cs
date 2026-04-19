using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class BaseUIPanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private bool _isShow = false;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        _isShow = false;
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    private void Update()
    {
        if (_isShow && canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime * 5f;
        }
        else if (!_isShow && canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= Time.deltaTime * 5f;
        }
    }

    public virtual void Show()
    {
        _isShow = true;
        canvasGroup.interactable = true;
    }

    public virtual void Hide()
    {
        _isShow = false;
        canvasGroup.interactable = false;
    }
}
