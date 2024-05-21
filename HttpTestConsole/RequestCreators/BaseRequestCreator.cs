
using System.Text.Json;

namespace HttpTestConsole.RequestCreators
{
	public abstract  class BaseRequestCreator
	{

		protected  delegate string BaseAddressDelegate();
		private BaseAddressDelegate _addressDelegate;
		private delegate string SetControlerAndAction();
		private SetControlerAndAction _controlerAndAction;
		protected delegate string MakeRequestDelegate();
		private MakeRequestDelegate _makeRequestDelegate;
		private  HttpMethod  _httpMethod;


        public BaseRequestCreator()
        {
			_makeRequestDelegate = GetRequest;
			_httpMethod = HttpMethod.Get;
			_controlerAndAction = SetUrlPath;
        }

        protected  void  SetBaseAddress(BaseAddressDelegate baseAddress)
		{
			_addressDelegate = baseAddress;
		}



		protected  string MakeRequest() 
		{
	

			return _makeRequestDelegate.Invoke();
		}


		private string GetRequest() 
		{
			HttpClient client = new HttpClient();

			var baseAddress = _addressDelegate.Invoke();
			var msg = new HttpRequestMessage()
			{
				Method = _httpMethod,
				RequestUri = new Uri(baseAddress + _controlerAndAction.Invoke()),
			};

			var httpResponse = client.Send(msg);

			httpResponse.EnsureSuccessStatusCode();
			var resultContent = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return resultContent;
		}

		private string PostRequest() 
		{
			HttpClient client = new HttpClient();

			var baseAddress = _addressDelegate.Invoke();

			var msg = new HttpRequestMessage()
			{
				Method = _httpMethod,
				RequestUri = new Uri(baseAddress + _controlerAndAction.Invoke()),
				Content = new StringContent(JsonSerializer.Serialize(GetBody()))
		};
			var httpResponse = client.Send(msg);

			httpResponse.EnsureSuccessStatusCode();
			var resultContent = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return resultContent;
		}


		public HttpMethod SetHttpMethod(HttpMethod method) 
		{
			if (method == HttpMethod.Post)
				_makeRequestDelegate = PostRequest;

			return _httpMethod = method;
		}
		public abstract string SetUrlPath();

		public virtual object GetBody() 
		{
			return default;
		}




	}
}
