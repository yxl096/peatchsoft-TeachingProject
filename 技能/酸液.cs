namespace 战斗小游戏
{
    class 酸液 : 技能
    {
        public int 防御力降低值;
        public 酸液(int 消耗MP)
        {
            Name = "酸液";
            技能描述 = "减少敌方防御力";
            是主动技能 = true;
            有效目标 = 允许目标.敌方单体;
            发动概率 = 100;
            this.消耗MP = 消耗MP;
        }

        public override void 使用技能(角色 释放者, 角色[] 技能目标)
        {
            string message = $"{释放者.Name} 发动酸液";

            foreach (var 目标角色 in 技能目标)
            {
                // 防御力减少多少
                int 防御力降低值 = 目标角色.防御力;

                // 当场扣除，等buff结束加回去
                目标角色.防御力 -= 防御力降低值;

                目标角色.AddBuff(new 酸液减防(Name, 防御力降低值));
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
