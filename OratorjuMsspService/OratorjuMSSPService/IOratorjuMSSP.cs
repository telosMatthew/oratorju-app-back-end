using OratorjuMSSPService.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OratorjuMSSPService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOratorjuMSSP" in both code and config file together.
    [ServiceContract]
    public interface IOratorjuMSSP
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json/{id}")]
        string JSONData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "readingsFrom/{date}")]
        List<Reading> getReadingsFrom(string date);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "thoughtsFrom/{date}")]
        List<Thought> getThoughtsFrom(string date);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    UriTemplate = "thoughtsFrom/{date}")]

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    UriTemplate = "articlesFrom/{date}")]
    }
}
