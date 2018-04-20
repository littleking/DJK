using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class EnumHelper
    {
    }

    /// <summary>
    /// 窗体打开模式枚举
    /// </summary>
    public enum FormModelType
    {
        FormModelView = 0, //查看
        FormModelAdd = 1, //新增
        FormModelEdit = 2, //修改
        FormModelAudit = 3, //审核
    }
}
