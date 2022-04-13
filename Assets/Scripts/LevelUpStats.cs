using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelUpStats : MonoBehaviour
{
    public int level = 1;
    public float experince { get; private set; }
    public Text lvlText;
    public Image expBarImage;

    public static int ExpNeedToLvlUp(int currentLvl) {
        if (currentLvl == 0) return 0;
        return(currentLvl + currentLvl*currentLvl) * 5;
    }
    public void SetExperience(float exp) {
        experince += exp;
        float expNeeded = ExpNeedToLvlUp(level);
        float previousExperience = ExpNeedToLvlUp(level - 1);
        //level up
        if (experince >= expNeeded) {
            LevelUp();
            expNeeded = ExpNeedToLvlUp(level);
            previousExperience = ExpNeedToLvlUp(level - 1);
        }
        //Fill exp bar image with exp
        expBarImage.fillAmount = (experince - previousExperience) / (expNeeded - previousExperience);
        //reset the fill bar
        if (expBarImage.fillAmount == 1) {
            expBarImage.fillAmount = 0;

        }
    }

    public void LevelUp()
    {
        level++;
        lvlText.text = level.ToString("");
    }
}
