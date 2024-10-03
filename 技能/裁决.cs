namespace 战斗小游戏
{
    /// <summary>
    /// 负责人: 饼
    /// Description: 检查敌方全体的罪恶值，罪恶值高于法术强度5倍的获得眩晕效果，高于法术强度10倍的获得受到伤害增加33%的debuff
    /// </summary>
    class 裁决 : 技能
    {
        public 裁决()
        {
            Name = "裁决";
            技能描述 = "检查敌方全体的罪恶值，罪恶值高于法术强度5倍的获得眩晕效果，高于法术强度10倍的获得受到伤害增加33%的debuff";
            是主动技能 = true;
            有效目标 = 允许目标.敌方全体;
        }

        public override void 使用技能(角色 释放者, 角色[] 目标)
        {
            foreach (var 目标角色 in 目标)
            {
                string message = $"{释放者.Name} 进行裁决";

                // 找到罪恶值
                int 罪恶值 = 0;
                foreach (var buff in 目标角色.Buff池)
                {
                    if (buff is 罪恶值_buff)
                    {
                        // 类型转换，把buff类转换为具体的罪恶值_buff
                        罪恶值_buff b = (罪恶值_buff)buff;
                        罪恶值 = b.value;
                    }
                }

                //检查罪恶值，根据罪恶值释放技能
                if (罪恶值 > 释放者.法术强度 * 5)
                {
                    眩晕 buff = new 眩晕();
                    目标角色.AddBuff(buff);
                    Console.WriteLine($"{释放者.Name} 发动技能 {Name},使{目标角色.Name} 眩晕");
                }

                if(罪恶值 > 释放者.法术强度 * 10)
                {
                    易伤_buff buff = new 易伤_buff();
                    目标角色.AddBuff(buff);
                    Console.WriteLine($"{释放者.Name} 发动技能 {Name},使{目标角色.Name} 获得易伤效果");
                }

            }
        }
        // 待完成：加蓝耗检查
        public override 技能状态 释放合法性检查(角色 释放者)
        {
            return 技能状态.可用;
        }
    }
}
