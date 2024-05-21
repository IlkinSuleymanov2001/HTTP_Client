using HttpTestConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpTestConsole.RequestCreators
{
	public class StudentGetLIstRequest :BaseRequestCreator
	{
		public StudentGetLIstRequest() 
		{
			SetBaseAddress(() => "http://10.251.86.77:8080/");
			SetHttpMethod(HttpMethod.Get);
		}

		public IList<Student> GetListStudent() 
		{
			var jsonData = MakeRequest();
			return JsonSerializer.Deserialize<IList<Student>>(jsonData);

		}
		public override string SetUrlPath()
		{
			return "school";
		}
	}
}
