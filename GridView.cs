using System;
using System.Data;

namespace Modelo
{
    public class GridView
    {
        public DataTable DataSource { get; internal set; }

        internal void DataBind()
        {
            throw new NotImplementedException();
        }
    }
}