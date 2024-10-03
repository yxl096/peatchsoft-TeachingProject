namespace 战斗小游戏
{
    /// <summary>
    /// 负责人: 上单
    /// Description: 受到普通攻击时可以反击
    /// </summary>
    class 反击_被动 : Buff
    {
        public 反击_被动(string 创建者, int 技能倍率)
        {
            UUID = "受到普通攻击时反击";
            this.创建者 = 创建者;
            可以被驱散 = false;
            // 被动不标记为正面buff或负面buff
            是正面buff = false;
            是负面buff = false;
            MagicNumber = 技能倍率;
        }

        public override bool 受到普通攻击效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            伤害效果 damage = 攻击事件.GetDamage();

            // 创建反击的攻击事件
            int damageValue = buff持有者.攻击力 * MagicNumber / 100;
            string message = $"{创建者} 使 {buff持有者.Name} 获得反击能力\n{buff持有者.Name} 发动反击";

            伤害效果 反击 = new 伤害效果(buff持有者, damage.发动者, 创建者, message, 
                伤害类型.物理, 攻击类型.追击, damageValue);

            // 将新的攻击事件加入攻击事件序列
            攻击事件.AddDamageToNext(反击);
            return true;
        }
    }
}