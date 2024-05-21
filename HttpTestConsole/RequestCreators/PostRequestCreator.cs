using HttpTestConsole.Models;
using System.Text.Json;

namespace HttpTestConsole.RequestCreators
{
	public class PostRequestCreator : BaseRequestCreator
	{

		private TestModel _testModel;

        public PostRequestCreator()
        {
			SetBaseAddress(() => "https://jsonplaceholder.typicode.com/");
			SetHttpMethod(HttpMethod.Post);
		}
        public TestModel PostRequestForCreateModel(TestModel model) 
		{
			
			var stringRes = base.MakeRequest();
			_testModel = model;

			return JsonSerializer.Deserialize<TestModel>(stringRes);

		}

		public override string GetUrlPath()
		{
			return "posts";
		}

		public override object GetBody()
		{
			return _testModel;
		}
	}
}
