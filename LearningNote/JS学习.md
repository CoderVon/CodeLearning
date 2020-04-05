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