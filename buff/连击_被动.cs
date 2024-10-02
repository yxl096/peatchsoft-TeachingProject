namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 示例buff
    /// </summary>
    class 连击_被动 : Buff
    {
        public 连击_被动(string 创建者, int 技能倍率)
        {
            Name = "连击";
            UUID = "可以进行两次普通攻击";
            this.创建者 = 创建者;
            可以被驱散 = false;
            是正面buff = true;
            是负面buff = false;
            MagicNumber = 技能倍率;
        }

        public override void 发动攻击效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            伤害效果 damage = 攻击事件.GetDamage();

            // 防止重复触发
            if (damage.创建者 == 创建者)
                return;

            // 复制一份攻击事件
            伤害效果 追击 = damage.Clone();

            // 追加攻击事件的信息
            追击.Message = $"{创建者} 使 {buff持有者.Name} 获得连击能力\n{buff持有者.Name} 再次发动普通攻击";
            追击.创建者 = 创建者;

            // 乘算伤害倍率
            追击.Value = (int)(追击.Value * MagicNumber / 100.0);

            // 将新的攻击事件加入攻击事件序列
            攻击事件.AddDamageToNext(追击);
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
