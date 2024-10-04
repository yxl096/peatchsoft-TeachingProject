namespace 战斗小游戏
{
    /// <summary>
    /// 负责人: 陈
    /// Description: 为所有敌方单位添加 罪恶 buff
    /// </summary>
    class 秩序 : 技能
    {
        public 秩序()
        {
            Name = "秩序";
            技能描述 = "为所有敌方单位添加罪恶buff，每当对方发动攻击时会积累相当于初始伤害的罪恶值";
            是主动技能 = false;
            有效目标 = 允许目标.敌方全体;
        }

        public override void 被动效果(角色 技能持有者)
        {
            角色[] 敌方全体 = 战斗管理器.GetInstance().敌人;
            // 为敌方全体增加罪恶值机制buff
            foreach (var 角色 in 战斗管理器.GetInstance().敌人)
            {
                角色.buff池.Add(new 罪恶值系统(Name));
            }
        }

        public override 技能状态 释放合法性检查(角色 释放者)
        {
            return 技能状态.被动技能;
        }
    }
}
