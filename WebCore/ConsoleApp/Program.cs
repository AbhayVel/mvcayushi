using System;
using System.Collections.Generic;
using System.Reflection;
using UtilityCore;
using System.Linq;
using WebCoreEntities;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp
{
    //Public static void Main 
   
    class Program
    {
       
        public static bool MLess(int i, int j)
        {

            //public delegate Boolean MyFunc<in T, out Boolean>(T value);
            return i < 2;
        }

        public static bool Less(int i)
        {
            return i < 2;
        }

        public static  bool Greater(int i)
        {
            return i > 2;
        }


      static  void GetData(MyFunc<int, Boolean> func)
        {
          bool res=  func(2);
        }



        static IEnumerable<string> GetContantian(IEnumerable<string> strList,string str )
        {
           // List<string> lst = new List<string>();

            foreach(var item in strList)
            {
                if (item.Contains(str))
                {
                    yield return item;
                }
            }

          //  return lst;
        }


        static IEnumerable<string> GetValues2(IEnumerable<string>  data)
        {

            yield return "ABhay";
            yield return "Ayushi";
            yield return "Rupal";

        }

        static IEnumerable<string> GetValues()
        {

            yield return "ABhay";
            yield return "Ayushi";
            yield return "Rupal";

        }

        public static dynamic ConvertData(string value, Type type)
        {

            return Convert.ChangeType(value, type);
        }
        static void Binder(Dictionary<string,string> d, Object obj, ModelState modelState)
        {

            Type type = obj.GetType();
            foreach (var item in d)
            {
                PropertyInfo p=  type.GetProperty(item.Key);
                if (p == null) continue;             

                p.SetValue(obj, ConvertData( item.Value, Type.GetType(p.PropertyType.ToString())));
                var IAttr = p.GetCustomAttributes();
                List<string> lstStr = new List<string>();
                foreach (var iattr in IAttr)
                {
                    if(iattr is ValidationAttribute)
                    {
                        ValidationAttribute va= iattr as ValidationAttribute;
                        bool t = va.IsValid(item.Value);
                        if (!t)
                        {
                            var message = va.FormatErrorMessage(item.Key);
                            lstStr.Add(message) ;
                        }
                        Console.WriteLine(t);
                    }

                }
                if(lstStr.Count > 0)
                {
                    modelState.Errors.Add(item.Key, lstStr);
                }

            }
        }


        static void Main(string[] args)
        {

            var name = "ABhay Velankar";
       var outputarr=     name.ToLower().ToCharArray().OrderBy(X => X).Distinct(X => X.ToString()).ToArray();
            string Output = string.Join("", outputarr);   // "abehklnrvy";
            
            StudentMSContext sm = new StudentMSContext();
            sm.StudentSet.Add(new Student
            {
               FirstName="Rupal",
               LastName= "Kajle",
               Age=21,
               SubjectId=2,
               Fees=15000,
               Active=true
            });

            sm.SaveChanges();

            Console.ReadLine();
        }

        static void Main_Delete(string[] args)
        {
            //StudentMSContext sm = new StudentMSContext();
            //var subject = sm.TblSubject.Where(x => x.Id ==6).FirstOrDefault();

            //if (subject != null)
            //{
            //    sm.TblSubject.Remove(subject);
            //    sm.SaveChanges();
            //}

            //Console.ReadLine();
        }

        static void Main_Get(string[] args)
        {
            //StudentMSContext sm = new StudentMSContext();
            //var subjectList = sm.TblSubject.Where(x => x.Id > 5).ToList();

            //foreach (var item in subjectList)
            //{
            //    Console.WriteLine(item.Id.ToString() + ":::" + item.Name);
            //}


            //Console.ReadLine();
        }
            static void Main_saveNew(string[] args)
        {
            //StudentMSContext sm = new StudentMSContext();
            //sm.TblSubject.Add(new TblSubject
            //{
             
            //    Name = "Selenium"
            //});

            //sm.TblSubject.Add(new TblSubject
            //{

            //    Name = "Python"
            //});


            //sm.TblSubject.Add(new TblSubject
            //{

            //    Name = "Go"
            //});

            //sm.TblSubject.Add(new TblSubject
            //{

            //    Name = "C"
            //});
            //sm.SaveChanges();
            //Console.Read();
        }

            static void MainOld123(string[] args)
        {
            Student s = new Student();
            ModelState modelState = new ModelState();
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Id", "1");
            d.Add("FirstName", "Rupal11111111111111111111111111");
            d.Add("LastName", "K");
            d.Add("Age", "23");

            d.Add("Age2", "23");


            Binder(d, s,modelState);

            Console.WriteLine(s);

        }

        static void Main9999(string[] args)
        {
            int a=5;
            int b = 2;
            int c =(int) Math.Ceiling(  a * 1.0 / b);
            Console.Read();
            try{

            }
            finally
            {

            }
        }

            static void Main900(string[] args)
        {

            List<string> lst = new List<string>();
            lst.ToList();
            for(var i = 0; i < 10000; i = i + 1)
            {
                lst.Add("A" + i.ToString());
            }

            for (var i = 0; i < 10000; i = i + 1)
            {
                lst.Add("B" + i.ToString());
            }

            for (var i = 0; i < 10000; i = i + 1)
            {
                lst.Add("C" + i.ToString());
            }
            for (var i = 0; i < 10000; i = i + 1)
            {
                lst.Add("D" + i.ToString());
            }


            var datal = GetContantian(lst, "A");
            var data2 = GetContantian(datal, "1");
            var data3 = GetContantian(data2, "0");

            var d = data3.ToMyList();

            var data = GetValues();

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
            
            Console.Read();
        }

            static void Main89(string[] args)
        {
            string str = "  ";
            bool res1 = string.IsNullOrEmpty(str);
            bool res2 = string.IsNullOrWhiteSpace(str);
        }
            static void Main2(string[] args)
        {
            int[] arrInt = { 1, 1, 3, 5, 6, 2, 4, 6, 7, 9, 12, 45, -3, 6, -8 };
            var f = -3 % 2;
            var d = arrInt.FirstOrDefault(X => X > 600);
            var d2 = arrInt.Single(X => X==X);
            // IEnumerable<int> lst = MyLinq.Where(arrInt, X => X % 2 == 0);

            //var outputLst= MyLinq.ToMyList(lst);

            // var outputArr = MyLinq.ToMyArray(lst);

            IEnumerable<int> lst = arrInt.Where(X => X % 2 == 0);

            var outputLst = lst.ToMyList();

            var outputArr = lst.ToMyArray();

            var output= arrInt.FirstOrDefault(x=>x >  5);

            //IEnumerable<int> lst = arrInt.Where(X => X % 2 == 0);

          //  var outputLst2 = arrInt.Where(X => X % 2 == 0).ToMyList();

        // var oo=   arrInt.OrderBy(x => x);
            var r = arrInt.Min(X=>X);

            Employee[] empArr = { new Employee { Name="Abhay" },
                new Employee { Name="Ayushi" },
                 new Employee { Name="Rupal" },
                 new Employee { Name="Amruta" }
                };

           var resOut= empArr.Min(X => X.Name);

            var resOutMax = empArr.Max(X => X.Name);

            var o = empArr.All(X => X.Name.Contains("p", StringComparison.OrdinalIgnoreCase));
            //var outputArr = lst.ToMyArray();
            Console.Read();
            //int[] arrResult = new int[10];
            //int j = 0;
            //for(int i=0;i< arrInt.Length; i = i + 1)
            //{
            //    if (arrInt[i] % 2 == 1)
            //    {
            //        arrResult[j++] = arrInt[i];
            //    }
            //}



            //string 
            //collection 
            //number
            //Boolean 
            //Date 


            Console.Read();
        }


        //static T[] GetGreaterEqual<T>(T[] arrInt, T val)  
        //{
        //    T[] arrResult = new T[10];
        //    int j = 0;
        //    for (int i = 0; i < arrInt.Length; i = i + 1)
        //    {
        //        if (arrInt[i] == val)
        //        {
        //            arrResult[j++] = arrInt[i];
        //        }
        //    }

        //    return arrResult;
        //}

        

        static T[] GetValues<T>(T[] arrInt, MyFunc<T, bool> func)
        {
            T[] arrResult = new T[arrInt.Length];
            int j = 0;
            for (int i = 0; i < arrInt.Length; i = i + 1)
            {
                if (func(arrInt[i]))
                {
                    arrResult[j++] = arrInt[i];
                }

            }

            return arrResult;
        }


        //static decimal[] GetValues(decimal[] arrInt, MyFunc<decimal, bool> func)
        //{
        //    decimal[] arrResult = new decimal[10];
        //    int j = 0;
        //    for (int i = 0; i < arrInt.Length; i = i + 1)
        //    {

        //        if (func(arrInt[i]))
        //        {
        //            arrResult[j++] = arrInt[i];
        //        }

        //    }

        //    return arrResult;
        //}

        //static int[] GetValues(int[] arrInt, MyFunc<int, bool> func)
        //{
        //    int[] arrResult = new int[10];
        //    int j = 0;
        //    for (int i = 0; i < arrInt.Length; i = i + 1)
        //    {
                
        //            if (func(arrInt[i] ))
        //            {
        //                arrResult[j++] = arrInt[i];
        //            }               

        //    }

        //    return arrResult;
        //}


        static int[] GetValues(int[] arrInt, int val, string op)
        {
            int[] arrResult = new int[10];
            int j = 0;
            for (int i = 0; i < arrInt.Length; i = i + 1)
            {
                if(op.Equals("Gte")){
                    if (arrInt[i] >= val)
                    {
                        arrResult[j++] = arrInt[i];
                    }
                } else if (op.Equals("Lte"))
                {
                    if (arrInt[i] <= val)
                    {
                        arrResult[j++] = arrInt[i];
                    }
                }
                else if (op.Equals("eq"))
                {
                    if (arrInt[i] == val)
                    {
                        arrResult[j++] = arrInt[i];
                    }
                }
                else if (op.Equals("even"))
                {
                    if (arrInt[i] %2==0)
                    {
                        arrResult[j++] = arrInt[i];
                    }
                }
                else if (op.Equals("odd"))
                {
                    if (arrInt[i] % 2 == 1)
                    {
                        arrResult[j++] = arrInt[i];
                    }
                }

            }

            return arrResult;
        }

        static int[] GetGreaterEqual(int[] arrInt, int val)
        {
            int[] arrResult = new int[10];
            int j = 0;
            for (int i = 0; i < arrInt.Length; i = i + 1)
            {
                if (arrInt[i] >= val)
                {
                    arrResult[j++] = arrInt[i];
                }
            }

            return arrResult;
        }

        static decimal[] GetGreaterEqual(decimal[] arrInt, decimal val)
        {
            decimal[] arrResult = new decimal[10];
            int j = 0;
            for (int i = 0; i < arrInt.Length; i = i + 1)
            {
                if (arrInt[i] >= val)
                {
                    arrResult[j++] = arrInt[i];
                }
            }

            return arrResult;
        }


        static int[] GetGreater(int[] arrInt, int val)
        {
            int[] arrResult = new int[10];
            int j = 0;
            for (int i = 0; i < arrInt.Length; i = i + 1)
            {
                if (arrInt[i]> val)
                {
                    arrResult[j++] = arrInt[i];
                }
            }

            return arrResult;
        }

        static int[] GetEven(int[] arrInt)
        {
            int[] arrResult = new int[10];
            int j = 0;
            for (int i = 0; i < arrInt.Length; i = i + 1)
            {
                if (arrInt[i] % 2 == 0)
                {
                    arrResult[j++] = arrInt[i];
                }
            }

            return arrResult;
        }




    }


    
}


/*
 *  MyFunc<int,Boolean> func = Greater;

            MyFunc<int,int, Boolean> funcLess = MLess;

            MyFunc<int, Boolean> funcX = (X) => {
                return X > 2;
                }
            ;

            MyFunc<int, Boolean> funcX2 = X => X > 4;


            GetData(X => X > 6);

            GetData(X => X > 1);
            
            var output = func(3);

            output = funcLess(3,3);

            List<string> strLst = new List<string>();
            strLst.Add("Rupal");
            strLst.Add("Ayushi");
            strLst.Add("Anushri");
            strLst.Add("Abhay");
            strLst.Add("Manish");

            int[] arrInt = { 1, 2, 4, 6, 7, 9, 12, 45 };

            int[] arrResult = GetValues(arrInt,X=>X> 9 );
            arrResult = GetValues(arrInt, X=>X==9);
            arrResult = GetValues(arrInt,X=> X<9);
            arrResult = GetValues(arrInt, X => X %2==0);
            Console.Read();
            decimal[] arrDecimal = { 1, 2, 4, 6, 7, 9, 12, 45 };

            decimal[] arrDResult = GetValues(arrDecimal, X => X % 2 == 0);

            string[] strArra = { "Abhay", "Ayushi", "Rupal", "Manish", "Amruta" };

            string[] arrSResult = GetValues(strArra, X => X.ToLower().Contains("r"));

            Employee[] empArr = { new Employee { Name="Abhay" },
                new Employee { Name="Ayushi" },
                 new Employee { Name="Rupal" },
                 new Employee { Name="Amruta" }
                };


            Employee[] arrEResult = GetValues(empArr, X => X.Name.ToLower().Contains("r"));

 * 
 * static void Main(string[] args)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("id", "1");
            d.Add("name", "Abhay");

            d.Add("salary", "1.0");

            d.Add("department.name", "Dotnet");

            d.Add("department.id", "1");

            d.Add("department.address.address1", "Kharadi");

            d.Add("department.address.address2", "Eon");

            Employee e = new Employee();

            Address address = new Address();

      var objreturn= Binders.MyModelBinder(address, d, "department.address");

         //   Console.WriteLine(e.Name);

            Console.Read();
        }

 * 
 *    public static dynamic ConvertData(string value, Type type)
        {

            return Convert.ChangeType(value, type);
        }


        public static T MyModelBinder<T>(T obj,Dictionary<string,string> d)
        {
            Type type = obj.GetType();

          var propInfoArray=  type.GetProperties();

            foreach (PropertyInfo item in propInfoArray)
            {
                if (d.ContainsKey(item.Name))
                {

                    item.SetValue(obj, ConvertData(d[item.Name],Type.GetType(item.PropertyType.ToString())));

                    //if (item.PropertyType.Name == "Int32"){
                    //    item.SetValue(obj, Convert.ToInt32( d[item.Name]));
                    //}   else if (item.PropertyType.Name == "Decimal")
                    //{
                    //    item.SetValue(obj, Convert.ToDecimal(d[item.Name]));
                    //}
                    //else
                    //{
                    //    item.SetValue(obj, d[item.Name]);
                    //}


                    //"Decimal"


                }
            }
            return obj;
        }
      */