namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 示例主动技能，未完成
    /// </summary>
    class 防御力强化 : 技能
    {
        public 防御力强化()
        {
            Name = "防御力强化";
            是主动技能 = true;
            发动概率 = 100;
            倍率 = 2;
            消耗MP = 25;
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
