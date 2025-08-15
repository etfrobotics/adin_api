﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.DTOs
{
    public class RequestParams
    {
        const int maxPageSize = 50;
        private int _pageNumber = 1;
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }

            set
            {
                _pageNumber = (value < 1) ? 1 : value;
            }
        }
        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : ((value < 1) ? 1 : value);
            }
        }
    }
}
