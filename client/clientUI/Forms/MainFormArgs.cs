namespace clientUI;

public class MainFormArgs : EventArgs
{
    public readonly uint TeamClickedCnt;

    public MainFormArgs(uint teamClickedCnt)
    {
        TeamClickedCnt = teamClickedCnt;
    }
}
