# CSS学习记录

## 创建css的方法
1. 使用元素内嵌样式表 元素内
2. 使用文档内嵌样式表 head内
3. 使用外部样式表 导入方式：\<link href="1a.css" rel="stylesheet" type="text/css" /> 


## Style元素
      font-size 控制文本大小
      color 控制文本颜色
      border 边框设置
            -border-width 边框宽度
            -border-style 边框样式
            -border-color 边框颜色
            -border-up 上边框 其他同理
            -border-radius 设置圆角边框；border-radius:20px/15px 为设置圆心离边框左右距离20px,上下距离15px的四个圆角
      background 背景设置
            -background-color 背景颜色
            -background-position 背景位置
            -background-size 背景图像尺寸
            -background-repeat 背景重复方式
            -background-origin 
            -background-clip
            -background-attachment 设置背景是否随滚轮移动
            -background-image 设置背景图片
      text 文本设置
            -text-align 对齐方式
            -direction 书写方向,对中文没什么用处
            -letter-spacing 字间距
            -word-spacing 单词间距 英语有效
            -line-height 行高
            -text-indent 首行缩进
            -text-decoration 文本装饰
            -text-transform 文本大小写转换
            -text-shadow 文本阴影，参数为 水平阴影距离 竖直阴影距离 模糊程度 颜色
      font 字体设置
            -font-family 显示字体
            -font-size 字体大小
            -font-style 字体类型
            -font-variant 小型大写字母
            -font-weight 字体粗细设置
      transition 过渡设置
            -transition-delay 延迟时间
            -transition-duration 动画时间
            -transiton-property 控制过渡的属性是哪个
            -transiton-timing-function 过渡使用的贝塞尔曲线
      animation 动画设置
            -transition-delay 延迟时间
            -transition-duration 动画时间
            -transition-name 动画名字 动画名字在@keyframes中使用;@keyframes中效果是从from到to的
            -transition-iteration-count 动画次数 从from到to算一次，反过来也算一次
            -animation-direction 动画方向
            -animation-fill-mode 规定填充格式 常用forwards使动画最后停留在最后一帧
      transform 变换设置
            -transform:rotate(ndeg) 旋转变换n度
            -transform:scale(n) 缩放n倍
            -transform-origin 锚点
## 基本选择器
- ### 根据类型选择元素
       - a{ }则为\<a>标签选择器
- ### 选择所有元素
       - *{ }为所有选择器
- ### 根据类选择元素
      - 标签内属性class="a"，这个是一个全局属性
      - .a{}为类a的选择器
- ### 根据ID选择元素
      - 标签内属性id="b"，每个元素id唯一，这个是一个全局属性
      - #b{}为id为b的选择器
- ### 根据属性选择元素
      - 标签内任意属性都可以使用 例如herf
      - [herf]{}为属性有herf的选择器
      - [herf:11.html]{}为属性有herf:11.html的选择器
- ### :选择器动作
      - a:hover{}为冒号选择器，有很多种
## 各浏览器私有属性
      -webkit chrome、safari私有属性
       -o Opera私有属性
      -moz firefox浏览器私有属性
      -ms IE浏览器私有属性
## 盒子模型
![avater](https://img-blog.csdn.net/20140124141001609?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvenl1eml4aWFv/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)
