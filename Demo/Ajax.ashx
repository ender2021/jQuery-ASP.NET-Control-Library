<%@ WebHandler Language="C#" Class="Ajax" %>

using System;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

public class Ajax : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        switch (context.Request.Params["action"])
        {
            case "ajax-content":
                context.Response.Write("<img src=\"http://www.sematopia.com/images/ajax.jpg\" style=\"height:200px;width:200px;\" />");
                break;
            case "autocomplete":
                var term = context.Request.Params["term"];
                var data = "Apples Oranges Pears grapes prunes raspberries strawberries banana".Split(' ').ToList();
                var subset = (
                     from item in data
                     where item.ToLower().Contains(term.ToLower())
                     select item).ToList();
                
                context.Response.Write(JsonConvert.SerializeObject(subset));
                break;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}