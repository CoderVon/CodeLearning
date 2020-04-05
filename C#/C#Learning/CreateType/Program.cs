using System;

namespace CreateType
{

    [Flags]//若枚举成员可组合，就应该加上[Flags],若不使用的话，调用实例的tostring输出的是数值而不是名称
    public enum Borders//组合枚举
    {
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8
    }
    class Program
    {
        static void Main(string[] args)
        {
            ObjectInstiaterCase();
            AsandIs();



            //对象初始化器
            void ObjectInstiaterCase()//对象初始化器相关
            {
                Panda p1 = new Panda { name = "p1", age = 11 };//对象初始化器，可以在构造对象时直接初始化对象的public数值；
                Panda p2 = new Panda("p2") { age = 122 };//这个例子是对象初始化器使用了一个参数的构造函数的情况下同时初始化了public的变量
            }
            //As Is操作符
            void AsandIs()
            {
                Parent parent = new Parent();
                Son son = new Son();
                son = parent as Son;//AS会执行向下转换，若转换失败不会抛出异常，而是返回null；
                //long x = 3 as long;//as无法做自定义转换
                if (son is Parent)//判断son是否使parent的子类，用于向下转换前的验证
                {
                    Console.WriteLine("son is parent");
                }
                if (son is Parent p)//判断son是否是parent的子类，则执行p=(Parent)son;
                {
                }
            }
            //将对象隐式转换为接口
            void InterFaceUse()
            {
                FooTry t = new FooTry();
                t.Do();
                ((Ifoo)t).Do();
                ((Ibar)t).Do();
            }
            //组合枚举
            void ManyEnum()
            {
                var b = Borders.Top | Borders.Right | Borders.Bottom;//b为top或right或bottom
                /*
                Top:      00000001
                Right:    00000010
                Bottom:   00000100
                ----------------------
                b:        00000111
                */
                var c = b & Borders.Right;//通过这种操作检查b中是否有Right；
                /*
                b:        00000111;
                Right:    00000010
                -----------------------
                c:        00000010
                */

                Borders side = (Borders)1233;
                Enum.IsDefined(typeof(Borders), side);//false 可通过Enum.IsDefined来检查枚举值是否合理
            }


        }
    }
    class Expression_bodied//=>可以简单描述retuan或一个简单的方法体，适用于单表达式；
    {
        int Foo1(int x)
        {
            return x * 2;
        }
        int Foo2(int x) => x * 2;

        void Foo3(int x) => Console.WriteLine(x);

    }
    class OverLoad//方法的重载,方法的签名
    {
        void Foo(int x) { Console.WriteLine(x); }
        void Foo(double x) { Console.WriteLine(x); }
        //方法的签名不一样才可重载，返回值不影响方法的签名
        //如下
        //int Foo(int x) { return x; }//返回值不影响签名，参数类型和顺序才影响签名
        //int Foo(int[] x){}
        //int Foo(Params int[] x){}//Params关键字不影响签名

        //值传递和引用传递的区别会影响方法的签名
        void Foo2(int x) { }
        void Foo(ref int x) { }
    }
    class LoaclFunction//C#7特性 本地方法
    {
        void WriteCubes()
        {
            Console.WriteLine(Cubes(3));

            int Cubes(int value)//方法体内部可以声明一个新的方法(本地方法)
            {
                value = 2 * value;
                int Cube(int value) => value * value * value;//本地方法可以套娃 本地方法不可以使用static
                return (Cube(value));
            }

        }
    }
    class Panda//构造函数与解构函数(Deconstruct)实例 解构函数是C#7的特性
    {
        //字段的初始化
        public string name;
        public int age;

        static Panda()//静态构造函数，只能有一个且无参，在类型使用之前的一瞬间，编译器会调用类型的静态构造函数，之云逊用unsafe和extern修饰符
        {
            Console.WriteLine("Panda初始化了");
        }
        //若没有任何构造函数 编译器会帮忙生成一个无参构造函数
        public Panda() { }

        //当一个构造函数A调用构造函数B时，B先执行；
        public Panda(string n) => name = n;//新特性后构造函数可以使用这种形式

        //可以把表达式传递给另一个构造函数，但表达式本身不能使用this引用，因为这个时候对象还没被初始化，所以任何方法的调用都会失败，但是可以使用static方法
        public Panda(string n, int a) : this(Panda.GetAge()) //构造函数的重载，重载内可用this代替前面的构造函数 
        {
            age = a;
        }
        public static string GetAge()
        {
            return "Panda";
        }

        public static Panda CreateInstance(string n)//若构造函数不是public的 就需要一个静态的方法给外部调用，否则外部无法调用构造函数
        {
            return new Panda(n);
        }
        //public Panda(string n)
        //{
        //    name = n;
        //}

        public void Deconstruct(out string Name, out int Age)//解构函数用于在销毁对象时将参数传到外部，解构函数名字必须为Deconstruct；
        {
            Name = name;
            Age = age;
        }
        public void Deconstruct(out string Name)//解构函数可被重载； 解构函数也可以是扩展方法Extensions
        {
            Name = name;
        }
        //外部调用结构函数例子
        //var panda=new Panda("nike",3);
        //(string myname,int myage)=panda;//调用解构函数形式1
        //panda.Deconstruct(out string myname,out int myage);//调用解构函数形式2
    }
    class PropertyiesandField//属性与字段
    {
        //属性与字段的区别，字段与属性访问方式相同，但是属性赋予了实现者对获取和赋值的完全控制，允许实现者选择任意所需的内部表示，不向使用者公开内部实现细节
        public decimal price;//字段

        decimal currentPrice;//幕后字段Backing Field 用来存储属性的数据
        public decimal CurrentPrice//属性
        {
            get { return currentPrice; }//get访问器会在属性被读取的时候运行，必须返回一个该属性的值；若只有get访问器，则属性为只读
            set { currentPrice = value; }//set访问器会在属性被赋值的时候运行，有一个隐式的该类型的参数Value;若只有set访问器，则属性为只写；
        }

        //C#6后，只读属性可以直接用EB形式表示
        public decimal worth => currentPrice;
        //c#&后，set也可以用EB形式表示
        public decimal worth1
        {
            get => currentPrice;
            set => currentPrice = value;
        }
        //自动属性与属性初始化器，属性初始化器可以初始化属性
        public decimal auto { get; private set; } = 123;//get与set可以有不同的访问级别

    }
    class Indexer//索引器
    {
        //索引器提供了一种可以访问封装了的列表值或字典值得class/sturct元素的一种自然的语法
        //语法很像使用数组时的语法，方式这里的索引参数可以是任何类型的
        string s = "hello";
        string[] words = "i am superman".Split();

        //实现索引器的方法
        public string this[int wordNum]
        {
            get { return words[wordNum]; }
            set { words[wordNum] = value; }
        }

        void show()
        {
            Console.WriteLine(s?[0]);//索引器可以使用null条件操作符
        }
    }
    class Parent//继承 父类
    {
        public string name;
        virtual public void show()//virtual 可使子类能够重写这个方法
        {
            Console.WriteLine(name);
        }
    }
    class Son : Parent  //继承 子类
    {
        public long money;
        public override void show()
        {
            Console.WriteLine(money.ToString());
        }
    }
    public struct House
    {
        //struct有一个无参的构造函数，但是不能对其进行重写。这个构造函数会对字段进行按位归零操作

        //int x = 1;//struct不可以有字段初始器
        int x, y;
        public House(int x, int y)//当定义struct构造函数的时候，必须显式的为{每}一个字段赋值
        {
            this.x = x;
            this.y = y;
        }
    }
    public interface Ifoo//接口
    {
        void Do();//接口中只能有方法的规格，不能有具体实现；且接口内的方法都是隐式public的，无法添加访问修饰符
    }
    public interface IfooSon : Ifoo//接口可继承
    {
        int ReDo();
    }
    public interface Ibar
    {
        int Do();
    }
    public class FooTry : Ifoo, Ibar//使用类实现接口,可以同时实现多个接口
    {
        public void Do()//
        {
            Console.WriteLine("Footry");
        }
        int Ibar.Do()//若实现多个接口方法时，方法的签名相同，则需要显式实现方法，调用这个方法需要先进行类型转换
        {
            Console.WriteLine("Ibar");
            return 0;
        }
    }

    public class NestType//嵌套类型 类型内可嵌套其他类型
    {
        public class imone { }
        public class imtwo { }
        struct imthree { }
        enum imfour { }
    }


}
