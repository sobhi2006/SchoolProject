using System.Net;

namespace SchoolProject.Core.Bases;

public class ResponseHandler
{
    public Response<T> Deleted<T>()
    {
        return new Response<T>() 
        {
            StatusCode = HttpStatusCode.OK,
            Succeeded = true,
            Message = "Deleted Successfully"
        };
    }
    public Response<T> Success<T>(T entity,string Message = null, object Meta = null)
    {
        return new Response<T>() 
        {
            Data = entity,
            StatusCode = HttpStatusCode.OK,
            Succeeded = true,
            Message = "Success",
            Meta = Meta
        };
    }
    public Response<T> Unauthorized<T>()
    {
        return new Response<T>() 
        {
            StatusCode = HttpStatusCode.Unauthorized,
            Succeeded = true,
            Message = "UnAuthorized"
        };
    }
    public Response<T> BadRequest<T>(string Message = null)
    {
        return new Response<T>() 
        {
            StatusCode = HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = Message == null ? "Bad Request" : Message
        };
    }

    public Response<T> NotFound<T>(string message = null)
    {
        return new Response<T>() 
        {
            StatusCode = HttpStatusCode.NotFound,
            Succeeded = false,
            Message = message == null ? "Not Found" : message
        };
    }
    
    public Response<T> Created<T>(T entity, object Meta = null)
    {
        return new Response<T>() 
        {
            Data = entity,
            StatusCode = HttpStatusCode.Created,
            Succeeded = true,
            Message = "Created",
            Meta = Meta
        };
    }
}


