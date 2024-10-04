namespace 战斗小游戏
{
    /// <summary>
    /// Author: 上单
    /// 修复：桃
    /// Description: 酸液
    /// </summary>
    class 酸液 : 技能
    {
        public 酸液(int 倍率, int 持续回合)
        {
            Name = "酸液";
            技能描述 = "减少敌方防御力";
            是主动技能 = true;
            有效目标 = 允许目标.敌方单体;
            发动概率 = 100;
            消耗MP = 100;
            this.倍率 = 倍率;
            this.持续回合 = 持续回合;
        }

        public override void 使用技能(角色 释放者, 角色[] 技能目标)
        {
            // 扣除mp
            释放者.减MP(消耗MP);

            Console.WriteLine($"{释放者.Name} 发动 {Name}");

            foreach (var 目标角色 in 技能目标)
            {
                // 计算出具体减防数值
                int 防御力降低值 = 目标角色.防御力 * 倍率 / 100;
                // 注意，这里传入负值
                目标角色.buff池.Add(new 属性变更buff(角色属性.防御力, -防御力降低值, Name, 持续回合));
                Console.WriteLine($"{目标角色.Name} 的防御力降低了 {防御力降低值} ({目标角色.防御力 + 防御力降低值} => {目标角色.防御力})");
            }
        }

        public override 技能状态 释放合法性检查(角色 释放者)
        {
            if (释放者.MP < 消耗MP)
            {
                return 技能状态.MP不足;
            }
            return 技能状态.可用;
        }
    }
}
