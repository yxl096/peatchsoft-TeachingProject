namespace 战斗小游戏
{
    /// <summary>
    /// Author: 上单
    /// Description: 鼓舞友方全体，增加相当于牢饼10%法术强度的攻击力，法术强度，防御力，速度，持续3回合
    /// </summary>
    class 鼓舞 : 技能
    {
        public 鼓舞(int 倍率, int 持续回合)
        {
            Name = "鼓舞";
            技能描述 = "鼓舞友方全体，增加相当于牢饼10%法术强度的攻击力，法术强度，防御力，速度，持续3回合";
            是主动技能 = true;
            有效目标 = 允许目标.友方全体;
            消耗MP = 100;
            this.倍率 = 倍率;
            this.持续回合 = 持续回合;
        }

        public override void 使用技能(角色 释放者, 角色[] 技能目标)
        {
            // 扣除mp
            释放者.减MP(消耗MP);

            Console.WriteLine($"{释放者.Name} 发动 {Name}");

            // 给队友添加buff
            foreach (var 目标角色 in 技能目标)
            {
                
                int 各数值增加值 = 释放者.法术强度 * 倍率 / 100;       // 计算增加值

                目标角色.buff池.Add(new 属性变更buff(角色属性.攻击力, 各数值增加值, Name, 持续回合));
                目标角色.buff池.Add(new 属性变更buff(角色属性.法术强度, 各数值增加值, Name, 持续回合));
                目标角色.buff池.Add(new 属性变更buff(角色属性.防御力, 各数值增加值, Name, 持续回合));
                目标角色.buff池.Add(new 属性变更buff(角色属性.速度, 各数值增加值, Name, 持续回合));

                Console.WriteLine($"{目标角色.Name} 的攻击力，法术强度，防御力，速度提高了 {各数值增加值}");
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
