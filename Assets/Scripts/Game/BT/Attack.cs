public class Attack : Task
{
    public override bool Execute()
    {
        bool result = true;

        if (TargetAI != null)
        {
            AICharacter ai = TargetAI.GetComponent<AICharacter>();

            if (ai)
            {
                ai.Attack();
            }
        }

        return result;
    }
}