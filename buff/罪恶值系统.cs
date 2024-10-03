using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace 战斗小游戏.buff
{
    /// <summary>
    /// Author: 陈
    /// Description: 罪恶值系统创建：希亚战斗核心buff
    /// </summary>
    internal class 罪恶值系统 : Buff
    {
        public int 罪恶值 { get; private set; } = 0;

        public 罪恶值系统(string 创建者)
        {
            Name = "罪恶";
            UUID = "当发动攻击时会积累相当于初始伤害的罪恶值";
            this.创建者 = 创建者;
            可以被驱散 = false;
            是正面buff = false;
            是负面buff = true;
        }

        public override void 造成物理伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            //提取攻击事件中的伤害量
            伤害效果 damage = 攻击事件.GetDamage();

            //伤害量转化为罪恶值
            罪恶值 += damage.Value;
            Console.WriteLine($"由于秩序技能，{buff持有者.Name} 的攻击行为使得他增加了 {罪恶值} 点罪恶值");
        }

        public override void 造成法术伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            //提取攻击事件中的伤害量
            伤害效果 damage = 攻击事件.GetDamage();

            //伤害量转化为罪恶值
            罪恶值 += damage.Value;
            Console.WriteLine($"由于秩序技能，{buff持有者.Name} 的攻击行为使得他增加了 {罪恶值} 点罪恶值");
        }
    }
}
