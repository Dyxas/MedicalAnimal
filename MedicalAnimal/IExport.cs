﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnimal
{
    public interface IExport<T>
    {
        T ExportExcel(T card);
    }
}
