using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTargeting : MonoBehaviour
{
    public GameObject selectedHero;
    public bool heroPlayer;
    RaycastHit hit;
    void Start()
    {
        selectedHero = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Minion targeting
        if (Input.GetMouseButton(1)) {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)) {
                //if the minion is targetable
                if (hit.collider.GetComponent<Targetable>() != null)
                {
                    if (hit.collider.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
                    {
                        selectedHero.GetComponent<HeroCombat>().targetedEnemy = hit.collider.gameObject;
                       
                    }
                }
                else if (hit.collider.GetComponent<Targetable>() == null) {
                    selectedHero.GetComponent<HeroCombat>().targetedEnemy = null;
                }
            }
        }
    }
}
