﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Controller
{
    public interface IDataSaver
    {
        void Save<T>(List<T> item) where T : class;

        List<T> Load<T>() where T : class;
    }
}
