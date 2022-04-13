using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCombat : MonoBehaviour
{
    public enum HeroAttackType { Melee, Ranged};
    public HeroAttackType heroAttackType;
    public GameObject targetedEnemy;

    public float attackRange;
    public float rotateSpeedForAttack;

    Movement moveScript;
    Stats statsScript;
    Animator anim;
    public bool attackIdle = false;
    public bool isHeroAlive;
    public bool performMeleeAttack = true;
    void Start()
    {
        moveScript = GetComponent<Movement>();
        statsScript = GetComponent<Stats>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetedEnemy != null)
        {
            if (Vector3.Distance(transform.position, targetedEnemy.transform.position) > attackRange)
            {
                moveScript.agent.SetDestination(targetedEnemy.transform.position);
                moveScript.agent.stoppingDistance = (attackRange);

                //Rotation
                Quaternion rotationLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationLookAt.eulerAngles.y,
                    ref moveScript.rotateVelocity, rotateSpeedForAttack * (Time.deltaTime * 5));
                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
            else
            {
                if (heroAttackType == HeroAttackType.Melee)
                {
                    if (performMeleeAttack)
                    {
                        Debug.Log("Melee the Minion");
                        //start coroutine to attack
                        StartCoroutine(MeleeAttackInterval());
                    }
                }
            }
        }
        
    }

    IEnumerator MeleeAttackInterval()
    {
        performMeleeAttack = false;
        anim.SetBool("Basic Attack", true);
        yield return new WaitForSeconds(statsScript.attackTime / (100 + statsScript.attackTime) * 0.01f);
        if (targetedEnemy == null) {
            anim.SetBool("Basic Attack", false);
            performMeleeAttack = true;
        }

    }
    public void MeleeAttack() {
        if (targetedEnemy != null) {
            if (targetedEnemy.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion) {
                targetedEnemy.GetComponent<Stats>().health -= statsScript.attackDmg;
            }
        }
        performMeleeAttack = true;
    }
}
