using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practical_09.App_Start
{
    public class Filter
    {
        public class MyExceptionFilter : FilterAttribute, IExceptionFilter

        {
            public void OnException(ExceptionContext filterContext)
            {
                //Handle exception here  
                try
                {
                    throw new Exception("Some unknown error encountered!");
                }
                catch(Exception ex)
                {
                    
                }

            }
        }
    }
}