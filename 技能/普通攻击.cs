namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 普通攻击技能
    /// </summary>
    class 普通攻击 : 技能
    {
        private 伤害类型 伤害类型;
        private int 伤害倍率;

        public 普通攻击(伤害类型 伤害类型, int 伤害倍率 = 100)
        {
            Name = "普通攻击";
            技能描述 = "普通的攻击";
            是主动技能 = true;
            this.伤害类型 = 伤害类型;
            this.伤害倍率 = 伤害倍率;
            有效目标 = 允许目标.敌方单体;
        }

        public override void 使用技能(角色 释放者, 角色[] 目标)
        {
            string message = $"{释放者.Name} 发动普通攻击";

            // 计算伤害值
            int 伤害值 = 释放者.攻击力 * 伤害倍率 / 100;

            // 为战斗管理器传递攻击指令
            伤害效果 普通攻击 = new 伤害效果(释放者, 目标, Name, message, 伤害类型, 攻击类型.普通攻击, 伤害值);
            战斗管理器.GetInstance().处理伤害事件(new DamageInfo(普通攻击));
        }

        public override 技能状态 释放合法性检查(角色 释放者)
        {
            return 技能状态.可用;
        }
    }
}
