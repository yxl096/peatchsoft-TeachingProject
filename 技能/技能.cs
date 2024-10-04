namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 所有技能的基类
    /// </summary>
    abstract class 技能
    {
        public string Name { get; set; } = "未命名技能";
        public string 技能描述 { get; set; } = "默认描述";
        public bool 是主动技能 { get; set; } = false;
        public int 冷却 { get; set; } = 0;
        public int 冷却剩余 { get; set; } = 0;
        public int 发动概率 { get; set; } = 100;
        public int 倍率 { get; set; } = 100;
        public int 持续回合 { get; set; }
        public int 消耗MP { get; set; } = 0;

        public 允许目标 有效目标 { get; set; } = 允许目标.自己;

        public virtual 技能状态 释放合法性检查(角色 释放者)
        {
            return 技能状态.可用;
        }

        public virtual void 使用技能(角色 释放者, 角色[] 目标) { }

        // 只有被动技能需要重写这个方法，在回合开始时调用
        // 被动技能一律写为buff形式
        public virtual void 被动效果(角色 技能持有者) { }

    }
}
