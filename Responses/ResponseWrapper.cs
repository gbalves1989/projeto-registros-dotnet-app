using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrosEntradaSaidaAPP.Responses
{
    public class ResponseWrapper
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<Registro> Data { get; set; }
    }
}
