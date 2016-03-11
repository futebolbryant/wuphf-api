using Models;

namespace Services
{
    public class AsyncMessageRepository : MongoRepository<Message>, IAsyncRepository<Message>
    {
        public override string GetCollectionName()
        {
            return "messages";
        }              
    }
}
