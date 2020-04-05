using System;
using System.IO;

namespace Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            static int Calc(int x) => 10 / x;

            //当异常被抛出时，CLR会执行一个测试，当前是否执行在能够catch异常的try语句里
            //如果是：当前执行就会传递给兼容的catch块里，如果catch块完成了执行，那么执行会移动到try语句后面的语句，如果有finally块存在，回想执行finally
            //如果不是：当前执行会返回到函数的调用者，并重复这个测试过程（在执行完任何包裹这语句的finally块后）
            try
            {
                int y = Calc(0);
                Console.WriteLine(y);
            }
            //catch字句指定要捕获的异常的类型，这个异常必须是system.Exception或者其子类
            //捕获System.exception这个异常的话就会捕获所有可能的错误
            catch (DivideByZeroException e) when (true)//c#6后，catch子句后面可以添加when子句，这样在when中的值为true时才会执行这个catch块的内容
            {
                Console.WriteLine("分母不能为0");
            }
            catch//可以捕获任何类型的异常
            {
                Console.WriteLine("???");
            }
            finally//唯一可以不让finally执行的东西就是无限循环或者程序突然结束
            { 
                Console.WriteLine("完");
            }
        }

        class UsingCase
        {
            void Case1()
            {
                using (StreamReader reader = File.OpenText("file.txt")) ;//效果同下面；实现了iDisposable接口的对象才能使用，会自动在finally中调用Dispose方法
                {
                    //balabala
                }

                StreamReader reader1 = File.OpenText("file.txt");//效果同上面
                try
                {
                    //balabala
                }
                finally
                {
                    if (reader1 != null)
                        ((IDisposable)reader1).Dispose();
                }
            }
        }
    }
}
