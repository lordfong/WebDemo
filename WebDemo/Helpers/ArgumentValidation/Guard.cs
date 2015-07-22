using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo.Helpers
{
    public class Guard
    {
        public void ObjectIsnotNull(object o) 
        {
            if (o == null) 
            {
                throw new ArgumentNullException();
            }
        }

        public void LessThanOne(int value) 
        {
            if (value < 1) 
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}