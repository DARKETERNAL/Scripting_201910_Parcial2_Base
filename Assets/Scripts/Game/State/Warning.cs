public class Warning : State
{
    private bool running;

    public override void Execute()
    {
        this.enabled = true;
    }

    private void Awake()
    {
        enabled = false;
    }

    private void Update()
    {
        transform.LookAt(Player.Instance.transform);
    }
}