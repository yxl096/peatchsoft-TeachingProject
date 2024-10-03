namespace 战斗小游戏
{
    /// <summary>
    /// Author: 上单
    /// Description: 前排的觉悟
    /// </summary>
    class 前排的觉悟 : 技能
    {
        public 前排的觉悟()
        {
            Name = "前排的觉悟";
            技能描述 = "当技能持有者和希亚同时在场时，替希亚抵挡所有伤害";
            是主动技能 = false;
            有效目标 = 允许目标.自己;
        }
        public override void 被动效果(角色 技能持有者)
        {
            // buff加给希亚
            foreach (var 角色 in 战斗管理器.GetInstance().友方)
            {
                if(角色.Name == "希亚")
                {
                    角色.AddBuff(new 希亚的狗_被动(Name, 技能持有者));
                }
            }
            

        }
        public override 技能状态 释放合法性检查(角色 释放者)
        {
            return 技能状态.被动技能;
        }
    }
}