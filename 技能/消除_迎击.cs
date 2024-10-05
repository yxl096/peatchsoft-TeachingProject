namespace 战斗小游戏
{
    /// <summary>
    /// 负责人: 饼
    /// Description: 提供2次迎击，当敌方发动弹道攻击的时候，抵消此次攻击。
    /// </summary>
    class 消除_迎击 : 技能
    {
        public 消除_迎击()
        {
            Name = "迎击";
            技能描述 = "提供2次迎击，当敌方发动弹道攻击的时候，抵消此次攻击。";
            是主动技能 = false;
            有效目标 = 允许目标.敌方全体;
        }

        public override void 使用技能(角色 释放者, 角色[] 目标)
        {
            
        }
    }
}