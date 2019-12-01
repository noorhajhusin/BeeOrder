using BeeOrder.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;

namespace BeeOrder.Service
{ 
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        // [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetData/{value}")]
        [WebInvoke(UriTemplate = "/GetFoods", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        GetItemsRespond GetFoods(string UserName, string Password);

        [OperationContract]
        // [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetData/{value}")]
        [WebInvoke(UriTemplate = "/GetDrinks", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        GetItemsRespond GetDrinks(string UserName, string Password);


        [OperationContract]
        // [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetData/{value}")]
        [WebInvoke(UriTemplate = "/GetOrders", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        GetOrdesRespond GetOrders(string UserName, string Password);

        [OperationContract]
        // [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetData/{value}")]
        [WebInvoke(UriTemplate = "/OrdersDone", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        OrdersDoneRespond OrdersDone(string UserName, string Password);


        [OperationContract]
        // [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetData/{value}")]
        [WebInvoke(UriTemplate = "/GetPlaces", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<PlaceRespond> GetPlaces(string UserName, string Password);



        [OperationContract]
        [WebInvoke(UriTemplate = "/Login", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //[WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Login/{un}/{pass}")]
        LoginRespond Login(string UserName, string Password);


        [OperationContract]
        [WebInvoke(UriTemplate = "/Order", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        OrderRespond Order(List<OrderItemRequest> Items, string UserName, string Password);

    }
    
}
