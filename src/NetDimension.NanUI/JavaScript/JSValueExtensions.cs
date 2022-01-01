using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript
{
    public static class JSValueExtensions
    {
        public static string ToDefinition(this CefV8Value v8Value)
        {
            if(v8Value == null || !v8Value.IsValid)
            {
                throw new ArgumentNullException();
            }



            if (v8Value.IsFunction)
            {

            }
            else if(v8Value.IsArray)
            {

            }
            else if (v8Value.IsObject)
            {

            }
            else if (v8Value.IsBool)
            {

            }
            else if(v8Value.IsDate)
            {

            }
            else if(v8Value.IsDouble)
            {

            }
            else if (v8Value.IsInt)
            {

            }
            else if (v8Value.IsUInt)
            {

            }
            else if (v8Value.IsString)
            {

            }
            else if(v8Value.IsNull)
            {

            }
            else
            {
                
            }

            return string.Empty;
        }
    }
}
