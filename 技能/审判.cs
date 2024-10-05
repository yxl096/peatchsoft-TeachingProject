namespace 战斗小游戏
{
    class 审判 : 技能
    {
        public 审判()
        {
            Name = "审判";
            技能描述 = "进行一次牛逼的根据罪恶值增加伤害的攻击";
            是主动技能 = true;
            有效目标 = 允许目标.敌方全体;
            发动概率 = 90;
            消耗MP = 200;
        }

        public override void 使用技能(角色 释放者, 角色[] 目标)
        {
            foreach (var 目标角色 in 目标)
            {
                //第一段伤害
                string message = $"{释放者.Name} 进行审判";
                int 第一段伤害 = 释放者.法术强度 * 3;

                // 找到罪恶值
                int 罪恶值 = 0;
                foreach (var buff in 目标角色.Buff池)
                {
                    if (buff is 罪恶值_buff)
                    {
                        罪恶值_buff b = (罪恶值_buff)buff;
                        罪恶值 = b.value;
                    }
                }

                int 罪恶值加成伤害 = 罪恶值 * 释放者.法术强度 / 100;

                伤害效果 审判 = new 伤害效果(释放者, [目标角色], Name, message, 伤害类型.法术, 攻击类型.技能伤害, 第一段伤害 + 罪恶值加成伤害);
                战斗管理器.GetInstance().处理伤害事件(new DamageInfo(审判));
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
