namespace 战斗小游戏
{
    /// <summary>
    /// Author: 陈
    /// Description: 硬化皮肤被动部分
    /// </summary>
    class 硬化皮肤_被动 : Buff
    {
        public 硬化皮肤_被动(string 创建者, int 技能倍率)
        {
            Name = "硬化皮肤";
            UUID = "受到的伤害减少";
            this.创建者 = 创建者;
            可以被驱散 = false;
            是正面buff = true;
            是负面buff = false;
            MagicNumber = 技能倍率;
        }

        public override void 受到物理伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            //提取受击事件中的伤害量
            伤害效果 damage = 攻击事件.GetDamage();

            //暂存一个伤害减免前的伤害量
            int text = damage.Value;

            damage.Value = damage.Value * (100 - MagicNumber) / 100;
            Console.WriteLine($"硬化皮肤效果使得 {buff持有者.Name} 受到的伤害减少了  {text - damage.Value}");
        }

        public override void 受到法术伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            //提取受击事件中的伤害量
            伤害效果 damage = 攻击事件.GetDamage();

            //暂存一个伤害减免前的伤害量
            int text = damage.Value;

            damage.Value = damage.Value * (100 - MagicNumber) / 100;
            Console.WriteLine($"硬化皮肤效果使得 {buff持有者.Name} 受到的伤害减少了  {text - damage.Value}");
        }

        public override void 重复施加(Buff b)
        {
            // 对比持续回合，保留最大的，并修改创建者
            if (b.持续回合 > this.持续回合)
            {
                Console.WriteLine($"来自{b.创建者}的伤害减免效果覆盖了{this.创建者}的伤害减免效果");
                this.持续回合 = b.持续回合;
                this.创建者 = b.创建者;
            }
        }
    }
}