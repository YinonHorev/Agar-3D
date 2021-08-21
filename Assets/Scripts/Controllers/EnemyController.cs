using UnityEngine;
using UnityEngine.AI;

/* Makes enemies follow and attack the player */

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.Player.transform; // We dont want to referance every enemy to the Player
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Get the distance to the player
        float distance = Vector3.Distance(target.position, transform.position);

        // If inside the radius
        if (distance <= lookRadius)
        {
            // Move towards the player
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    // Point towards the player
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}