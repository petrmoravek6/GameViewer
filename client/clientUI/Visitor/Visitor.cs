namespace clientUI.Model
{
    public interface Visitor<T>
    {
        T VisitTeam(Team team);
        T VisitMatch(Match match);
        T VisitPlayer(Player player);
    }
}