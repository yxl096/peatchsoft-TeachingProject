namespace 战斗小游戏
{
    class 易伤_buff : Buff
    {
        public int value = 0;

        public 易伤_buff()
        {
            Name = "罪恶值";
            可以被驱散 = true;
            是负面buff = true;
            是正面buff = false;
            MagicNumber = 33;
        }

        public override void 受到攻击效果(角色 buff持有者, DamageInfo 攻击事件) 
        {
            伤害效果 damage = 攻击事件.GetDamage();
            damage.Value = damage.Value * (100 + MagicNumber / 100);
            Console.WriteLine($"{buff持有者.Name} 受到了易伤效果，受到的伤害增加了{MagicNumber}%");
        }

    }

}
