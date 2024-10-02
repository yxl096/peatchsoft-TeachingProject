namespace 战斗小游戏
{
    class 甜点师傅 : 技能
    {
        /// <summary>
        /// 创建者:饼
        /// 描述: 恢复相当于法术强度514%的生命值，如果队伍中存在希亚，则恢复效果变为友方全体。
        /// </summary>
        public 甜点师傅(int 恢复倍率, int 消耗MP)
        {
            Name = "甜点师傅";
            倍率 = 恢复倍率;
            技能描述 = $"恢复相当于法术强度{恢复倍率}%的生命值，如果队伍中存在希亚，则恢复效果变为友方全体";
            this.消耗MP = 消耗MP;
            是主动技能 = true;
            有效目标 = 允许目标.自己;
        }

        public override void 使用技能(角色 释放者, 角色[] 目标)
        {
            // 扣除MP
            释放者.MP -= 消耗MP;

            string message = $"{释放者.Name} 发动技能：{Name}";

            foreach( var 角色 in 战斗管理器.GetInstance().友方)
            {
                // 如果队伍中存在希亚，则恢复效果变为友方全体
                int 恢复值 = 释放者.法术强度 * 倍率 / 100;
                伤害效果 甜点恢复;
                if (角色.Name == "希亚")
                {
                    甜点恢复 = new 伤害效果(释放者, 战斗管理器.GetInstance().友方, Name, message, 伤害类型.治疗, 攻击类型.技能伤害, 恢复值);

                }
                else
                {
                    甜点恢复 = new 伤害效果(释放者, [释放者], Name, message, 伤害类型.治疗, 攻击类型.技能伤害, 恢复值);
                }
                战斗管理器.GetInstance().处理伤害事件(new DamageInfo(甜点恢复));
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