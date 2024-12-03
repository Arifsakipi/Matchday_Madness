namespace MatchdayMadness2.Domain
{
    public interface IUpdatableRow
    {
        IRow AsReadOnly();
        void Set(string v1, string v2);
        void Set(string v1, long v2);
    }
}