using System;
using System.Collections.Generic;

namespace GenericType
{
    class Program
    {
        void Main(string[] args)
        {
            var stack = new Stack<int>();//在运行时，所有的泛型类型实例都是封闭的（占位符类型已经被填充了）
            stack.Push(5);
            stack.Push(10);
            int x = stack.Pop();//x=10
            int y = stack.Pop();//y=5
            Swap<int>(ref x, ref y);//在这种情况加<int>可不写，但是为了防止出现歧义（例如需要类型是long但是默认判断的类型是int）所以写上以防万一


            //开放的泛型类型在编译后就变成了封闭的泛型类型
            //但是如果只是作为Type对象，那么未绑定的泛型类型在运行时（runtime）是可以存在的，不过只能通过Typeof操作符实现
            Type a = typeof(Stack<>);


            //对于每一个封闭类型，静态数据是唯一的
            Console.WriteLine(++Stack<int>.count);//1
            Console.WriteLine(++Stack<int>.count);//2
            Console.WriteLine(++Stack<string>.count);//1
            Console.WriteLine(++Stack<object>.count);//1



            //协变 当值作为返回值/out输出 协变的原理是把子类指向父类的关系，拿到泛型中
            //逆变 当值作为输入/in 逆变的原理是把父类指向子类的关系，拿到泛型中
            //逆变与协变只能放在泛型接口和泛型委托的泛型参数里面
            //不变 当值既是输入又是输出

            IEnumerable<string> strings = new List<string> { "a", "b", "c" };
            IEnumerable<object> objects = strings;//不会报错，因为这是协变（值作为输出），而object比string大

            IList<string> strings1 = new List<string> { "a", "b", "c" };
            //IList<object> objects1 = strings1;//报错，因为这是不变

            Action<object> objectAction = obj => Console.WriteLine(obj);
            Action<string> stringAction = objectAction;//不会报错，因为这是逆变（值作为输入），而object比string大；

            void Swap<T>(ref T a, ref T b)//泛型方法
            {
                T temp = a;
                a = b;
                b = temp;
            }
            static void Zap<T>(T[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = default(T);//可以使用default来获取泛型类型参数的默认值
                }
            }

        }
    }
    //泛型类型 带有“（类型）占位符”的一种“模板”
    //泛型会声明类型参数-泛型的消费者需要提供类型参数（argument）来把占位符类型填充上
    //声明class、struct、interface、delegate的时候可以引入类型参数，其他的例如实行就不可以引入类型参数,但是可以使用类型参数
    //泛型类型和泛型方法可以使用引入多个类型参数，如class Directionary<Tkey,TValue>{.......}
    //泛型类型哥泛型方法的名称可以被重载，条件是参数类型的个数不同；如class A{}   class A<T>{}   class A<T1,T2> 都不冲突
    //按照约定，泛型类型和泛型方法如果只有一个类型参数，那么就叫T，如果有多个类型参数，那么每一个类型参数都是用T作为前缀，后面跟着一个描述性的名字
    public class Stack<T>//泛型类型 开放类型
    {
        int position;
        public static int count;
        T[] data = new T[100];
        public void Push(T obj) => data[position++] = obj;
        public T Pop() => data[--position];
    }
    //泛型的约束
    //默认情况，泛型的类型参数可以是任意类型的；
    //如果想要只允许使用特定的类型参数，就需要指定约束
    /*
     where T : base-class // Base-class constraint
     where T : interface // Interface constraint
     where T : class // Reference-type constraint
     where T : struct // Value-type constraint (excludes Nullable types)
     where T : new() // Parameterless constructor constraint
     where U : T // Naked type constraint
     */

    class SomeClass { }
    interface interface1 { }
    class GenericClass<T,U>where T:SomeClass,interface1 where //泛型类型约束为T必须是SomeClass的子类且实现了interface1接口
                                 U: new()//U必须有无参构造函数
    {
        //.....
    }

    //泛型类型可以有子类,可以让父类的类型参数保持开放
    class SpecialStack<T> : Stack<T>
    { }
    //也可以使用具体的参数来关闭父类的参数类型
    class IntStack : Stack<int>
    {}
    //子类型也可以引入新的类型参数
    class ListA<T>//父类
    {}
    //子类
    class KeyedLista<TEnement, TKey> : ListA<TEnement>//所有子类的类型参数都是新鲜的，可以认为子类先把父类的类型参数关闭了再打开，可以为这个打开的类型参数带来新的名称或者含义
    { 
    }
}
