using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarItem : MonoBehaviour
{
    private Image currentHealth;

    public void Initialize()
    {
        currentHealth = transform.Find("Image").GetComponent<Image>();
        currentHealth.fillAmount = 1f;
    }

    public void SetHealth(float healthPercent)
    {
        currentHealth.fillAmount = healthPercent;
    }
}
