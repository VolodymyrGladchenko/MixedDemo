using System.Configuration;
using System.Linq;
using StackExchange.Redis;

namespace RedisRepository.RedisApi
{
    public interface IRedisClientFactory
    {
        ConnectionMultiplexer GetConnectionMultiplexer();
    }

    public class RedisClientFactory : IRedisClientFactory
    {
        private readonly ConnectionMultiplexer connectionMultiplexer;

        public RedisClientFactory()
        {
            var host = ConfigurationManager.AppSettings.GetValues("host");
            if (host != null && host.Any())
            {
                connectionMultiplexer = ConnectionMultiplexer.Connect(host[0]);
            }
        }

        public ConnectionMultiplexer GetConnectionMultiplexer()
        {
            return connectionMultiplexer;
        }
    }
}