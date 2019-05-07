using UnityEngine;
using UnityEngine.AI;

public class FleeFromPlayer : Task
{
    [SerializeField]
    private float distanceToFlee;

    public override bool Execute()
    {
        bool result = true;

        if (TargetAI != null)
        {
            TargetAI.GetComponent<NavMeshAgent>().SetDestination(TargetAI.transform.position + Random.insideUnitSphere * distanceToFlee);
        }

        return result;
    }
}