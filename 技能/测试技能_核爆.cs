namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 示例主动技能，测试用
    /// </summary>
    class 测试技能_核爆 : 技能
    {
        public 测试技能_核爆()
        {
            Name = "核爆";
            技能描述 = "把你们全tm炸死";
            是主动技能 = true;
            有效目标 = 允许目标.敌方全体;
        }

        public override void 使用技能(角色 释放者, 角色[] 目标)
        {
            string message = $"{释放者.Name} 发动核爆";
            int 伤害值 = 999900000;
            伤害效果 核爆 = new 伤害效果(释放者, 目标, Name, message, 伤害类型.物理, 攻击类型.技能伤害, 伤害值);
            战斗管理器.GetInstance().处理伤害事件(new DamageInfo(核爆));
        }
        public override 技能状态 释放合法性检查(角色 释放者)
        {
            return 技能状态.可用;
        }
    }
}
