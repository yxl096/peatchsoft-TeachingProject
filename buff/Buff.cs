namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 所有buff的基类
    /// </summary>
    abstract class Buff
    {
        public string UUID { get; set; }
        public string 创建者 { get; set; }
        public bool 可以被驱散 { get; set; }
        public bool 是正面buff { get; set; }
        public bool 是负面buff { get; set; }

        // 默认为9999回合，即这个为被动技能
        public int 持续回合 { get; set; } = 9999;

        public int MagicNumber { get; set; }


        public virtual void 回合开始效果(角色 buff持有者) { }
        public virtual void 角色行动前效果(角色 buff持有者) { }
        public virtual void 角色行动后效果(角色 buff持有者) { }
        public virtual void 回合结束效果(角色 buff持有者) { }

        public virtual bool 发动普通攻击效果(角色 buff持有者, DamageInfo 攻击事件) { return true; }
        public virtual bool 受到普通攻击效果(角色 buff持有者, DamageInfo 攻击事件) { return true; }
        public virtual bool 发动技能效果(角色 buff持有者, DamageInfo 攻击事件) { return true; }
        public virtual bool 成为技能目标(角色 buff持有者, DamageInfo 攻击事件) { return true; }
        public virtual bool 发动治疗效果(角色 buff持有者, DamageInfo 攻击事件) { return true; }
        public virtual bool 受到治疗效果(角色 buff持有者, DamageInfo 攻击事件) { return true; }
        public virtual bool 造成物理伤害效果(角色 buff持有者, DamageInfo 攻击事件) { return true; }
        public virtual bool 造成法术伤害效果(角色 buff持有者, DamageInfo 攻击事件) { return true; }
        public virtual bool 受到物理伤害效果(角色 buff持有者, DamageInfo 攻击事件) { return true; }
        public virtual bool 受到法术伤害效果(角色 buff持有者, DamageInfo 攻击事件) { return true; }

        public virtual 角色状态 获取角色状态() { return 角色状态.正常; }

        public virtual void 重复施加(Buff b)
        {
            // 回合长的覆盖回合短的
            if (b.持续回合 > 持续回合)
            {
                持续回合 = b.持续回合;
                MagicNumber = b.MagicNumber;
                创建者 = b.创建者;
            }
            // 回合相同则倍率高的覆盖倍率低的
            else if (b.MagicNumber > MagicNumber)
            {
                持续回合 = b.持续回合;
                MagicNumber = b.MagicNumber;
                创建者 = b.创建者;
            }
        }

        public virtual void 属性变更效果(Buff池 buff池) { }
        public virtual void 移除buff事件(角色 buff持有者) { }
    }
}
