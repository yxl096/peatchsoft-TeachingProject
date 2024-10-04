namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 眩晕类控制机制模版
    /// </summary>
    class 眩晕 : Buff
    {
        public 眩晕(string 创建者, int 持续回合)
        {
            UUID = "眩晕";
            this.创建者 = 创建者;
            this.持续回合 = 持续回合;
            可以被驱散 = true;
            是负面buff = true;
            是正面buff = false;
        }

        public override 角色状态 获取角色状态(角色 buff持有者)
        {
            Console.WriteLine($"{创建者} 的眩晕效果使 {buff持有者.Name} 无法行动");
            return 角色状态.无法行动;
        }
    }

}
