using UnityEngine;

public class IsPlayerNear : Selector
{
    [SerializeField]
    private float maxDistance = 100F;

    protected override bool CheckCondition()
    {
        return TargetAI == null ?
            false :
            (TargetAI.transform.position - Player.Instance.transform.position).magnitude <= maxDistance;
    }
}