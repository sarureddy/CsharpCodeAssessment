
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CSharpCodeAssessment
{
    [TestFixture]
    public class TestClass
    {
        
        public static TestContext testContext { get; set; }
        

        
        public string cid = System.Configuration.ConfigurationManager.AppSettings["clientId"];
        public string mid = System.Configuration.ConfigurationManager.AppSettings["moduleId"];
        public string pid = System.Configuration.ConfigurationManager.AppSettings["productId"];
        public TokenResponseDTO createToken;

    
        [Test]
        public void GetToken()
        {
            var user = new Baseclass<TokenResponseDTO>();
           TokenResponseDTO getToken = user.getUserToken();
            
            //Assert.AreEqual(getToken.tokens.userToken, "JYDFGDFGFDGRTMPWZDFDFG");
        }

        [Test]
        public void CheckGameBalance()
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var gamepayload = File.ReadAllText(Path.Combine(assemblyPath + @"\TestData\checkbalance.json"));
            var GamePlayEndpoint = $"v1/games/module/{mid}/client/{cid}/play";
            var base1 = new Baseclass<CheckBalanceResponseDTO>();

            //var newToken = createToken.tokens.userToken; // "JYDFGDFGFDGRTMPWZDFDFG" ;
            var newToken = "JYDFGDFGFDGRTMPWZDFDFG";
            var balance = base1.GetBalance(GamePlayEndpoint, pid, mid, newToken);
            var amount = balance.Context.Balances.TotalInAccountCurrency;
            Assert.AreEqual(amount, "10000.0");
      
        }
    }
}
