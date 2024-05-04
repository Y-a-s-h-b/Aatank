using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    public enum States { hide,run}
    public States currentState;
    private Animator animator;
    public bool isColliding;
    private Health health;
    private EnemyMovement enemyMovement;
    public int rayDistance;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        animator = GetComponent<Animator>();
        currentState = States.run;
        health = GetComponent<Health>();
        enemyMovement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CreateRay();
        if (health.CurrentHealth <= 0)
        {
            Debug.Log(health.CurrentHealth);
            
            this.enabled = false;
        }
        else
        {
            switch (currentState)
            {
                case States.hide:
                    animator.Play("Emoji_Cry");
                    break;
                case States.run:
                    animator.Play("Action_Run");
                    enemyMovement.enabled = true;
                    break;
            }
        }
    }
    void CreateRay()
    {
        Vector3 fwdDirection = Vector3.forward;
        Vector3 rayCastPosition = new Vector3(fwdDirection.x, 1, fwdDirection.z);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position + new Vector3(0,1,0), transform.TransformDirection(Vector3.forward), out hit, rayDistance, layer))
        {
            Debug.DrawRay(transform.position + new Vector3(0, 1, 0), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if(hit.collider != null) 
            {
                Debug.Log("Hiding");
                currentState = States.hide;
            }
            
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            currentState = States.run;
            Debug.Log("Did not Hit");
        }
    }
    /*private void OnTriggerStay(Collider other)
    {
        isColliding = true;
        if (other.CompareTag("Obstacles"))
        {
            currentState = States.hide;
        }
        else
        {
            currentState = States.run;
        }     
    }*/
    /*private void OnTriggerExit(Collider other)
    {
        isColliding = false;
        Debug.Log("AS");
        if (other.CompareTag("Obstacles"))
        {
            currentState = States.run;
        }
    }*/
}
