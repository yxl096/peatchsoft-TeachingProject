using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 战斗小游戏.buff
{
    class 瞄准标记 : Buff
    {
        public 角色 释放者;
        public int 全伤害易伤倍率;
        public 瞄准标记(string 创建者, int 全伤害易伤倍率, int 持续回合, 角色 释放者) 
        {
            UUID = "有瞄准状态的敌军受到来自牢饼的伤害增加10%";
            可以被驱散 = true;
            this.创建者 = 创建者;
            this.释放者 = 释放者;
            是正面buff = false;
            是负面buff = true;
        }
        public override bool 受到物理伤害效果(角色 buff持有者, DamageInfo 攻击事件) 
        {
            // 受到来自牢饼的伤害时，受到的伤害增加10%
            伤害效果 damage = 攻击事件.GetDamage();
            if(damage.发动者 == 释放者)
            {
                int 增加伤害;
                增加伤害 = damage.基础伤害 * 全伤害易伤倍率/ 100;
                damage.最终伤害 += 增加伤害;

            }
            return true;
        }
        public override bool 受到法术伤害效果(角色 buff持有者, DamageInfo 攻击事件) 
        {
            // 受到来自牢饼的伤害时，受到的伤害增加10%
            伤害效果 damage = 攻击事件.GetDamage();
            if (damage.发动者 == 释放者)
            {
                int 增加伤害;
                增加伤害 = damage.基础伤害 * 全伤害易伤倍率 / 100;
                damage.最终伤害 += 增加伤害;

            }
            return true; 
        }
    }
}
