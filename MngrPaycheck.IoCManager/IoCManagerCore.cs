using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace MngrPaycheck.IoCManager
{
    public class IoCManagerCore
    {
        public static IKernel Kernel { get; private set; }

        public static void Start()
        {
            Kernel = new StandardKernel(new Bindings());
        }

        public static void Stop()
        {
            Kernel.Dispose();
        }
    }
}
