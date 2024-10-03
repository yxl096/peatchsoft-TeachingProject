namespace 战斗小游戏
{
    /// <summary>
    /// 负责人: 陈
    /// Description: 罪恶值系统创建：希亚战斗核心buff
    /// </summary>
    class 罪恶值系统 : Buff
    {
        public 罪恶值系统(string 创建者)
        {
            UUID = "罪恶值系统";
            this.创建者 = 创建者;
            可以被驱散 = false;
            // 被动不标记为正面buff或负面buff
            是正面buff = false;
            是负面buff = false;
            MagicNumber = 0;
        }

        public override bool 造成物理伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            return 造成伤害效果(buff持有者, 攻击事件);
        }

        public override bool 造成法术伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            return 造成伤害效果(buff持有者, 攻击事件);
        }

        private bool 造成伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            //提取攻击事件中的伤害量
            伤害效果 damage = 攻击事件.GetDamage();

            //伤害量转化为罪恶值
            MagicNumber += damage.基础伤害;
            Console.WriteLine($"{创建者} 技能使 {buff持有者.Name} 积累了 {damage.基础伤害} 点罪恶值 ({MagicNumber - damage.基础伤害} => {MagicNumber})");
            return true;
        }
    }
}
