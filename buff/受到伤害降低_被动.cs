namespace 战斗小游戏
{
    /// <summary>
    /// 负责人: 陈
    /// Description: 硬化皮肤被动部分
    /// </summary>
    class 受到伤害降低_被动 : Buff
    {
        public 受到伤害降低_被动(string 创建者, int 技能倍率)
        {
            UUID = "受到伤害降低";
            this.创建者 = 创建者;
            可以被驱散 = false;
            // 被动不标记为正面buff或负面buff
            是正面buff = false;
            是负面buff = false;
            MagicNumber = 技能倍率;
        }

        public override bool 受到物理伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            受到伤害效果(buff持有者, 攻击事件);
            return true;
        }
        public override bool 受到法术伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            受到伤害效果(buff持有者, 攻击事件);
            return true;
        }
        public void 受到伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            伤害效果 damage = 攻击事件.GetDamage();
            int 减免伤害 = damage.最终伤害 * (100 - MagicNumber) / 100;
            damage.最终伤害 -= 减免伤害;
            Console.WriteLine($"{创建者} 使 {buff持有者.Name} 受到的伤害减少了{MagicNumber}% ({damage.最终伤害 + 减免伤害} => {damage.最终伤害})");
        }
    }
}