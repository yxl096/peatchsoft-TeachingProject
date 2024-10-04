namespace 战斗小游戏
{
    /// <summary>
    /// 负责人: 上单
    /// Description: 前排的觉悟
    /// </summary>
    class 希亚的狗 : 技能
    {
        int 减伤概率;
        int 减伤倍率;
        public 希亚的狗(int 减伤概率, int 减伤倍率)
        {
            Name = "希亚的狗";
            技能描述 = $"当技能持有者和希亚同时在场时，替希亚抵挡所有伤害，并有{减伤概率}%的概率将本次伤害减少{减伤倍率}%";
            是主动技能 = false;
            有效目标 = 允许目标.自己;
            this.减伤概率 = 减伤概率;
            this.减伤倍率 = 减伤倍率;
        }

        public override void 被动效果(角色 技能持有者)
        {
            // buff加给希亚
            foreach (var 角色 in 战斗管理器.GetInstance().友方)
            {
                if(角色.Name == "希亚")
                {
                    角色.buff池.Add(new 援护友军_希亚的狗(Name, 技能持有者, 减伤概率, 减伤倍率));
                }
            }
        }

        public override 技能状态 释放合法性检查(角色 释放者)
        {
            return 技能状态.被动技能;
        }
    }
}