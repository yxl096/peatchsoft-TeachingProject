using 战斗小游戏.buff;
using static System.Net.Mime.MediaTypeNames;

namespace 战斗小游戏
{
    /// <summary>
    /// Author: 陈
    /// Description: 秩序被动技能：为所有敌方单位添加 罪恶 buff
    /// </summary>

    // 为所有敌方单位添加罪恶的buff，每当对方发动攻击时会积累相当于初始伤害的罪恶值
    class 秩序 : 技能
    {
        public 秩序()
        {
            Name = "秩序";
            技能描述 = "为所有敌方单位添加 罪恶 buff";
            是主动技能 = true;
            有效目标 = 允许目标.敌方全体;
        }

        public override void 被动效果(角色 技能持有者)
        {
            角色[] 敌方全体 = 战斗管理器.GetInstance().敌人;
            // 为敌方提供 罪恶 buff
            foreach (var 角色 in 战斗管理器.GetInstance().敌人)
            {
                角色.AddBuff(new 罪恶值系统(Name));
            }
        }
    }
}
