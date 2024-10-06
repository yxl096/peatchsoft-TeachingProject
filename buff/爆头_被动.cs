
namespace 战斗小游戏.buff
{
     class 爆头_被动 : Buff
     {
        public 爆头_被动(string 创建者, int 技能倍率) 
        {
            UUID = "攻击有瞄准状态的敌军时伤害增加300%";
            this.创建者 = 创建者;
            可以被驱散 = false;
            是正面buff = false;
            是负面buff = false;
            MagicNumber = 技能倍率;
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
            Buff b;     // 创建一个接收GetBuff输出的变量
            伤害效果 damage = 攻击事件.GetDamage();

            // 检测攻击对象是否有瞄准标记
            damage.承受者.buff池.GetBuff("瞄准标记", out b);
            if (b.UUID == "瞄准")
            {
                damage.最终伤害 *= MagicNumber;     // 造成3倍伤害
            }
            return true;
        }
    }
}
