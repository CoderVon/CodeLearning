# JavaScript学习
## javascript嵌入方式
1. 通过\<script\>标签内直接内嵌，计较推荐内嵌到\<head>之间或者\</body>后面
2. 导入外链的js文件，形同\<script type="text/javascript" src="路径+文件名">\</script>
3. 行间事件，直接把js代码写入事件的简单操作（如鼠标点击移入等）中，形如\<input type="button" name="" id="button" onclick="JS代码"/>
## Javascript组成
- ECMAScript 编程语法和基础核心
- DOM 文档对象模型，控制网页元素等
- BOM 浏览器对象模型，与浏览器进行互动，弹出对话框获取分辨率等
## 输入输出语句
    prompt()//输入框
    alert()//弹出框
    console.log()//控制台输出
## JavaScript是弱类型语言，由值决定变量类型 
- number 最大值：MAX_VALUE 最小值：MIN_VALUE Infinity:无穷大 NaN：非数值
- boolean
- string ""和''均可表示字符串
- undefined 声明变量但未赋值的类型
- null 
- object
## 数据类型转换
转换为string：toString()、String()强制类型转换、通过"+"进行隐式转换
转换为number：parseInt()和parseFloat()、Number()强制类型转换、通过算术运算符(-*/)隐式转换
转换为Boolean：Boolean()；0、NaN、Null、undefined、空字符串转换为false,其他的为true;
## 运算符优先级
https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Reference/Operators/Operator_Precedence
## 数组 
- 尽量避免使用new Array()
- Array.length是可读写的；
- pop()和push()分别是在数组结尾弹出和压入数据
- shift()和unshift()则是在数组开头弹出和压入数据
## 函数
- 用function声明函数 function name(){}或者var name=function(){}
- 若实参个数多于形参，则多余的不传入
- 若实参个数少于形参，则视为没有接收值（undefined）
- arguments里存储了所有传递过来的实参
- es6以后才有块级作用域
## 对象
- 利用字面量{}创建对象 如var obj{}
- 对象内的属性或者方法采取键值对的形式 键 属性名：值 属性值
- 多个属性或者方法中奖用逗号隔开
    
        
        //创建对象方式1
        var man={
            name:"张三",
            age:18,
            sex:"男",
            say:function(){
                console.log("HelloWorld");
            }
        }

        //创建对象方式2 通过追加属性和函数
        man=new Object();//创建空对象
        man.name='张三';
        man.age=18;
        man.sex='男'；//追加属性
        man.say=function(){
            console.log("HelloWorld");
        }//追加函数

        //创建对象方式3 通过构造函数
        function Person(name,age,sex){
            this.name=name;
            this.age=age;
            this.sex=sex;
            this.say=function(){
            console.log("HelloWorld");
            }
        }
        man=new Person('张三',18,'男');


        //调用对象的属性的两种方法
        console.log(man.name);
        console.log(man['name']);
        调用对象的函数
        man.say();

        //遍历对象里的所有元素
        for(var k in man){
            console.log(k);//name age sex say
            console.log(man[k]);//张三 18 男 say(){console.log("HelloWorld");}
        }

## 预解析
1. js引擎运行js分为两步：预解析 代码执行
2. 预解析 js会把js里所有的var和function提升到当前作用域的最前面
3. 变量预解析：将所有的变量声明提升到当前作用域最前面 不提升赋值操作
4. 函数预解析：将所有的函数声明提升到当前作用域最前面 不调用函数
