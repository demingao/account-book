//*************************************
// All rights reserved
// filename:JsonRpcHanler
// description:this is a class file
// created by kikao
// created at 2014/9/7 21:03:25
// version 1.0
//*************************************

using System.IO;
using System.Reflection;
using System.Web;
using AustinHarris.JsonRpc;

namespace AccountBook.JsonRpcHandleLoader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JsonRpcHanler : IHttpAsyncHandler
    {
        private static readonly Dictionary<string, Assembly> Assemblies = new Dictionary<string, Assembly>();
        private static readonly Dictionary<string, JsonRpcService> JsonRpcServices = new Dictionary<string, JsonRpcService>();
        static JsonRpcHanler()
        {
            //var serviceTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(type => type.BaseType == typeof(JsonRpcService));
            string assembliesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            LoadAssemblies(assembliesPath);
        }

        public JsonRpcHanler()
        {
        }

        private static void LoadAssemblies(string path)
        {
            DirectoryInfo dir = Directory.CreateDirectory(path);
            FileInfo[] files = dir.GetFiles("*.dll");
            foreach (var fileInfo in files)
            {
                Assembly ass = Assembly.Load(fileInfo.Name.Replace(fileInfo.Extension, ""));
                try
                {
                    LoadService(ass);
                }
                catch (Exception)
                {
                    continue;
                }

            }
        }

        private static void LoadService(Assembly ass)
        {
            var services = ass.GetTypes().Where(_ => _.BaseType == typeof(JsonRpcService));
            foreach (var service in services)
            {
                if (!JsonRpcServices.ContainsKey(service.Name))
                    JsonRpcServices.Add(service.Name, (JsonRpcService)ass.CreateInstance(service.FullName));
            }
        }

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            // not used
        }

        #endregion

        #region IHttpAsyncHandler Members

        /// <summary>
        /// Initiates an asynchronous call to the HTTP handler.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        /// <param name="cb">The <see cref="T:System.AsyncCallback"/> to call when the asynchronous method call is complete. If <paramref name="cb"/> is null, the delegate is not called.</param>
        /// <param name="extraData">Any extra data needed to process the request.</param>
        /// <returns>
        /// An <see cref="T:System.IAsyncResult"/> that contains information about the status of the process.
        /// </returns>
        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            var async = new JsonRpcStateAsync(cb, context);
            async.JsonRpc = GetJsonRpcString(context.Request);
            JsonRpcProcessor.Process(async, context.Request);
            return async;
        }

        private static string GetJsonRpcString(System.Web.HttpRequest request)
        {
            string json = string.Empty;
            if (request.RequestType == "GET")
            {
                json = request.Params["jsonrpc"] ?? string.Empty;
            }
            else if (request.RequestType == "POST")
            {
                if (request.ContentType == "application/x-www-form-urlencoded")
                {
                    json = request.Params["jsonrpc"] ?? string.Empty;
                }
                else
                {
                    json = new StreamReader(request.InputStream).ReadToEnd();
                }
            }
            return json;
        }
        /// <summary>
        /// Provides an asynchronous process End method when the process ends.
        /// </summary>
        /// <param name="result">An <see cref="T:System.IAsyncResult"/> that contains information about the status of the process.</param>
        public void EndProcessRequest(IAsyncResult result)
        {
            var state = result as JsonRpcStateAsync;
            if (state != null)
            {
                var r = state.Result;
                var callback = ((HttpContext)state.AsyncState).Request.Params["callback"];
                if (!string.IsNullOrEmpty(callback))
                {
                    r = string.Format("{0}({1})", callback, r);
                }
                ((HttpContext)state.AsyncState).Response.Write(r);
                ((HttpContext)state.AsyncState).Response.End();
            }
        }
        #endregion
    }
}
