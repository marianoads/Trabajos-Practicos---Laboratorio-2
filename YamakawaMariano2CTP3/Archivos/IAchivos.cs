﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IAchivos<T>
    {
        bool Leer(string archivo,out T datos);
        bool Guardar(string archivo, T datos);
    }
}
