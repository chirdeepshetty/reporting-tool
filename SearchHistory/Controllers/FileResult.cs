using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SearchHistory.Controllers
{
   
    public class FileResult : ActionResult
    {
        #region Constructors

        public FileResult(string fileName, string contentType, IEnumerable<byte> data)
            : this(fileName, contentType, data, null)
        {
        }

        public FileResult(string fileName, string contentType, IEnumerable<byte> data,                           IDictionary<string, string> headers)
        {
            this.FileName = fileName;
            this.ContentType = contentType;
            this.Data = data;
            this.Headers = headers;
        }

        public FileResult(string fileName, string contentType, Encoding contentEncoding,                           IEnumerable<byte> data)
            : this(fileName, contentType, contentEncoding, data, null)
        {
        }

        public FileResult(string fileName, string contentType, Encoding contentEncoding,                          IEnumerable<byte> data, IDictionary<string, string> headers)
            : this(fileName, contentType, data, headers)
        {
            this.ContentEncoding = contentEncoding;
        }

        public FileResult(string fileName, string contentType, string path)
            : this(fileName, contentType, path, null)
        {
        }

        public FileResult(string fileName, string contentType, string path,                          IDictionary<string, string> headers)
        {
            this.FileName = fileName;
            this.ContentType = contentType;
            this.Data = ReadBytes(path);
            this.Headers = headers;
        }

        #endregion

        IEnumerable<byte> ReadBytes(string path)
        {
            var stream = File.OpenRead(path);
            var bytes = new byte[1024];
            int n;

            while ((n = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                for (int i = 0; i < n; i++)
                {
                    yield return bytes[i];
                }
            }
        }

        // Methods
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            HttpResponseBase response = context.HttpContext.Response;
            
            response.Clear();
            response.ClearContent();

            if (!string.IsNullOrEmpty(this.ContentType))
            {
                response.ContentType = this.ContentType;
            }
            else
            {
                response.ContentType = MediaTypeNames.Text.Plain;
            }

            response.ContentEncoding = this.ContentEncoding ?? Encoding.Default;

            if (!String.IsNullOrEmpty(this.FileName))
            {
                response.AppendHeader("content-disposition", "attachment; filename=" + this.FileName);
            }

            if (this.Headers != null)
            {
                foreach (var header in Headers)
                {
                    response.AppendHeader(header.Key, header.Value);
                }
            }

            if (this.Data != null)
            {
                response.BinaryWrite(this.Data.ToArray());
            }
        }

        // Properties
        public IEnumerable<byte> Data { get; set; }

        public string FileName { get; set; }

        public Encoding ContentEncoding { get; set; }

        public string ContentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public IDictionary<string, string> Headers { get; set; }
    }
}
