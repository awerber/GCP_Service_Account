﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using GoogleCloudPrint.Model;

/// <summary>
/// this code is from https://github.com/io7/GoogleCloudPrint
/// </summary>
namespace GoogleCloudPrint
{
    public class GoogleCloudPrintService
    {
        private readonly string _source;
        private readonly string _serviceAccountEmail;
        private readonly string _keyFilePath;
        private readonly string _keyFileSecret;
        private readonly ServiceAccountCredential _credentials;
        // below added by AHW
        private readonly CallingProgramConstants _callerType;
        public List<CloudPrinter> Printers = new List<CloudPrinter>();

        #region AHW additions
        public enum CallingProgramConstants
        {
            Console, Desktop, Web, Service
        }
        public GoogleCloudPrintService( string serviceAccountEmail, string keyFilePath, string keyFileSecret, 
            string source, CallingProgramConstants caller)
        {
            _serviceAccountEmail = serviceAccountEmail;
            _keyFilePath = keyFilePath;
            _keyFileSecret = keyFileSecret;
            _source = source;
            _callerType = caller;

            var credentialsTask = Authorize();

            credentialsTask.Wait();

            if (!credentialsTask.IsFaulted)
            {
                _credentials = credentialsTask.Result;
            }
        }

        public GoogleCloudPrintService( string serviceAccountEmail, string keyFilePath, 
            string keyFileSecret, string source) : this ( serviceAccountEmail,  keyFilePath,
             keyFileSecret, source, CallingProgramConstants.Console) { }

        /// <summary>
        /// for more on registering, see https://developers.google.com/cloud-print/docs/devguide#registering
        /// Java code for registering - https://github.com/jittagornp/GoogleCloudPrint
        /// PHP code for registering - 
        /// Example of what should go in capabilites parameter? - https://stackoverflow.com/questions/12724201/google-cloud-print-how-to-submit-valid-capabilities
        /// </summary>
        /// <param name="pReg"></param>
        /// <returns></returns>
        public UnregisteredCloudPrinter RegisterPrinter(UnregisteredCloudPrinter pReg)
        {
            // call the register method and fill the parameter p above with the data
            // since CloudPrinter, at this time, does not have fields for a message, we'll return
            // debuging stuff in exiting fields
            // TODO consider a new class inheriting from CloudPrinter to contain messages

            try
            {
                var p = new PostData();

                if (String.IsNullOrEmpty(pReg.capabilities)) pReg.capabilities = "{\"capabilities\":[{}]}";

                p.Parameters.Add(new PostDataParam { Name = "name", Value = pReg.name, Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "default_display_name", Value = pReg.default_display_name, Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "tag", Value = pReg.tag, Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "proxy", Value = pReg.proxy, Type = PostDataParamType.Field });
                //p.Parameters.Add(new PostDataParam { Name = "capabilities", Value = pReg.capabilities, Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "capabilities", Value = "{\"capabilities\":[{}]}", Type = PostDataParamType.Field });

                pReg = GCPServiceCall<UnregisteredCloudPrinter>("register", p);
            }
            catch (Exception ex)
            {
                pReg.name = ex.Message;
                pReg.id = "failure";
                pReg.description = ex.StackTrace;
            }
            // we could get actual response to inspect the success parameter
            // but it's a failure if object is null
            if (pReg.id == null)
            {
                pReg.id = "failure";
                pReg.name = string.Empty;
                pReg.description = string.Empty;
            }

            return pReg;
        }
        /// <summary>
        /// add required? characters around capabilities
        /// </summary>
        /// <param name="capabilities"></param>
        /// <returns></returns>
        private string DecorateCapabilites (string capabilities)
        {
            // TODO should test for special characters, skip for now
            //string dblQuote = "\"";
            //string returnedValue = "{" + capabilities + "}";
            string returnedValue = capabilities;
            return returnedValue;
        }
        public UnregisteredCloudPrinter UpdatePrinter(UnregisteredCloudPrinter pReg)
        {
            // call the update method to change name and display name of printer
            // since CloudPrinter, at this time, does not have fields for a message, we'll return
            // debuging stuff in exiting fields
            // TODO consider a new class inheting from (un reg)CloudPrinter to contain messages

            try
            {
                var p = new PostData();

                //p.Parameters.Add(new PostDataParam { Name = "name", Value = pReg.name, Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "default_display_name", Value = pReg.default_display_name, Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "printerid", Value = pReg.id, Type = PostDataParamType.Field });

                pReg = GCPServiceCall<UnregisteredCloudPrinter>("update", p);
            }
            catch (Exception ex)
            {
                pReg.name = ex.Message;
                pReg.id = "failure";
                pReg.description = ex.StackTrace;
            }
            // we could get actual response to inspect the success parameter
            // but it's a failure if object is null
            if (pReg.id == null)
            {
                pReg.id = "failure";
                pReg.name = string.Empty;
                pReg.description = string.Empty;
            }

            return pReg;
        }
        public List<CloudPrinter> GetFilteredPrinters (GoogleCloudPrint.Model.GoogleCloudPrinterTypeConstants printerType)
        {
            // return registered printers filtering out by printerType. Filtering is by examining default display name
            List<CloudPrinter> filterdPrinters = new List<CloudPrinter>();

            CloudPrinters cPrinters = GetPrinters();
            foreach (var aPrinter in cPrinters.printers)
            {
                string[] printerNameParts = aPrinter.defaultDisplayName.Split(Convert.ToChar(MiscConstants.DEFAULT_NAME_DELIMITER));
                if (printerNameParts.Length > 1)
                {
                    if (printerNameParts[1] == printerType.ToString())
                        {
                            filterdPrinters.Add(aPrinter);
                        }
                }
            }

            return filterdPrinters;
        }
        #endregion
        #region Original constructor
        /// <summary>
        /// original constructor below
        /// </summary>
        /// <param name="serviceAccountEmail"></param>
        /// <param name="keyFilePath"></param>
        /// <param name="keyFileSecret"></param>
        /// <param name="source"></param>
        //public GoogleCloudPrintService(string serviceAccountEmail, string keyFilePath, string keyFileSecret, string source)
        //{
        //    _serviceAccountEmail = serviceAccountEmail;
        //    _keyFilePath = keyFilePath;
        //    _keyFileSecret = keyFileSecret;
        //    _source = source;

        //    var credentialsTask = Authorize();

        //    credentialsTask.Wait();

        //    if (!credentialsTask.IsFaulted)
        //    {
        //        _credentials = credentialsTask.Result;
        //    }
        //}
        #endregion

        public Task<CloudPrinters> GetPrintersAsync()
        {
            return Task<CloudPrinters>.Factory.StartNew(GetPrinters);
        }

        public Task<CloudPrintJob> PrintAsync(string printerId, string title, byte[] document, String mimeType)
        {
            return Task<CloudPrintJob>.Factory.StartNew(() => PrintDocument(printerId, title, document, mimeType));
        }

        public Task<CloudPrintShare> PrinterShareAsync(string printerId, string email, bool notify)
        {
            return Task<CloudPrintShare>.Factory.StartNew(() => PrinterShare(printerId, email, notify));
        }

        public Task<CloudPrintShare> PrinterUnShareAsync(string printerId, string email)
        {
            return Task<CloudPrintShare>.Factory.StartNew(() => PrinterUnShare(printerId, email));
        }

        public CloudPrintShare PrinterUnShare(string printerId, string email)
        {
            try
            {
                var p = new PostData();

                p.Parameters.Add(new PostDataParam { Name = "printerid", Value = printerId, Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "email", Value = email, Type = PostDataParamType.Field });

                return GCPServiceCall<CloudPrintShare>("unshare", p);
            }
            catch (Exception ex)
            {
                return new CloudPrintShare {success = false, message = ex.Message};
            }
        }

        private void RefreshAccessToken()
        {
            if (_credentials.Token.IsExpired(_credentials.Clock))
            {
                _credentials.RequestAccessTokenAsync(CancellationToken.None).Wait();
            }
        }

        public CloudPrintShare PrinterShare(string printerId, string email, bool notify)
        {
            try
            {
                var p = new PostData();

                p.Parameters.Add(new PostDataParam { Name = "printerid", Value = printerId, Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "email", Value = email, Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "role", Value = "APPENDER", Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "skip_notification", Value = notify.ToString(), Type = PostDataParamType.Field });

                return GCPServiceCall<CloudPrintShare>("share", p);
            }
            catch (Exception ex)
            {
                return new CloudPrintShare {success = false, message = ex.Message};
            }
        }

        public CloudPrintJob PrintDocument(string printerId, string title, byte[] document, string mimeType)
        {
            var content = "data:" + mimeType + ";base64," + Convert.ToBase64String(document);

            return PrintDocument(printerId, title, content, "dataUrl");
        }

        public CloudPrintJob PrintDocument(string printerId, string title, string url)
        {
            return PrintDocument(printerId, title, url, "url");
        }

        public CloudPrintJob PrintDocument(string printerId, string title, string content, string contentType)
        {
            try
            {
                var p = new PostData();

                p.Parameters.Add(new PostDataParam { Name = "printerid", Value = printerId, Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "capabilities", Value = "{\"capabilities\":[{}]}", Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "contentType", Value = contentType, Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "title", Value = title, Type = PostDataParamType.Field });

                var contentValue = content;

                p.Parameters.Add(new PostDataParam { Name = "content", Type = PostDataParamType.Field, Value = contentValue });

                return GCPServiceCall<CloudPrintJob>("submit", p);
            }
            catch (Exception ex)
            {
                return new CloudPrintJob {success = false, message = ex.Message};
            }
        }

        public CloudPrinters GetPrinters()
        {
            // clear internal data, will be reset if call succeeds
            Printers = new List<CloudPrinter>();

            try
            {
                var rv = GCPServiceCall<CloudPrinters>("search");
                if (rv != null)
                {
                    Printers = rv.printers;
                }

                return rv;
            }
            catch (Exception)
            {
                return new CloudPrinters { success = false, printers = new List<CloudPrinter>() };
            }
        }

        public CloudPrintJob ProcessInvite(string printerId)
        {
            try
            {
                var p = new PostData();

                p.Parameters.Add(new PostDataParam { Name = "printerid", Value = printerId, Type = PostDataParamType.Field });
                p.Parameters.Add(new PostDataParam { Name = "accept", Value = "true", Type = PostDataParamType.Field });


                return GCPServiceCall<CloudPrintJob>("processinvite", p);
            }
            catch (Exception ex)
            {
                return new CloudPrintJob() { success = false, message = ex.Message };
            }
        }

        private T GCPServiceCall<T>(string restVerb, PostData p = null) where T : class
        {
            RefreshAccessToken();
            var authCode = _credentials.Token.AccessToken;

            var request = (HttpWebRequest)WebRequest.Create($"https://www.google.com/cloudprint/{restVerb}?output=json");
            request.Method = "POST";

            // Setup the web request
            request.ServicePoint.Expect100Continue = false;

            // Add the headers
            request.Headers.Add("X-CloudPrint-Proxy", _source);
            request.Headers.Add("Authorization", "OAuth " + authCode);

            if (p == null)
            {
                request.ContentLength = 0;
            }
            else
            {
                var postData = p.GetPostData();
                var data = Encoding.UTF8.GetBytes(postData);

                request.ContentType = "multipart/form-data; boundary=" + p.Boundary;

                var stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
            }

            // Get response
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException webEx)
            {
                var myResponse = webEx.Response as HttpWebResponse;

                if (myResponse != null)
                {
                    var exResponseStream = myResponse.GetResponseStream();

                    if (exResponseStream == null)
                    {
                        throw;
                    }

                    var strm = new StreamReader(exResponseStream, Encoding.UTF8);
                    var resp = strm.ReadToEnd();

                    throw new Exception(resp);
                }
            }

            if (response == null)
            {
                throw new Exception("Response was null!");
            }

            var responseStream = response.GetResponseStream();

            if (responseStream == null)
            {
                throw new Exception("Response stream was null!");
            }

            using (var responseStreamReader = new StreamReader(responseStream))
            {
                var responseContent = responseStreamReader.ReadToEnd();
                var serializer = new DataContractJsonSerializer(typeof(T));
                var ms = new MemoryStream(Encoding.Unicode.GetBytes(responseContent));
                var rv = serializer.ReadObject(ms) as T;

                return rv;
            }
        }

        private async Task<ServiceAccountCredential> Authorize()
        {
            var certificate = new X509Certificate2(_keyFilePath, _keyFileSecret, X509KeyStorageFlags.Exportable);

            var credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(_serviceAccountEmail)
               {
                   Scopes = new[] { "https://www.googleapis.com/auth/cloudprint" }
               }.FromCertificate(certificate));

            // below is original code
            //await credential.RequestAccessTokenAsync(CancellationToken.None);
            #region AHW added
            switch (_callerType)
            {
                case CallingProgramConstants.Console:
                    await credential.RequestAccessTokenAsync(CancellationToken.None);
                    break;
                case CallingProgramConstants.Desktop:
                case CallingProgramConstants.Web:
                case CallingProgramConstants.Service:
                    credential.RequestAccessTokenAsync(CancellationToken.None).Wait();
                    break;
            }
            #endregion
            return credential;
        }

        internal class PostData
        {
            private const string CRLF = "\r\n";

            internal string Boundary { get; set; }

            internal List<PostDataParam> Parameters { get; set; }

            internal PostData()
            {
                // Get boundary, default is --AaB03x
                Boundary = "----CloudPrintFormBoundary-" + DateTime.UtcNow.Ticks;

                // The set of parameters
                Parameters = new List<PostDataParam>();
            }

            internal string GetPostData()
            {
                var sb = new StringBuilder();
                foreach (var p in Parameters)
                {
                    sb.Append("--" + Boundary).Append(CRLF);

                    if (p.Type == PostDataParamType.File)
                    {
                        sb.Append(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"", p.Name, p.FileName)).Append(CRLF);
                        sb.Append("Content-Type: ").Append(p.FileMimeType).Append(CRLF);
                        sb.Append("Content-Transfer-Encoding: base64").Append(CRLF);
                        sb.Append("").Append(CRLF);
                        sb.Append(p.Value).Append(CRLF);
                    }
                    else
                    {
                        sb.Append(string.Format("Content-Disposition: form-data; name=\"{0}\"", p.Name)).Append(CRLF);
                        sb.Append("").Append(CRLF);
                        sb.Append(p.Value).Append(CRLF);
                    }
                }

                sb.Append("--" + Boundary + "--").Append(CRLF);

                return sb.ToString();
            }
        }

        internal enum PostDataParamType
        {
            Field,
            File
        }

        internal class PostDataParam
        {
            public string Name { get; set; }
            public string FileName { get; set; }
            public string FileMimeType { get; set; }
            public string Value { get; set; }
            public PostDataParamType Type { get; set; }

            public PostDataParam()
            {
                FileMimeType = "text/plain";
            }
        }
    }
}
