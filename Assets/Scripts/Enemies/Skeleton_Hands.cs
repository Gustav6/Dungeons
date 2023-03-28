using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Hands : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;


    public Animator animator;

    private float distance;
    private bool isWalking;
    private bool isNotWalking;



    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
  
        if(distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }


        if (distance < distanceBetween)
        {
            isWalking = true;
            isNotWalking = false;
        }
        else
        {
            isWalking = false;
            isNotWalking = true;

        }
        animator.SetBool("IsWalking", isWalking);
        animator.SetBool("isNotWalking", isNotWalking);
    }
}
 