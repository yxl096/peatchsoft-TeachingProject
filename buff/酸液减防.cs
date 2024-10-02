using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 战斗小游戏
{
    class 酸液减防 : Buff
    {
        public int 防御力降低值;
        public 酸液减防(string 创建者, int 防御力降低值)
        {
            Name = "酸液减防";
            UUID = "减少敌方25%防御力，持续两回合";
            this.创建者 = 创建者;
            this.防御力降低值 = 防御力降低值;
            持续回合 = 2;
            /*可以被驱散 = true;
            是正面buff = false;
            是负面buff = true;*/
        }

        public virtual void 回合结束效果(角色 buff持有者) 
        {
            持续回合--;
            if (持续回合 == 0) 
            {
                // 酸液的效果消失了！
                buff持有者.防御力 += buff持有者.防御力 + 防御力降低值;
            }
        }
    }
}
