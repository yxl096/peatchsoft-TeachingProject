namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 影响角色三维的buff
    /// </summary>
    class 属性变更buff : Buff
    {
        public int 对攻击力的影响 { get; set; } = 0;
        public int 对防御力的影响 { get; set; } = 0;
        public int 对法术强度的影响 { get; set; } = 0;
        public int 对速度的影响 { get; set; } = 0;

        public 属性变更buff() { }
        public 属性变更buff(角色属性 属性, int value, string 创建者, int 持续回合 = 9999)
        {
            // 自动判断是不是被动效果
            if (持续回合 == 9999)
                可以被驱散 = false;
            else
                可以被驱散 = true;

            // 自动判断是正面buff还是负面buff
            是正面buff = value > 0;
            是负面buff = value < 0;

            this.创建者 = 创建者;
            this.持续回合 = 持续回合;
            switch (属性)
            {
                case 角色属性.攻击力:
                    对攻击力的影响 = value;
                    break;
                case 角色属性.防御力:
                    对防御力的影响 = value;
                    break;
                case 角色属性.法术强度:
                    对法术强度的影响 = value;
                    break;
                case 角色属性.速度:
                    对速度的影响 = value;
                    break;
            }
        }

        public int 计算Buff后的攻击力(int 攻击力)
        {
            return 攻击力 + 对攻击力的影响;
        }
        public int 计算Buff后的防御力(int 防御力)
        {
            return 防御力 + 对防御力的影响;
        }
        public int 计算Buff后的法术强度(int 法术强度)
        {
            return 法术强度 + 对法术强度的影响;
        }
        public int 计算Buff后的速度(int 速度)
        {
            return 速度 + 对速度的影响;
        }
        public override void 回合结束效果(角色 buff持有者)
        {
            持续回合--;
            if (持续回合 == 0)
            {
                Console.WriteLine($"{buff持有者} 身上的 {创建者} 效果结束了");
                // 销毁掉自己
                buff持有者.buff池.Remove(this);
            }
        }
    }
}
