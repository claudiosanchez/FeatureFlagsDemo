using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LaunchDarkly.Client;
using LaunchDarkly.Xamarin;

namespace NewBank.BasicClient.Services
{
    public class FeatureFlagService : IFeatureFlagService
    {
        LdClient _client;
        User _user;
        string SDK_KEY_PROD = "sdk-213ff5d1-c2ca-408c-b646-c2ac50350d78";
        string SDK_KEY_TEST = "sdk-c3342f99-7f14-4df8-8dae-398acce1adb6";

        string MOBILE_KEY_TEST = "mob-b3a03622-2410-4fa7-b846-e5c449c7aa97";

        async void Initialize()
        {
            var config = Configuration.Default(MOBILE_KEY_TEST)
            .WithStartWaitTime(TimeSpan.Zero);

            _user = User.WithKey("claudio.a.sanchez@outlook.com");
            _client = LdClient.Instance;
        }

        public bool Can(string id)
        {
            if (_client == null) Initialize();

            var results = _client.BoolVariation(id);
            // Logging would be good
            Console.WriteLine($"Feature {id} is {results} for user  {_user.Name} ({_user.Key})");
            return results;
        }
    }

    //public class FeatureFlagService : IFeatureFlagService
    //{
    //    LdClient _client;
    //    string SDK_KEY_PROD = "sdk-213ff5d1-c2ca-408c-b646-c2ac50350d78";
    //    string SDK_KEY_TEST= "sdk-c3342f99-7f14-4df8-8dae-398acce1adb6";

    //    void Initialize()
    //    {
    //        var user = User.WithKey("claudio.a.sanchez@outlook.com");
    //       _client = new LdClient(MY_MOBILE_KEY);
    //    }

    //    public bool Can(string id)
    //    {
    //        if (_client== null || _client.Initialized())
    //        {
    //            Initialize();
    //        }

    //        var user = User.WithKey("claudio.a.sanchez@outlook.com");

    //        var results = _client.BoolVariation(id, user);
    //        // Logging would be good
    //        Console.WriteLine($"Feature {id} is {results} for user  {user.Name} ({user.Key})");
    //        return results;
    //    }
    //}
}
