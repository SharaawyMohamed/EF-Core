using Azure;
using System.Net;

namespace StudentAPI
{
	public class Responses
	{
		public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public object? Data { get; set; }

		public static async Task<Responses> SuccessResponse(string? Message = null, object? data = null)
		{
			if (data == null)
			{
				return new Responses
				{
					StatusCode = HttpStatusCode.OK,
					IsSuccess = true,
					Message = Message,
				};
			}
			else
			{
				return new Responses
				{
					StatusCode = HttpStatusCode.OK,
					IsSuccess = true,
					Data = data,
				};
			}
		}
		public static async Task<Responses> FailurResponse(HttpStatusCode StatusCode, string? Message = null, object? data = null)
		{
			if (data == null)
			{
				return new Responses
				{
					StatusCode = StatusCode,
					IsSuccess = false,
					Message = Message,
				};
			}
			else
			{
				return new Responses
				{
					StatusCode = StatusCode,
					IsSuccess = false,
					Data = data,
				};
			}
		
		}
	}
}
