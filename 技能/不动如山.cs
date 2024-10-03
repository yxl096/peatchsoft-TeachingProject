namespace 战斗小游戏
{
    class 不动如山 : 技能
    {
        /// <summary>
        /// Author: 上单
        /// Description: 不动如山
        /// </summary>
        public 不动如山()
        {
            Name = "不动如山";
            技能描述 = "获得被动不动如山";
            是主动技能 = false;
            有效目标 = 允许目标.自己;
        }

        public override void 被动效果(角色 技能持有者)
        {
            // 加防御力
            技能持有者.防御力 = 技能持有者.防御力 + 114;
            // 为技能持有者提供一个buff
            技能持有者.AddBuff(new 不动如山_被动(Name, 85));
        }

        public override 技能状态 释放合法性检查(角色 释放者)
        {
            return 技能状态.被动技能;
        }
    }
}
