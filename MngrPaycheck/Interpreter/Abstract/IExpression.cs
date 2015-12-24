using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Interpreter.Abstract
{
    interface IExpression
    {
        int Interpret(Context context);    
    }
}
