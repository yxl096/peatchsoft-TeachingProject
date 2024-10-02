namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 示例buff
    /// </summary>
    class 顺劈_被动 : Buff
    {
        public 顺劈_被动(string 创建者, int 技能倍率)
        {
            Name = "顺劈";
            UUID = "普通攻击可以伤害所有敌人";
            this.创建者 = 创建者;
            可以被驱散 = false;
            是正面buff = true;
            是负面buff = false;
            MagicNumber = 技能倍率;
        }

        public override void 发动攻击效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            伤害效果 damage = 攻击事件.GetDamage();

            // 复制一份攻击事件
            伤害效果 顺劈 = damage.Clone();

            // 选择普通攻击目标之外的所有敌人
            List<角色> 效果目标 = new List<角色>();
            foreach (var 角色 in 战斗管理器.GetInstance().敌人)
            {
                if (角色 != damage.承受者[0])
                {
                    效果目标.Add(角色);
                }
            }
            顺劈.承受者 = 效果目标.ToArray();

            // 追加攻击事件的信息
            顺劈.Message = $"{创建者} 使 {buff持有者.Name} 可以攻击所有敌人\n{buff持有者.Name} 的攻击造成溅射伤害";

            // 攻击类型修改为追击
            顺劈.AttackType = 攻击类型.追击;
            顺劈.创建者 = 创建者;

            // 乘算伤害倍率
            顺劈.Value = (int)(顺劈.Value * MagicNumber / 100.0);

            // 将新的攻击事件加入攻击事件序列
            攻击事件.AddDamageToNext(顺劈);
        }

        public override void 重复施加(Buff b)
        {
            // 对比持续回合，保留最大的，并修改创建者
            if (b.持续回合 > this.持续回合)
            {
                Console.WriteLine($"来自{b.创建者}的连击效果覆盖了{this.创建者}的连击");
                this.持续回合 = b.持续回合;
                this.创建者 = b.创建者;
            }
        }
    }
}
