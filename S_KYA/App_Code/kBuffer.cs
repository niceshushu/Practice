﻿using S_KYA_Core.Model;
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

    private static List<Mod_Sys_Btn> Table_Sys_Btn = null;
    public static List<Mod_Sys_Btn> _Table_Sys_Btn
    {
        get
        {
            if (Table_Sys_Btn == null)
            {
                _Fresh_Table_Sys_Btn();
            }
            return Table_Sys_Btn;
        }
    }

    public static void _Fresh_Table_Sys_Menu()
    {
        Table_Sys_Menu = S_KYA_Core.Bll.Bll_Sys_Menu.Instance.GetList(null);
    }
    public static void _Fresh_Table_Sys_Btn()
    {
        Table_Sys_Btn = S_KYA_Core.Bll.Bll_Sys_Btn.Instance.getSysBtnList(null);
    }

    #endregion

    #region 角色权限档案数据
    private static List<Mod_Sys_Author> Table_Sys_Author = null;
    public static List<Mod_Sys_Author> _Table_Sys_Author
    {
        get
        {
            if (Table_Sys_Author == null)
            {
                _Fresh_Table_Sys_Role_GroupRight();
            }
            return Table_Sys_Author;
        }
    }

    public static void _Fresh_Table_Sys_Role_GroupRight()
    {
        Table_Sys_Author = S_KYA_Core.Bll.Bll_Sys_Author.Instance.GetList(null);
    }
    #endregion
}