namespace 战斗小游戏
{
    class 眩晕_buff : Buff
    {
        public int value = 0;

        public 眩晕_buff()
        {
            Name = "眩晕";
            可以被驱散 = true;
            是负面buff = true;
            是正面buff = false;
        }

        public override void 角色行动前效果(角色 buff持有者)
        {
            buff持有者.状态 = 角色状态.无法行动;
            // 待完成：谁加的buff使谁无法行动
            Console.WriteLine($"{buff持有者.Name} 无法行动");
        }

        public override void 移除buff事件(角色 buff持有者)
        {
            buff持有者.状态 = 角色状态.正常;
        }
    }

}
