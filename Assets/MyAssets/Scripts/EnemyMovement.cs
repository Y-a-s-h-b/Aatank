using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    public Transform[] targetPositions;
    public int moveSpeed;// Array to hold the target positions
    private Health health;
    [SerializeField] private float walkPointRange;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] NavMeshAgent agent;
    private bool walkPointSet = false;
    private Vector3 walkPoint;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
    }
    void Update()
    {
        
        Debug.Log(health.CurrentHealth);
        if (health.CurrentHealth <= 0)
        {

            Destroy(this);
        }
        else
        {
            Patrolling();
        }
    }
    void Patrolling()
    {
        Debug.Log("patrolling ");
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet && health.CurrentHealth >= 0)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    /*private void MoveBetweenRandomPositions()
    {
        while (false)
        {
            // Choose two random target positions
            int randomIndex1 = Random.Range(0, targetPositions.Length);
            int randomIndex2 = Random.Range(0, targetPositions.Length);

            // Make sure the two random indices are not the same
            while (randomIndex2 == randomIndex1)
            {
                randomIndex2 = Random.Range(0, targetPositions.Length);
            }

            // Move to the first random position
            MoveTo(targetPositions[randomIndex1].position);

            // Wait for a short delay before moving to the next position
            //yield return new WaitForSeconds(0.0f);

            // Move to the second random position
            MoveTo(targetPositions[randomIndex2].position);

            // Wait for a short delay before starting the loop again
            //yield return new WaitForSeconds(0.0f);
        }
    }

    private IEnumerator MoveTo(Vector3 targetPosition)
    {
        // Move the GameObject smoothly towards the target position
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
            transform.LookAt(targetPosition);
            yield return null;
        }
    }*/
}
