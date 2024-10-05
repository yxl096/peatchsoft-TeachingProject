namespace 战斗小游戏
{
    /// <summary>
    /// 负责人: 饼
    /// Description: 检查敌方全体的罪恶值，罪恶值高于法术强度5倍的获得眩晕效果，高于法术强度10倍的获得受到伤害增加33%的debuff
    /// </summary>
    class 裁决 : 技能
    {
        public 裁决(int 持续回合,int 倍率, int 眩晕时间)
        {
            Name = "裁决";
            技能描述 = $"检查敌方全体的罪恶值，罪恶值高于法术强度5倍的获得眩晕{眩晕时间}回合的效果，高于法术强度10倍的获得受到伤害增加{倍率}的debuff";
            是主动技能 = true;
            有效目标 = 允许目标.敌方全体;
            消耗MP = 150;
            发动概率 = 100;
            this.持续回合 = 持续回合;
            this.倍率 = 倍率;
        }

        public override void 使用技能(角色 释放者, 角色[] 目标)
        {
            //扣除MP
            释放者.减MP(消耗MP);

            foreach (var 目标角色 in 目标)
            {
                string message = $"{释放者.Name} 进行裁决";

                // 找到罪恶值
                Buff 罪恶值;
                Buff池.GetBuff("罪恶值系统",out 罪恶值);

                //检查罪恶值，根据罪恶值释放技能
                foreach (var 角色 in 战斗管理器.GetInstance().敌人)
                {
                    if (罪恶值.MagicNumber > 释放者.法术强度 * 5)
                    {
                        角色.buff池.Add(new 眩晕(释放者.Name, 持续回合));
                        Console.WriteLine($"{释放者.Name} 发动技能 {Name},使{目标角色.Name} 眩晕");
                    }

                    if (罪恶值.MagicNumber > 释放者.法术强度 * 10)
                    {
                        角色.buff池.Add(new 易伤(释放者.Name, 倍率, 持续回合));
                        Console.WriteLine($"{释放者.Name} 发动技能 {Name},使{目标角色.Name} 获得易伤效果");
                    }
                }

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
