看到这里觉得可以分享一下自己的注释，其实很多注释是可以自定义的。

定义成模板在自己的 IDE 上，这样每次通过快捷键就可自动帮你输出在方法中，省去了很多时间，也使代码更加规范。

下面已 eclipse 为例，分析一下自己的。

我是加载了 JAutodoc 插件在 IDE 中，习惯这种格式的小伙伴也可以去下载一下。

首先是在文件头部添加：

/*
 * <p>项目名称: ${project_name} </p> 
 * <p>文件名称: ${file_name} </p> 
 * <p>描述: [类型描述] </p>
 * <p>创建时间: ${date} </p>
 * <p>公司信息: ************公司 *********部</p> 
 * @author <a href="mail to: *******@******.com" rel="nofollow">作者</a>
 * @version v1.0
 * @update [序号][日期YYYY-MM-DD] [更改人姓名][变更描述]
 */
方法：

/**
 * @Title：${enclosing_method}
 * @Description: [功能描述]
 * @Param: ${tags}
 * @Return: ${return_type}
 * @author <a href="mail to: *******@******.com" rel="nofollow">作者</a>
 * @CreateDate: ${date} ${time}</p> 
 * @update: [序号][日期YYYY-MM-DD] [更改人姓名][变更描述]     
 */
getter 和 setter

/**
 * 获取  ${bare_field_name}
 */



/**
 * 设置   ${bare_field_name} 
 * (${param})${field}
 */
