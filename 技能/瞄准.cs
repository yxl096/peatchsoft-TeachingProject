using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 战斗小游戏.buff;

namespace 战斗小游戏
{
    class 瞄准 : 技能
    {
        public int 易伤倍率;
        public int 持续回合;
        public 瞄准(int 易伤倍率, int 持续回合) 
        {
            Name = "瞄准";
            技能描述 = $"给敌方添加{Name}状态，并使敌方受到的物理伤害提高10%";
            是主动技能 = true;
            有效目标 = 允许目标.敌方单体;
            消耗MP = 150;
            this.易伤倍率 = 易伤倍率;
            this.持续回合 = 持续回合;
        }
        public override void 使用技能(角色 释放者, 角色[] 技能目标)
        {
            // 扣除mp
            释放者.减MP(消耗MP);

            Console.WriteLine($"{释放者.Name} 发动 {Name}");

            foreach (var 目标角色 in 技能目标)
            {
                目标角色.buff池.Add(new 瞄准标记(Name, 10, 10, 3));
                
            }
        }
    }
}
