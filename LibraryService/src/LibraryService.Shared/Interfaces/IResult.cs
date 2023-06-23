﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Shared.Interfaces
{
    /// <summary>
    /// Generic Result Class 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResult<T>
    {
        List<string> Messages { get; set; }

        bool Succeeded { get; set; }

        T Data { get; set; }


        Exception Exception { get; set; }

        int Code { get; set; }
    }
}
