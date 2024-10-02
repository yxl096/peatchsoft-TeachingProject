namespace 战斗小游戏
{
    class 希亚的狗_被动 : Buff
    {
        public 角色 承伤对象;
        public 希亚的狗_被动(string 创建者, 角色 承伤对象) 
        {
            Name = "希亚的狗";
            UUID = "当技能持有者和希亚同时在场时，替希亚抵挡所有伤害";
            this.创建者 = 创建者;
            this.承伤对象 = 承伤对象;
            可以被驱散 = false;
            是正面buff = true;
            是负面buff = false;
        }
        public override void 受到攻击效果(角色 buff持有者, DamageInfo 攻击事件) 
        {
            伤害效果 damage = 攻击事件.GetDamage();
            for (int i = 0; i < damage.承受者.Length; i++)
            {
                角色 角色 = damage.承受者[i];
                if (角色.Name == "希亚")
                {
                    damage.承受者[i] = 承伤对象;
                    Random random = new Random();
                    if (random.Next(0,101) < 50)
                        damage.Value = (int)(damage.Value * 0.2);   // 50%概率 80%减伤
                }
            }
        }
    }
}