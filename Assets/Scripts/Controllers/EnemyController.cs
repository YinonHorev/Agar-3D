using UnityEngine;
using UnityEngine.AI;

/* Makes enemies follow and attack the player */

public class EnemyController : CharecterController
{

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    private float m_MainPlayerSize;

    new void Start()
    {
        base.Start();
        target = PlayerManager.instance.Player.transform; // We dont want to referance every enemy to the Player
        agent = GetComponent<NavMeshAgent>();
        m_MainPlayerSize = PlayerManager.instance.Player.GetComponent<Transform>().localScale.x;
        m_BlobStat.AddSize(m_MainPlayerSize + Random.Range(-m_MainPlayerSize, 2 * m_MainPlayerSize));
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

    private new void FixedUpdate()
    {
        base.FixedUpdate();
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