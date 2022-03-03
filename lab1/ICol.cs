using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public interface ICol
    {
        void Put_A(double a);
        void Clear();
        double Add(double b);
        double Sub(double b);
        double Del(double b);
        double Multy(double b);
        double Mod(double b);
        double Div(double b);

    }
}
