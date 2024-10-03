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
            UUID = "可以进行两次普通攻击";
            this.创建者 = 创建者;
            可以被驱散 = false;
            是正面buff = true;
            是负面buff = false;
            MagicNumber = 技能倍率;
        }

        public override bool 发动普通攻击效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            伤害效果 damage = 攻击事件.GetDamage();

            // 防止重复触发
            if (damage.创建者 == 创建者)
                return true;

            // 复制一份攻击事件
            伤害效果 追击 = damage.Clone();

            // 追加攻击事件的信息
            追击.Message = $"{创建者} 使 {buff持有者.Name} 获得连击能力\n{buff持有者.Name} 再次发动普通攻击";
            追击.创建者 = 创建者;

            // 乘算伤害倍率
            追击.基础伤害 = 追击.基础伤害 * MagicNumber / 100;
            // 由于伤害是克隆出来的，需要重置伤害值
            追击.最终伤害 = 追击.基础伤害 * MagicNumber / 100;

            // 将新的攻击事件加入攻击事件序列
            攻击事件.AddDamageToNext(追击);
            return true;
        }
    }
}
