
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
        public override bool 发动普通攻击效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            伤害效果 damage = 攻击事件.GetDamage();
            if (damage.承受者.buff池.GetBuff(瞄准_buff, b))
            {

            }
            return true;
        }
    }
}
