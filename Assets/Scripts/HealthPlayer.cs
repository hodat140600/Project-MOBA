using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthPlayer : MonoBehaviour
{
    public Slider healthSlider3D;
    Slider healthSlider2D;
    Stats statsScript;
    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        healthSlider2D = gameObject.GetComponent<Slider>();
        healthSlider3D.maxValue = statsScript.maxHealth;
        healthSlider2D.maxValue = statsScript.maxHealth;
        statsScript.health = statsScript.maxHealth;
    }


    void Update()
    {
        healthSlider2D.value = statsScript.health;
        healthSlider3D.value = healthSlider2D.value;
    }
}
