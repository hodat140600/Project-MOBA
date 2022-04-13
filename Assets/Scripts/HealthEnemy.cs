using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthEnemy : MonoBehaviour
{
    public Slider healthSlider3D;
    
    Stats statsScript;
    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Stats>();
        
        healthSlider3D.maxValue = statsScript.maxHealth;
        
        statsScript.health = statsScript.maxHealth;
    }


    void Update()
    {
        healthSlider3D.value = statsScript.health;
        
    }
}
