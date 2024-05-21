
using System.Text.Json;

namespace HttpTestConsole.RequestCreators
{
	public abstract  class BaseRequestCreator
	{

		protected  delegate string BaseAddressDelegate();
		private BaseAddressDelegate _addressDelegate;
		protected delegate string MakeRequestDelegate();
		private MakeRequestDelegate _makeRequestDelegate;
		private  HttpMethod  _httpMethod;


        public BaseRequestCreator()
        {
			_makeRequestDelegate = GetRequest;
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
				Method = GetMethod(),
				RequestUri = new Uri(baseAddress + GetUrlPath()),
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
				Method = GetMethod(),
				RequestUri = new Uri(baseAddress + GetUrlPath()),
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
		public abstract string GetUrlPath();

		public virtual object GetBody() 
		{
			return default;
		}




	}
}
