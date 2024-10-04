namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 易伤机制模版
    /// </summary>
    class 易伤 : Buff
    {
        public 易伤(string 创建者, int 技能倍率, int 持续回合)
        {
            UUID = "受到伤害增加";
            可以被驱散 = true;
            是负面buff = true;
            是正面buff = false;
            this.创建者 = 创建者;
            MagicNumber = 技能倍率;
            this.持续回合 = 持续回合;
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

        private void 受到伤害效果(角色 buff持有者, DamageInfo 攻击事件) 
        {
            伤害效果 damage = 攻击事件.GetDamage();
            int 增加伤害 = damage.基础伤害 * MagicNumber / 100;
            damage.最终伤害 += 增加伤害;
            Console.WriteLine($"{创建者} 的易伤效果使 {buff持有者.Name} 受到的伤害增加了{MagicNumber}% ({damage.最终伤害 - 增加伤害} => {damage.最终伤害})");
        }

    }

}
