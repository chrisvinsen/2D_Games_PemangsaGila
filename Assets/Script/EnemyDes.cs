using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyDes : MonoBehaviour
{
    private enum State
    {
        Roaming,
        ChaseTarget,
        GoingBackToRoam,
        AttackMode,
    }
    [Header("Destination")]
    public AIDestinationSetter setter;
    public AIPath path;
    public Transform[] playerPosArr;
    public Transform[] waypoints;

    private float waitTime;
    [Header("TargetOption")]
    public float startWaitTime;
    public float targetRange;
    public float outOfRange;
    public float attackRange;

    [Header("Animator")]
    public Animator animator;
    public EnemyAttack enemyAttack;

    private Transform target;
    private int randomSpot;
    private State state;
    private Transform playerPos;

    private void Awake()
    {
        state = State.Roaming;
        if(PlayerPrefs.GetString("CharacterUsed") == "Male")
        {
            playerPos = playerPosArr[0];
        }
        else
        {
            playerPos = playerPosArr[1];
        }
         
    }

    private void Start()
    {
        waitTime = startWaitTime;
        setPatrolPosition();
    }
    private void Update()
    {
        switch (state)
        {
            default:
            case State.Roaming:
                //patrolling
                path.maxSpeed = 0.25f;
                if (Vector2.Distance(transform.position, target.position) < .2f)
                {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isRunning", false);
                    if (waitTime <= 0)
                    {
                        setPatrolPosition();
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
                FindTarget();
                break;
            case State.ChaseTarget:
                setter.target = playerPos.transform;
                path.maxSpeed = 0.3f;
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);

                if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y + 0.08f), playerPos.position) < attackRange)
                {
                    state = State.AttackMode;
                }

                if (Vector2.Distance(transform.position, playerPos.position) > outOfRange)
                {
                    //Too far, stop chasing
                    path.maxSpeed = 0.25f;
                    setPatrolPosition();
                    state = State.GoingBackToRoam;
                }
                break;
            case State.AttackMode:
                enemyAttack.Attack();
                if (Vector2.Distance(transform.position, playerPos.position) > attackRange)
                {
                    state = State.ChaseTarget;
                }
                break;
            case State.GoingBackToRoam:
                if (Vector2.Distance(transform.position, target.position) < .2f)
                {
                    state = State.Roaming;
                }
                FindTarget();
                break;
        }
    }

    public void setPatrolPosition()
    {
        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", false);
        randomSpot = Random.Range(0, waypoints.Length);
        target = waypoints[randomSpot].transform;
        setter.target = target;
    }

    public void FindTarget()
    {
        if (Vector2.Distance(transform.position, playerPos.position) < targetRange)
        {
            //Player within target range
            state = State.ChaseTarget;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, outOfRange);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + 0.08f), attackRange);
    }
}
