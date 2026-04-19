using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProcessBarItem : MonoBehaviour
{
    private Image currentProcess;
    private Coroutine processCoroutine;

    public void Initialize()
    {
        currentProcess = transform.Find("Image").GetComponent<Image>();
        currentProcess.fillAmount = 1f;
    }

    public void UpdateProcess(float processPercent)
    {
        currentProcess.fillAmount = processPercent;
    }

    public void LunchProcess(float time, Action? onCompletedProcess)
    {
        if (processCoroutine != null)
        {
            StopCoroutine(processCoroutine);
        }

        currentProcess.fillAmount = 1f;
        processCoroutine = StartCoroutine(ProcessCoroutine(time, onCompletedProcess));
    }

    private IEnumerator ProcessCoroutine(float time, Action? onCompletedProcess)
    {
        float currentTime = time;
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            currentProcess.fillAmount = Mathf.Clamp01(currentTime / time);
            yield return null;
        }
        currentProcess.fillAmount = 0f;
        onCompletedProcess?.Invoke();
    }
}
