namespace 战斗小游戏
{
    /// <summary>
    /// 负责人: 陈
    /// Description: 硬化皮肤被动技能：减免25%的伤害
    /// </summary>
    class 硬化皮肤 : 技能
    {
        public 硬化皮肤(int 减伤倍率)
        {
            Name = "硬化皮肤";
            技能描述 = $"减免{减伤倍率}%的伤害";
            是主动技能 = false;
            有效目标 = 允许目标.自己;
            倍率 = 减伤倍率;
        }

        public override void 被动效果(角色 技能持有者)
        {
            Console.WriteLine($"{技能持有者.Name} 发动技能 {Name}");
            // 为技能持有者提供一个buff
            技能持有者.buff池.Add(new 受到伤害降低_被动(Name, 倍率));
        }

        public override 技能状态 释放合法性检查(角色 释放者)
        {
            return 技能状态.被动技能;
        }
    }
}
