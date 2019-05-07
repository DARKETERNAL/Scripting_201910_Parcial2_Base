using UnityEngine;

public class RunBT : State
{
    [SerializeField]
    private readonly float tickRate;

    [SerializeField]
    protected Root btRoot;

    public override void Execute()
    {
        if (btRoot != null)
        {
            InvokeRepeating("StartBT", 0F, tickRate);
        }
    }

    private void StartBT()
    {
        btRoot.Execute();
    }
}