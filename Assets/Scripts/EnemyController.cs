using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public bool chasing;
    public float distanceToChase = 10f;
    public float distanceToLose = 15f;
    public float distanceToStop = 2f;

    private Vector3 targetPoint, startPoint;

    public NavMeshAgent navAgent;

    public float keepChasingTime = 5f;
    private float chaseCounter;

    public GameObject bullet;
    public Transform firePoint;

    public float fireRate, waitBetweenShots = 2f, timeToShoot = 1f;
    private float fireCount, shotWaitCounter, shootTimeCounter;


    public Animator anim;

    void Start()
    {
        startPoint = transform.position;

        shootTimeCounter = timeToShoot;
        shotWaitCounter = waitBetweenShots; 
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = PlayerControlller.instance.transform.position;
        //targetPoint.y = transform.position.y;

        if (!chasing)
        {
            if (Vector3.Distance(transform.position, PlayerControlller.instance.transform.position) < distanceToChase)
            {
                chasing = true;

                shootTimeCounter = timeToShoot;
                shotWaitCounter = waitBetweenShots;
            }

            if (chaseCounter > 0)
            {
                chaseCounter -= Time.deltaTime;

                if (chaseCounter < 0)
                {
                    navAgent.destination = startPoint;
                }
            }

            if(navAgent.remainingDistance < 0.25f)
            {
                anim.SetBool("isMoving", false);
            }
            else
            {
                anim.SetBool("isMoving", true);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, targetPoint) > distanceToStop)
            {
                navAgent.destination = targetPoint;
            }
            else
            {
                navAgent.destination = transform.position;
            }

            if (Vector3.Distance(transform.position, PlayerControlller.instance.transform.position) > distanceToLose)
            {
                chasing = false;

                chaseCounter = keepChasingTime;
            }

            if (shotWaitCounter > 0)
            {
                shotWaitCounter -= Time.deltaTime;

                if(shotWaitCounter <= 0)
                {
                    shootTimeCounter = timeToShoot;
                }
                anim.SetBool("isMoving", true);
            }
            else
            {
                if (PlayerControlller.instance.gameObject.activeInHierarchy)
                {


                    shootTimeCounter -= Time.deltaTime;

                    if (shootTimeCounter > 0)
                    {
                        fireCount -= Time.deltaTime;

                        if (fireCount <= 0)
                        {
                            fireCount = fireRate;

                            firePoint.LookAt(PlayerControlller.instance.transform.position + new Vector3(0f, 1.5f, 0f));

                            //Check the angle

                            Vector3 targetDirection = PlayerControlller.instance.transform.position - transform.position;
                            float angle = Vector3.SignedAngle(targetDirection, transform.forward, Vector3.up);

                            if (Mathf.Abs(angle) < 30)
                            {
                                Instantiate(bullet, firePoint.position, firePoint.rotation);

                                anim.SetTrigger("fireShot");
                            }
                            else
                            {
                                shotWaitCounter = waitBetweenShots;
                            }
                        }
                        navAgent.destination = transform.position;
                    }
                    else
                    {
                        shotWaitCounter = waitBetweenShots;
                    }
                }
                anim.SetBool("isMoving", false);
            }
        } 
    }
}
