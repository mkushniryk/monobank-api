using Sentinelab.Monobank.Api.Abstract;
using Sentinelab.Monobank.Api.Concrete;

namespace Sentinelab.Monobank.Api
{
    public class MonobankApi
    {
        public IMonoPublicClient PublicClient { get; }
        public IMonoPersonalClient PersonalClient { get; }

        public MonobankApi()
        {
            PublicClient = new MonoPublicClient();
        }

        public MonobankApi(string token) : this()
        {
            PersonalClient = new MonoPersonalClient(token);
        }
    }
}
  