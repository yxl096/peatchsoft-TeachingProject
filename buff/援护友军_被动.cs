namespace 战斗小游戏
{
    /// <summary>
    /// Author: 上单
    /// 修改：桃
    /// Description: 希亚的狗_被动
    /// 注：由于这个被动技能是复合效果，所以无法作为通用被动实现
    /// </summary>
    class 援护友军_被动 : Buff
    {
        public 角色 承伤对象;
        int 减伤概率;
        int 减伤倍率;

        public 援护友军_被动(string 创建者, 角色 承伤对象, int 减伤概率, int 减伤倍率) 
        {
            UUID = "援护友军";
            this.创建者 = 创建者;
            this.承伤对象 = 承伤对象;
            可以被驱散 = false;
            是正面buff = true;
            是负面buff = false;
            this.减伤概率 = 减伤概率;
            this.减伤倍率 = 减伤倍率;
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
            // 承伤对象不能似了还能挡伤害，不然希亚就无敌了
            if (承伤对象.死亡标记)
                return;

            伤害效果 damage = 攻击事件.GetDamage();

            // 复制一个伤害事件，目标为援护者
            伤害效果 newDamage = damage.Clone();
            newDamage.承受者 = 承伤对象;

            // 计算减伤
            if (new Random().Next(0, 101) < 减伤概率)
                newDamage.最终伤害 = newDamage.最终伤害 * (100 - 减伤倍率) / 100;

            // 加入新的伤害事件
            攻击事件.AddDamageToNext(newDamage);

            // 将本次伤害(希亚承受的)变为0
            damage.最终伤害 = 0;
        }

        public override void 重复施加(Buff b)
        {
            // 此技能优先级最高，不会被其他技能覆盖
        }
    }
}