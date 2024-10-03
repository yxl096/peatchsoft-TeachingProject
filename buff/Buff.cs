namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 所有buff的基类
    /// </summary>
    abstract class Buff
    {
        public string Name { get; set; }
        public string UUID { get; set; }
        public string 创建者 { get; set; }
        public bool 可以被驱散 { get; set; }
        public bool 是正面buff { get; set; }
        public bool 是负面buff { get; set; }
        public int 持续回合 { get; set; }

        public int MagicNumber { get; set; }


        public virtual void 回合开始效果(角色 buff持有者) { }
        public virtual void 角色行动前效果(角色 buff持有者) { }
        public virtual void 角色行动后效果(角色 buff持有者) { }
        public virtual void 回合结束效果(角色 buff持有者) { }

        public virtual void 成为技能目标(角色 buff持有者, 技能 skill) { }

        public virtual void 发动攻击效果(角色 buff持有者, DamageInfo 攻击事件) { }
        public virtual void 受到攻击效果(角色 buff持有者, DamageInfo 攻击事件) { }
        public virtual void 发动治疗效果(角色 buff持有者, DamageInfo 攻击事件) { }
        public virtual void 受到治疗效果(角色 buff持有者, DamageInfo 攻击事件) { }
        public virtual void 造成物理伤害效果(角色 buff持有者, DamageInfo 攻击事件) { }
        public virtual void 造成法术伤害效果(角色 buff持有者, DamageInfo 攻击事件) { }
        public virtual void 受到物理伤害效果(角色 buff持有者, DamageInfo 攻击事件) { }
        public virtual void 受到法术伤害效果(角色 buff持有者, DamageInfo 攻击事件) { }

        public virtual void 重复施加(Buff b) { }

        public virtual void 移除buff事件(角色 buff持有者) { }
    }
}
