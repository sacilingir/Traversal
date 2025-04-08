namespace TraversalCoreProject.CQRS.Queries.DestinationResults
{
    public class GetDestinationByIDQuery
    {
        public GetDestinationByIDQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
