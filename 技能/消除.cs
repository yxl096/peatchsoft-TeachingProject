namespace 战斗小游戏
{
    /// <summary>
    /// 负责人: 饼
    /// Description: 清除友方全体的debuff和敌方全体的正面buff，敌方的护盾也一并消除
    /// </summary>
    class 消除 : 技能
    {
        public 消除()
        {
            Name = "迎击";
            技能描述 = "清除友方全体的debuff和敌方全体的正面buff，敌方的护盾也一并消除";
            是主动技能 = false;
            有效目标 = 允许目标.敌方全体;
        }

        public override void 使用技能(角色 释放者, 角色[] 目标)
        {

        }
    }
}