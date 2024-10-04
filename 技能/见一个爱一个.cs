namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 实例技能-牢饼
    /// </summary>
    class 见一个爱一个 : 技能
    {
        public 见一个爱一个()
        {
            Name = "见一个爱一个";
            技能描述 = "普通攻击可以同时攻击到所有敌方角色(伤害倍率：70%)";
            是主动技能 = false;
            有效目标 = 允许目标.敌方全体;
        }

        public override void 被动效果(角色 技能持有者)
        {
            Console.WriteLine($"{技能持有者.Name} 发动技能 {Name}");
            Console.WriteLine($"技能 {Name} 使 {技能持有者.Name} 的普通攻击可以攻击所有敌人");
            // 为技能持有者提供一个buff
            技能持有者.buff池.Add(new 顺劈_被动(Name, 70));
        }

        public override 技能状态 释放合法性检查(角色 释放者)
        {
            return 技能状态.被动技能;
        }
    }
}
