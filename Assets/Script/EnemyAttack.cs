using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;

    private float waitTime;
    public float startWaitTime;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    public void Attack()
    {
        //Play Attack Animation
        animator.SetTrigger("Attack");

        if (waitTime <= 0)
        {
            //Detect enemies in range of attack
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

            //Kill enemy 
            foreach (Collider2D player in hitPlayers)
            {
                player.GetComponent<Hitted>().GotHitted();
            }
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
