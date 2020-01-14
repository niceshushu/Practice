using Newtonsoft.Json;
using S_KYA_Core.Model;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public static class MySessionService
{

    static int TimeOutMinutes = 120;

    static ConnectionMultiplexer mRedisSession;
    static MySessionService()
    {
        ConfigurationOptions configuration = new ConfigurationOptions()
        {
            AllowAdmin = true,
            KeepAlive = 180,
            DefaultDatabase = 0,
            EndPoints = { { "127.0.0.1", 6379 } }//应该放在配置文件的，但是懒，没做，后面改
        };
        mRedisSession = ConnectionMultiplexer.Connect(configuration);
    }

    /// <summary>
    /// 添加Session 返回令牌
    /// </summary>
    /// <typeparam name="T">Session对象类型</typeparam>
    /// <param name="aSession">要存为Session的对象</param>
    /// <param name="aPrefix">前缀</param>
    /// <returns>令牌</returns>
    public static string Add<T>(T aSession, string aPrefix = "") where T : BaseSession
    {
        try
        {
            IDatabase client = mRedisSession.GetDatabase();
            aSession.SetExpiresTime(DateTime.Now.AddMinutes(TimeOutMinutes));
            string fExistToken = client.StringGet(aSession.ServerID);//
            if (!string.IsNullOrEmpty(fExistToken))
            {
                //存在客户端令牌
                //更新客户端令牌
                if (client.StringSet(fExistToken, JsonConvert.SerializeObject(aSession), aSession.ExpiresTime.Subtract(DateTime.Now)))
                {
                    return fExistToken;
                }
            }
            else
            {
                string token = aPrefix + Guid.NewGuid().ToString("N");
                if (client.StringSet(token, JsonConvert.SerializeObject(aSession), aSession.ExpiresTime.Subtract(DateTime.Now)) &&//添加Session
                    client.StringSet(aSession.ServerID, token, aSession.ExpiresTime.AddSeconds(-5).Subtract(DateTime.Now))//绑定服务端唯一码与客户端令牌(比Session早5秒失效)
                    )
                {
                    return token;
                }
            }
        }
        catch (Exception ex)
        {
            //
        }
        return null;
    }

    /// <summary>
    /// 获取Session对象
    /// </summary>
    /// <typeparam name="T">Session对象类型</typeparam>
    /// <param name="aToken">令牌</param>
    /// <returns></returns>
    public static T Get<T>(string aToken) where T : BaseSession
    {
        try
        {
            IDatabase client = mRedisSession.GetDatabase();
            T fEntity = null;
            string fSessionValue = client.StringGet(aToken);
            if (!string.IsNullOrEmpty(fSessionValue))
            {
                #region  测试

                //User u = new User() { Name = "aaa" };
                //u.SetExpiresTime(DateTime.Now);

                //Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
                ////这里使用自定义日期格式，如果不使用的话，默认是ISO8601格式
                //timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                //var aa = JsonConvert.SerializeObject(u, Formatting.Indented, timeConverter);

                //var bb = JsonConvert.DeserializeObject<User>(aa); 
                #endregion

                fEntity = JsonConvert.DeserializeObject<T>(fSessionValue);
                //令牌有效时间检查
                CheckExpireTime(aToken, fEntity, client);
            }
            return fEntity;
        }
        catch (Exception)
        {

        }
        return default(T);
    }

    /// <summary>
    /// 获取Session字符串值
    /// </summary>
    /// <typeparam name="T">令牌</typeparam>
    /// <param name="aToken">令牌对应的Session字符串</param>
    /// <returns></returns>
    public static string GetValue<T>(string aToken) where T : BaseSession
    {
        try
        {
            IDatabase client = mRedisSession.GetDatabase();
            string fSessionValue = client.StringGet(aToken);
            if (!string.IsNullOrEmpty(fSessionValue))
            {
                CheckExpireTime(aToken, JsonConvert.DeserializeObject<T>(fSessionValue), client);
            }
            return fSessionValue;
        }
        catch (Exception)
        {

        }
        return null;
    }

    /// <summary>
    /// 删除Session
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="aToken">令牌</param>
    public static void Remote<T>(string aToken) where T : BaseSession
    {
        try
        {
            IDatabase client = mRedisSession.GetDatabase();
            T fEntity = null;
            string fSessionValue = client.StringGet(aToken);
            if (!string.IsNullOrEmpty(fSessionValue))
            {
                fEntity = JsonConvert.DeserializeObject<T>(fSessionValue);
                client.KeyDelete(fEntity.ServerID);
                client.KeyDelete(aToken);
            }
        }
        catch (Exception)
        {

        }
    }


    /// <summary>
    /// 令牌有效时间检查
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="aToken"></param>
    /// <param name="aSession"></param>
    /// <param name="client"></param>
    static void CheckExpireTime<T>(string aToken, T aSession, IDatabase client) where T : BaseSession
    {
        if (aSession.ExpiresTime.Subtract(DateTime.Now).TotalMinutes < 10)
        {
            //离Session过期时间小于10分钟,延长Session有效期
            try
            {
                aSession.SetExpiresTime(DateTime.Now.AddMinutes(TimeOutMinutes));
                client.StringSet(aToken, JsonConvert.SerializeObject(aSession), aSession.ExpiresTime.Subtract(DateTime.Now));
                client.KeyExpire(aSession.ServerID, aSession.ExpiresTime.AddSeconds(-5).Subtract(DateTime.Now));
            }
            catch (Exception ex)
            {

            }
        }
    }
}