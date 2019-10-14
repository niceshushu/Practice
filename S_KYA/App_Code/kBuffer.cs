using S_KYA_Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public partial class kBuffer
{
    public kBuffer()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }


    #region 系统菜单档案
    private static List<Mod_Sys_Menu> Table_Sys_Menu = null;
    public static List<Mod_Sys_Menu> _Table_Sys_Menu
    {
        get
        {
            if (Table_Sys_Menu == null)
            {
                _Fresh_Table_Sys_Menu();
            }
            return Table_Sys_Menu;
        }
    }

    private static void _Fresh_Table_Sys_Menu()
    {
        Table_Sys_Menu = S_KYA_Core.Bll.Bll_Sys_Menu.Instance.GetList(null);
    }

    #endregion
}