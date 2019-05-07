using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField]
    private State nextState;

    public abstract void Execute();

    private void SwitchToNextState()
    {
        Toggle(false);

        if (nextState != null)
        {
            nextState.Toggle(true);
        }
    }

    public void Toggle(bool val)
    {
        this.enabled = val;

        if (val)
        {
            Execute();
        }
    }
}