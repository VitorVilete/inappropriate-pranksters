using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBarSlider;
    private float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        healthBarSlider.value = maxHealth;
    }


}
