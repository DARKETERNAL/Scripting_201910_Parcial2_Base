using UnityEngine.AI;

public class DoKamikazeAttack : Task
{
    public override bool Execute()
    {
        bool result = true;

        if (TargetAI != null)
        {
            while (true)
            {
                TargetAI.GetComponent<NavMeshAgent>().SetDestination(Player.Instance.transform.position);
            } 
        }

        return result;
    }
}