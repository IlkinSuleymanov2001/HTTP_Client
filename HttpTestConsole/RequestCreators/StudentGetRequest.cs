using HttpTestConsole.Models;
using System.Text.Json;

namespace HttpTestConsole.RequestCreators
{
	public class StudentGetRequest : BaseRequestCreator
	{
		private int _id;
        public StudentGetRequest()
        {
			SetBaseAddress(() => "http://10.251.86.77:8080/");
			SetHttpMethod(HttpMethod.Get);
		}

		public Student GetStudent(int id)
		{
			_id = id;
			var jsonData = MakeRequest();
			return JsonSerializer.Deserialize<Student>(jsonData);

		}

		public override string SetUrlPath()
		{
			return $"school/ + {_id}";
		}
	}
}
