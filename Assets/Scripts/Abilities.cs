using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Abilities : MonoBehaviour
{
    [Header("Abilities 1")]
    public Image abilityImage1;
    public float cooldown1 = 5f;
    bool isCooldown1 = false;
    public KeyCode ability1;

    //ability1 input variables
    Vector3 position;
    public Canvas ability1Canvas;
    public Image skillshot;
    public Transform player;

    [Header("Abilities 2")]
    public Image abilityImage2;
    public float cooldown2 = 10f;
    bool isCooldown2 = false;
    public KeyCode ability2;

    //ability2 input variables
    public Image targetCircle;
    public Image indicatorRangeCircle;
    public Canvas ability2Canvas;
    Vector3 posUp;
    public float maxAbility2Distance;

    [Header("Abilities 3")]
    public Image abilityImage3;
    public float cooldown3 = 15f;
    bool isCooldown3 = false;
    public KeyCode ability3;
    void Start()
    {

        
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        skillshot.GetComponent<Image>().enabled = false;
        targetCircle.GetComponent<Image>().enabled = false;
        indicatorRangeCircle.GetComponent<Image>().enabled = false;
        
    }
    
  
    void Update()
    {
        Ability1();
        Ability2();
        Ability3();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //ability1 input
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
        //ability2 input
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject != this.gameObject) {
                posUp = new Vector3(hit.point.x, 2f, hit.point.z);
                position = hit.point;
                
            }
        }

        //ability1 Canvas input
        Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
        ability1Canvas.transform.rotation = Quaternion.Lerp(transRot, ability1Canvas.transform.rotation, 0f);
        //ability2 Canvas input
        var hitPosDir = (posUp - transform.position).normalized;
        float distance = Vector3.Distance(posUp, transform.position);
        distance = Mathf.Min(distance, maxAbility2Distance);

        var newHitPos = transform.position + hitPosDir * distance;
        ability2Canvas.transform.position = (newHitPos);


    }

    private void Ability1()
    {
        if (Input.GetKey(ability1) && isCooldown1 == false)
        {
            skillshot.GetComponent<Image>().enabled = true;

            //disable other UI
            indicatorRangeCircle.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;

        }
        if (skillshot.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0))
        {

            isCooldown1 = true;
            abilityImage1.fillAmount = 1;
        }

        if (isCooldown1)
        {

            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            skillshot.GetComponent<Image>().enabled = false;
            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown1 = false;
            }
        }
        //if (Input.GetKey(ability1) && isCooldown1 == false)
        //{
        //    skillshot.GetComponent<Image>().enabled = true;

        //    //Disable Other UI
        //    indicatorRangeCircle.GetComponent<Image>().enabled = false;
        //    targetCircle.GetComponent<Image>().enabled = false;
        //}

        //if (skillshot.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0))
        //{
        //    isCooldown1 = true;
        //    abilityImage1.fillAmount = 1;
        //}

        //if (isCooldown1)
        //{
        //    abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
        //    skillshot.GetComponent<Image>().enabled = false;

        //    if (abilityImage1.fillAmount <= 0)
        //    {
        //        abilityImage1.fillAmount = 0;
        //        isCooldown1 = false;
        //    }
        //}
    }
    private void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false)
        {
            targetCircle.GetComponent<Image>().enabled = true;
            indicatorRangeCircle.GetComponent<Image>().enabled = true;
            //disable other UI
            skillshot.GetComponent<Image>().enabled = false;
            
        }
        if (targetCircle.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0))
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }
        if (isCooldown2)
        {
            targetCircle.GetComponent<Image>().enabled = false;
            indicatorRangeCircle.GetComponent<Image>().enabled = false;
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }
    private void Ability3()
    {
        if (Input.GetKey(ability3) && !isCooldown3)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
        }
        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;
            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }
}
