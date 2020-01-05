﻿using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.SimplyRazor
{
    public interface ISimplySearch
    {

        int PageSize { get; set; }
        string Index { get; set; }
        string Height { get; set; }


        void AddColumn(IColumn column);
        void RemoveColumn(IColumn column);
        Task AddFilterSetup(ISearchyFilterSetup filter);
        void RemoveFilterSetup(ISearchyFilterSetup filter);
        Task RowClick(string index);
    }
}
