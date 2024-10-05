using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using 战斗小游戏.buff;

namespace 战斗小游戏
{
    class 漏个小头都得死 : 技能
    {
        public 漏个小头都得死()
        {
            Name = "漏个小头都得死";
            技能描述 = "攻击有瞄准状态的敌军时伤害增加300%";
            是主动技能 = false;
            有效目标 = 允许目标.自己;
        }
        public override void 被动效果(角色 技能持有者)
        {
            Console.WriteLine($"{技能持有者.Name} 发动技能 {Name}");
            Console.WriteLine($"技能 {Name} 使 {技能持有者.Name} 的普通攻击获得连击");
            技能持有者.buff池.Add(new 爆头_被动(Name, 300));
        }
    }
}
