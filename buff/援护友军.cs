namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 嘲讽效果
    /// </summary>
    class 援护友军 : Buff
    {
        public 角色 承伤对象;
        int 减伤概率;
        int 减伤倍率;

        public 援护友军(string 创建者, 角色 承伤对象, int 持续回合) 
        {
            UUID = "援护友军";
            this.创建者 = 创建者;
            this.承伤对象 = 承伤对象;
            this.持续回合 = 持续回合;
            可以被驱散 = false;
            是正面buff = true;
            是负面buff = false;
        }

        public override bool 受到物理伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            受到伤害效果(buff持有者, 攻击事件);
            return true;
        }
        public override bool 受到法术伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            受到伤害效果(buff持有者, 攻击事件);
            return true;
        }

        private void 受到伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            // 承伤对象不能似了还能挡伤害
            if (承伤对象.死亡标记)
                return;

            伤害效果 damage = 攻击事件.GetDamage();

            // 复制一个伤害事件，目标为援护者
            伤害效果 newDamage = damage.Clone();
            newDamage.承受者 = 承伤对象;

            // 加入新的伤害事件
            攻击事件.AddDamageToNext(newDamage);

            // 将本次伤害(希亚承受的)变为0
            damage.最终伤害 = 0;
        }

        public override void 重复施加(Buff b)
        {
            // 此技能优先级最高，不会被其他技能覆盖
        }

        public override void 回合结束效果(角色 buff持有者)
        {
            持续回合--;
            if (持续回合 == 0)
            {
                Console.WriteLine($"{创建者} 的援护效果结束了");
                // 销毁掉自己
                buff持有者.buff池.Remove(this, buff持有者);
            }
        }
    }
}