# HTML学习记录
## html注释
    <!-- -->
    <br/>换行
## html基本结构
    <!DOCTYPE html><!--这是让浏览器得知自己要处理的内容是html-->
    <html><!--文档中html部分的开始-->
    <head><!--提供有关文档内容合标注信息的-->
         <meta charset==="UTF-8"><!--meta 提供元数据-->
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>这是标题</title><!--用于标题的显示-->
    </head>
    <body>
         <h1>这个更大</h1>
         靠谱学院
         大家好，我是大哥
    </body>
    </html>
## html基础
    \<a> 超链接
    \<b> 粗体
    \<u> 下划线
    \<s> 删除线
## 表格
    <table>用于创建一个表格
    <tr>创建一行表格 table row
    <td>表格数据 table data
        <td colspan="2"> 表示两行单元格合并成一个
        <td rowspan="2"> 表示两列单元格合并成一个
    <th>表格的头部使用，使得字体居中加粗 table head
    <thead>表头
    <tbody>表中
    <tfoot>表脚
## 列表
    <ol>定义有序列表项
        <<ol type="a">>type决定有序列表排序的字是abcd或者1234等等
        <ol reversed>列表名称反转，如4321
    <ul>无列表
    <li>具体的一项
## 表单
表单是用于用户输入的窗口<br>

### 关键表单元素

 1.  \<form> 表单
        - 属性
            -  method
            - action  
 2.  \<input> 单行文本框
        - 属性
            -  type
                  - text 单行文本框
                  - password 密码
                  - button 按钮 无法与js协作
                  - submit 提交表单
                  - range 滑块 提供数字
                    - min 最小值
                    - max 最大值
                    - step 步长
                  - number 数字 手动输入
                    - min
                    - max
                  - checkbox 单选框
                  - radio 单选框 选中不可取消 若属性name相同则为同一组 其中一个必定选中
                  - email 检测格式
                  - tel 检测格式
                  - url 检测格式
                  - date 获取时间
                  - color 获取颜色
                  - search 搜索框
                  - hidden 蕴藏 但是提交表单时依然存在
                  - image 图片按钮 src中填入图片路径 width填入宽度 
                  - file 获取文件 multiple一次允许多个文件 Required必须上传一个文件 在使用input元素上传文件提交表单时要在form设置\<enctype="multipart/form-data">
            -  value 占位符
            -  placeholder 不占位仅显示
            -  maxlength 最大长度
            -  size 控制单行文本框可输入文本长度
            -  readonly 只读
            -  list 与下文中datalist的id用同一个key
 3.  \<textarea> 多行文本框
        - 属性
            - rows 行长
            - cols 列长
1.  \<button> 按钮 通过onclick用来和js协作的 
2.  \<select> \<option> 下拉选项 不能自行输入
3.  \<datalist>\<option>  下拉选项 可以自行输入，必须搭配input使用 需要填写ID属性与一个input里的list属性对应
4.  \<img>图片 alt为备用内容

## 客户端分区响应图
\<map> 是客户端分区响应图的关键元素<br>
\<area> 可以有多个，每个各自代表图像上可以被点击的一块区域
- shape coord属性的值解析 分为rect（有四个整数组成，分别为图像的左边缘、上边缘、右边缘、下边缘） circle(三个整数组成，分别为圆心坐标，圆的半径) poly default 
- coords
- herf 链接
- alt 备用内同

## 视频播放
\<video> 播放视频 可以嵌入\<source>
src视频地址 <br>
width视频宽度  <br>
height视频长度  <br>
autoplay网页完成后自动播放视频  <br>
controls增加进度条和暂停控制<br>
preload预先载入视频（None-不会载入 Metadata载入第一帧 Auto载入整个视频为默认状态） <br>
loop循环播放<br>
poster封面<br>
<br>
\<source> 视频源，若video标签的视频无法播放会跳入source寻找视频播放

## 音频播放
\<audio> 播放音频 
和视频播放参数基本一样



  


    