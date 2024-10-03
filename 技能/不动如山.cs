namespace 战斗小游戏
{
    /// <summary>
    /// 负责人: 上单
    /// Description: 防御力提升114点，并使自身受到普通攻击的时候能进行反击（伤害率：85%）
    /// </summary>
    class 不动如山 : 技能
    {
        int 防御力增幅;
        int 反击伤害倍率;

        public 不动如山(int 防御力增幅, int 反击伤害倍率)
        {
            Name = "不动如山";
            技能描述 = $"使自身防御力提升{防御力增幅}，并且受到普通攻击的时候能进行反击（伤害倍率：{反击伤害倍率}%）";
            是主动技能 = false;
            有效目标 = 允许目标.自己;
            this.防御力增幅 = 防御力增幅;
            this.反击伤害倍率 = 反击伤害倍率;
        }

        public override void 被动效果(角色 技能持有者)
        {
            // 为技能持有者提供一个属性变更buff
            技能持有者.buff池.Add(new 属性变更buff(角色属性.防御力, 防御力增幅, Name));

            技能持有者.buff池.Add(new 反击_被动(Name, 反击伤害倍率));
        }

        public override 技能状态 释放合法性检查(角色 释放者)
        {
            return 技能状态.被动技能;
        }
    }
}
