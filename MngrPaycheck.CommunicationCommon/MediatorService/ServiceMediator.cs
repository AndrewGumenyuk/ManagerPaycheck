﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.CommunicationCommon.MediatorService
{
    public abstract class ServiceMediator
    {
        public abstract void Update(string msg, Service service);
        public abstract void Add(string msg, Service service);
        public abstract string Serialize(object obj, Service service);
        public abstract void Delete(string msg, Service service);
    }
}
