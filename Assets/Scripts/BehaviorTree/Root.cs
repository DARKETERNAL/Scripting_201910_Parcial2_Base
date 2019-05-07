using UnityEngine;

public class Root : Node
{
    [SerializeField]
    private Composite child;

    private void Awake()
    {
        if (child != null)
        {
            child.SetTargetAI(this.TargetAI);
        }
        else
        {
            print(string.Format("{0}'s child is null", gameObject.name));
        }
    }

    public override bool Execute()
    {
        bool result = true;

        if (child != null)
        {
            result = child.Execute();
        }

        return result;
    }
}