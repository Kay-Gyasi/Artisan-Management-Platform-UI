using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kessewa.Extension.Shared.HttpServices.Models
{
	public class PaginatedQuery
	{
		public PaginatedQuery(int start, int currentPage,
			int pageSize)
		{
			Start = start;
			CurrentPage = currentPage;
			PageSize = pageSize <= 0 ? 10 : pageSize;
			Search = string.Empty;
			Sort = string.Empty;

		}
		public PaginatedQuery(int top,
			int skip)
		{
			Skip = skip;
			PageSize = top;
			Search = string.Empty;
			Sort = string.Empty;

		}

		public static PaginatedQuery Build(int start = 0, int currentPage = 1, int pageSize = 50)
		{
			return new PaginatedQuery(start, currentPage, pageSize);
		}

		public PaginatedQuery ThenSearch(string search)
		{
			Search = search;
			return this;
		}
		public PaginatedQuery SortBy(string sort)
		{
			Sort = sort;
			return this;
		}
		public PaginatedQuery SkipBy(int skip)
		{
			Skip = skip;
			return this;
		}
		public int Skip { get; set; }
		public int CurrentPage { get; }
		public int PageSize { get; }
		public int Start { get; }
		public string Sort { get; private set; }
		public string Search { get; private set; }
		public string OtherJson { get; set; }


		//Delete
		public string CurrentSemester { get; set; }
	}

	public class PaginatedList<T>
	{
		public List<T> Data { get; set; } = new List<T>();
		public int TotalPages { get; set; }
		public int PageSize { get; set; }
		public int TotalCount { get; set; }
		public bool HasPrevious { get; set; }
		public bool HasNext { get; set; }
		public int From { get; set; }
		public int To { get; set; }
		public int CurrentPage { get; set; }


	}

	public class RequestResponse
	{
		public RequestResponse(bool isComplete, string message, string detailedMessage)
		{
			IsComplete = isComplete;
			Message = message;
			DetailedMessage = detailedMessage;
		}

		public bool IsComplete { get; }
		public string Message { get; }
		public string DetailedMessage { get; }

		public static RequestResponse Error(Exception ex)
		{
			return new RequestResponse(false, ex.Message, ex.InnerException?.Message);
		}
		public static RequestResponse Error(string message, string detailed = "")
		{
			return new RequestResponse(false, message, detailed);
		}
		public static RequestResponse BadRequest(string message, string detailed = "")
		{
			return new RequestResponse(false, message, detailed);
		}

		public static RequestResponse Done(string message)
		{
			return new RequestResponse(true, message, null);
		}
	}
	public class ApiResultModel<T>
	{
		[JsonProperty("version")]
		public string Version { get; set; }

		[JsonProperty("statusCode")]
		public long StatusCode { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("result")]
		public T Result { get; set; }
	}
	public class AuditModel
	{
		[JsonProperty("createdBy")]
		public string CreatedBy { get; set; }

		[JsonProperty("lastModifiedBy")]
		public string LastModifiedBy { get; set; }

		[JsonProperty("entityStatus")]
		public string EntityStatus { get; set; }

		[JsonProperty("entityStatusCreateBy")]
		public object EntityStatusCreateBy { get; set; }

		[JsonProperty("entityStatusLastModifiedBy")]
		public string EntityStatusLastModifiedBy { get; set; }

		[JsonProperty("createdDate")]
		public string CreatedDate { get; set; }

		[JsonProperty("lastModifiedDate")]
		public string LastModifiedDate { get; set; }

		[JsonProperty("entityStatusCreatedDate")]
		public string EntityStatusCreatedDate { get; set; }

		[JsonProperty("entityStatusLastModifiedDate")]
		public string EntityStatusLastModifiedDate { get; set; }
	}
}
