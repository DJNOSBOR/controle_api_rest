using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class ResultList<T>
    {
        public ResultList(IEnumerable<T> data)
        {
            try
            {
                this.Data = data;
            }
            catch (Exception exception)
            {
                throw;//TODO
                //throw exception.Failin();
            }
        }

        public IEnumerable<T> Data { get; set; }
        public int Count
        {
            get
            {
                return this.Data.Count();
            }
        }
    }
}