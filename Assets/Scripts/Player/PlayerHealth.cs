using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    public bool isDead;

    private Controller2D controller;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        health = maxHealth;
    }


    public void UpdateHealth(float mod)
    {

        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            health = 0f;
            Debug.Log("Player Respawn");
        }
    }

    public void Update()
    {
        if (health <= 0f)
        {
            isDead = true;
            animator.SetBool("IsDead", isDead);
        }

    }


}
