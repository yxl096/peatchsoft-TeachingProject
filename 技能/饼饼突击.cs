namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 示例被动技能
    /// </summary>
    class 饼饼突击 : 技能
    {
        public 饼饼突击()
        {
            Name = "饼饼突击";
            技能描述 = "普通攻击获得连击";
            是主动技能 = false;
            有效目标 = 允许目标.自己;
        }

        public override void 被动效果(角色 技能持有者)
        {
            Console.WriteLine($"{技能持有者.Name} 发动技能 {Name}");
            Console.WriteLine($"技能 {Name} 使 {技能持有者.Name} 的普通攻击获得连击");
            // 为技能持有者提供一个buff
            技能持有者.buff池.Add(new 连击_被动(Name, 100));
        }

        public override 技能状态 释放合法性检查(角色 释放者)
        {
            return 技能状态.被动技能;
        }
    }
}
