using System;

namespace DelegatesAndEventAndLambda
{
    public delegate int Transformr(int x);//这个委托返回值和参数都为int，可以调用返回值和参数都为int的方法
    class Util
    {
        public static void Transform(int[] values, Transformr t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
        }
    }

    public delegate T Transformer<T>(T args);//委托可以是泛型的
    class UtilGeneRic
    {
        //public static void Transform<T>(T[] values, Transformer<T> t)
        public static void Transform<T>(T[] values, Func<T,T> t)//效果同上
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
        }
    }
    class Program
    {
        static int Square(int x) => x * x;
        static void Main(string[] args)
        {
            //委托类型定义了委托实例可以调用的那类方法，具体来说委托类型定义了方法的返回类型和参数
            Transformr t = Square;//把方法赋值给委托变量的时候就创建了委托实例 正规写法：Transformr t=new Transformr(Square)
            //在这里通过委托调用Square方法，使得调用者（Main）和被调用者（Square）解耦了
            int answer = t(3);//answer=9;委托实例调用目标方法 正规写法int answer=t.Invoke(3);
            int[] values = { 1, 2, 3 };
            Util.Transform(values, Square);
            foreach (int i in values)
            {
                Console.WriteLine($"{i} ");
            }
            //泛型委托
            UtilGeneRic.Transform<int>(values, Square);
            foreach (var i in values)
            {
                Console.WriteLine($"{i} ");
            }
            //Func就是一种封装好的泛型委托，最后一个参数是输出，返回类型和最后一个参数一致，其他参数是输入，若只有一个参数，那这个参数是输出
            //Action无返回类型，所有参数都是输入


            //多播委托
            /*
             * 使用+和+=操作符可以合并委托实例
             * SomeDeleGate d=SomeMethod1;
             * d+=SomeMethod2;
             * 这样子调用d就会调用SomeMethod1和SomeMethod2；而委托的调用顺序和它们的定义顺序一致
             * 同理-和-=类似
             * 委托的使用+-时操作数可以是null，
             * SomeDelegate d=null;
             * d+=SomeMethod1;
             * 上面两句相当于d=SomeMethod1；
             * 
             * 注意：委托实质是不可变的，使用+=或者-=时，时机上是创建了新的委托实例，并把它赋给当前的委托变量
             * 如果多播委托的返回类型不是void，那么调用者会从最后一个被调用的方法来接收返回值，前面的方法仍然会被调用，但是其返回值就被丢弃了
             */

            //委托能解决的问题，接口都可以解决
            //但是在以下条件之一满足时，更适合使用委托
            //1.接口只能定义一个方法
            //2.需要多播能力
            //3.订阅者需要多次实现接口

            //委托类型之间无论怎么都互不相容，只要名字不一样就不一样
            //若委托实例拥有相同的目标方法，则委托实例被认为是相等的

            //委托的兼容性-参数
            //当调用一个方法时，委托的参数可以比方法的参数更加具体（即委托参数是方法的子类依旧可以调用）
            //例子如下
            //delegate void StringAction(string s);
            //static void ObjectAction(object o) => Console.WriteLine(o);
            //StringAction sa = new StringAction(ObjectAction);
            //sa("Hello");

            //委托的兼容性-返回类型
            //调用方法时，可以得到一个比请求的类型更具体的类型的返回结果
            //例子如下
            //delegate object ObjectRetriever();
            //static string RetrieveString() => "Hello"; 
            //ObjectRetriever o= new ObjectRetriever(RetrieveString);
            //object result= o()


         
        }
        //Evevt事件
        //使用委托的时候通常会出现两个角色：广播者，订阅者
        //广播者这个类型包含一个委托字段，广播通过调用委托来决定什么时候进行广播
        //订阅者是目标方法的接收者，订阅者可以决定何时开始或结束监听，方法是通过在委托上调用+=和-=；
        //一个订阅者不知道和不敢让其他的订阅者。

        //事件就是将上述模式正式化的一个语言特性
        //事件是一种结构，为了实现广播者/订阅者模型，它只暴露了所需的委托特性的部分子集
        //事件的主要目的就是防止订阅者之间相互干扰
        public delegate void PriceChangeHandler(decimal oldPrice, decimal newPrice);
        class EventCase
        {
            public event PriceChangeHandler PriceChanged;//声明一个事件
            //在EventCase里面的代码拥有对PriceChanged的完全访问权
            //在EventCase外面的代码只能对PriceChanged这个event进行+=和-=操作；
        }
        //Lambda表达式
        class LambdaExpression
        {
            //Lambda表达式其实就是一个用来代替委托实例的未命名的方法;
            //编译器会把Lambda表达式转换为一个委托实例或者一个表达式树
            delegate int Transformer(int i);
            void main()
            {

                //lambda表达式的形式
                //（参数）=>表达式或语句块
                //每个lambda表达式的参数对应委托的参数，表达式的类型对应委托的返回类型
                //其中若只有一个参数并且类型可推断的话参数的小括号可以省略，如下
                Transformer sqr = x => x * x;//相当于调用了一个方法，这个方法的参数是x，返回值是x*x；
                Transformer sqr1 = x => { return x * x; };//效果相同

                Console.WriteLine(sqr(3));//9
                Console.WriteLine(sqr1(3));//9

                //lambda表达式通常和Func合Action委托一起使用
                Func<int, int> sqr2 = x => x * x;
                Func<string, string, int> totalLength = (s1, s2) => s1.Length + s2.Length;
                int total = totalLength("hello", "world");//total=10;

                void Foo<T>(T x) { }
                void Bar<T>(Action<T> a) { }
                void MyMethod()
                {
                    //由于无法推断出类型，需要显式指定类型
                    Bar((int x) => Foo(x));
                    Bar<int>(x => Foo(x));
                    Bar<int>(Foo);
                    //lambda表达式可以捕获变量
                    //捕获了外部变量的lambda表达式叫做闭包
                    //被捕获的变量实在委托被实际调用的时候才被计算，而不是在捕获的时候，详见下四行
                    int factor = 2;
                    Func<int, int> multiplier = n => n * factor;//已经捕获了外部变量，但是没有调用委托
                    factor = 10;
                    factor = multiplier(3);//=30

                    //lambda表达式本身也可以更新被捕获的变量,被捕获的变量生命周期会被延长到合委托一样
                    int seed = 0;
                    Func<int> natural = () => seed++;
                    Console.WriteLine(natural());//0;
                    Console.WriteLine(natural());//1
                    Console.WriteLine(seed);//2;;
                    //lambda表达式内实例化的本地变量对于委托实例的每次调用来说都是唯一的
                    static Func<int> Natural()
                    {
                        return () => { int seed = 0; return seed++; };
                    }
                    static void Other()
                    {
                        Func<int> natural = Natural();
                        Console.WriteLine(natural());//0
                        Console.WriteLine(natural());//0
                    }
                }

            }
            
        }
    }

}