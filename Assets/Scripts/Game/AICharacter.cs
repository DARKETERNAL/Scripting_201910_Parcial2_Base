using UnityEngine;

public class AICharacter : Character
{
    [SerializeField]
    private float warningDistance = 50F;

    [SerializeField]
    private float actDistance = 10F;

    [SerializeField]
    protected bool stopStateCheck = false;

    private State currentState;

    private State actStateComponent;
    private State warningStateComponent;
    private State idleStateComponent;

    public void SetNewState(State newState)
    {
        currentState = newState;
    }

    public void Attack()
    {
        SpawnBullet();
    }

    protected override void Start()
    {
        base.Start();

        warningStateComponent = GetComponent<Warning>();
        idleStateComponent = GetComponent<Idle>();
        actStateComponent = GetComponent<RunBT>();

        SetNewState(idleStateComponent);

        InvokeRepeating("CheckState", 0F, 0.1F);
    }

    protected bool DistanceInRange(float distanceToPlayer, float min, float max)
    {
        return min <= distanceToPlayer && distanceToPlayer <= max;
    }

    protected void CheckState()
    {
        float distanceToPlayer = (Player.Instance.transform.position - transform.position).magnitude;

        //print(string.Format("Distance to player: {0}", distanceToPlayer));

        if (distanceToPlayer <= actDistance && currentState != actStateComponent)
        {
            //print("Changed to act state");
            SwitchToState(actStateComponent);

            if (stopStateCheck)
            {
                CancelInvoke();
            }
        }
        else if (DistanceInRange(distanceToPlayer, actDistance, warningDistance) && currentState != warningStateComponent)
        {
            print("Changed to warning state");
            SwitchToState(warningStateComponent);
        }
        else if (distanceToPlayer > warningDistance && currentState != idleStateComponent)
        {
            //print("Changed to idle state");
            SwitchToState(idleStateComponent);
        }
    }

    private void SwitchToState(State newState)
    {
        currentState.Toggle(false);
        SetNewState(newState);
        currentState.Execute();
    }
}