using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float stoppingDistance = 2f;
    public float movementSpeed = 5f;

    private NavMeshAgent agent;
    private Animator animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (agent.enabled)
        {
            // Hedefi belirle
            agent.SetDestination(target.position);

            // Mesafeye göre animasyon değiştir
            if (agent.remainingDistance > stoppingDistance)
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdle", false);
            }
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", true);
            }
        }
    }
}