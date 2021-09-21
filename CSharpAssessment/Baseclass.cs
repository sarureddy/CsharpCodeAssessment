using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace CSharpCodeAssessment
{
    
    class Baseclass<T>
    {
        
        public TokenResponseDTO getUserToken()
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string endpoint = "accounts/login/real";
            var payload = File.ReadAllText(Path.Combine(assemblyPath + @"\TestData\TokenTestData.json"));
            var user = new HelperClass();
            var url = user.setUrl(endpoint);
            var request = user.CreateTokenPostRequest(payload);
            var response = user.GetResponse(url, request);
            TokenResponseDTO content = user.GetContent<TokenResponseDTO>(response);
            return content;
         }

        public CheckBalanceResponseDTO GetBalance(string endpoint, string productID, String ModuleID, string token)
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string gamepayload = File.ReadAllText(Path.Combine(assemblyPath + @"\TestData\checkbalance.json"));
            var user = new HelperClass();
            var url = user.setUrl(endpoint);
            var request = user.Checkbalancepostrequest(gamepayload, productID, ModuleID, token);
            var response = user.GetResponse(url, request);
            CheckBalanceResponseDTO content = user.GetContent<CheckBalanceResponseDTO>(response);
            return content;

        }
    }
}
