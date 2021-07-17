using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{

    public delegate void MyAction<in T>(T value);
    //public deleget Return_Type main<in T, out Boolean>(T i);
    public delegate TR MyFunc<in T, out TR>(T value);
    public delegate Boolean MyFunc<in T,in S, out Boolean>(T value,S value2);

}
