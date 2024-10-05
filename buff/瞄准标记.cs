using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 战斗小游戏.buff
{
    class 瞄准标记 : Buff
    {
        public int 易伤倍率;
        public int 脆弱倍率;
        public 瞄准标记(string 创建者, int 易伤倍率, int 脆弱倍率, int 持续回合) 
        {
            UUID = "有瞄准状态的敌军受到来自牢饼的伤害增加10%，并使牢饼的攻击倍率提高300%";
            可以被驱散 = true;
            this.创建者 = 创建者;
            是正面buff = false;
            是负面buff = true;
        }
        public override bool 受到物理伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            buff持有者.buff池.Add(new 易伤(创建者, 易伤倍率, 持续回合));
            return true;
        }
        public override bool 受到法术伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            buff持有者.buff池.Add(new 脆弱(创建者, 脆弱倍率, 持续回合));
            return true;
        }
    }
}
