using UnityEngine;
using UnityEngine.AI;

public class MoveToDistance : Task
{
    [SerializeField]
    private float maxDistance = 100F;

    public override bool Execute()
    {
        bool result = true;

        if (TargetAI != null)
        {
            TargetAI.GetComponent<NavMeshAgent>().SetDestination(GetTargetPoint());
        }

        return result;
    }

    private Vector3 GetTargetPoint()
    {
        Vector3 dir = TargetAI.transform.position - Player.Instance.transform.position;
        Vector3 finalDir = dir + dir.normalized * maxDistance;

        Vector3 result = Player.Instance.transform.position + finalDir;

        return result;
    }
}