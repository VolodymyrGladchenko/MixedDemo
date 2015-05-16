using System;
using System.Collections.Generic;
using StackExchange.Redis;

namespace RedisRepository.RedisApi.RedisCrud
{
    public interface IRedisCrud
    {
        bool AddNewRecord(string key, string value);
        Dictionary<string, string> ReadRecord(string key);
        bool DeleteRecords(string key);
    }

    public class RedisCrud : IRedisCrud
    {
        private readonly IRedisClientFactory redisClientFactory;
        private readonly IDatabase redisDataBase;

        public RedisCrud(IRedisClientFactory redisClientFactory)
        {
            redisDataBase = redisClientFactory.GetConnectionMultiplexer().GetDatabase();
        }

        public bool AddNewRecord(string key, string value)
        {
            try
            {
                redisDataBase.StringSet(key, value);
            }
            catch (Exception ex)
            {
                //use logger here
                return false;
            }
            return true;
        }

        public Dictionary<string, string> ReadRecord(string key)
        {
            var result = new Dictionary<string, string>();
            try
            {
                string value = redisDataBase.StringGet(key);
                result.Add(key, value);
            }
            catch (Exception ex)
            {
                //use logger here
                return new Dictionary<string, string>();
            }
            return result;
        }

        public bool DeleteRecords(string key)
        {
            try
            {
                redisDataBase.KeyDelete(key);
            }
            catch (Exception ex)
            {
                //use logger here
                return false;
            }
            return true;
        }
    }
}