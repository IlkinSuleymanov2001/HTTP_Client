using HttpTestConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace HttpTestConsole.RequestCreators
{
	public class GetRequestCreator : BaseRequestCreator
	{

        public GetRequestCreator()
        {
			SetBaseAddress(() => "https://jsonplaceholder.typicode.com/");
			SetHttpMethod(HttpMethod.Get);
		}
        public List<TestModel> GetModelsList() 
		{
			
			var stringRes = MakeRequest();
			return JsonSerializer.Deserialize<List<TestModel>>(stringRes);
		}
	

		public override string GetUrlPath()
		{
			return "posts";
		}
	}
}
