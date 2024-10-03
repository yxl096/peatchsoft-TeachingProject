namespace 战斗小游戏
{
    /// <summary>
    /// Author: 上单
    /// Description: 不动如山_被动
    /// </summary>
    class 不动如山_被动 : Buff
    {
        public 不动如山_被动(string 创建者,  int 技能倍率)
        {
            Name = "不动如山";
            UUID = "防御力提升，自身受到普通攻击的时候能进行反击";
            this.创建者 = 创建者;
            可以被驱散 = false;
            是正面buff = true;
            是负面buff = false;
            MagicNumber = 技能倍率;
        }
        public override void 受到攻击效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            伤害效果 damage = 攻击事件.GetDamage();
            for (int i = 0; i < damage.承受者.Length; i++)
            {
                角色 角色 = damage.承受者[i];
                if (角色 == buff持有者)  //当受到普通攻击为buff持有者时
                {
                    // 复制一份攻击事件
                    伤害效果 反击 = damage.Clone();

                    // 反击事件的信息
                    反击.Message = $"{buff持有者}受到普通攻击，发动反击";
                    反击.创建者 = 创建者;

                    // 乘算伤害倍率
                    反击.Value = (int)(反击.Value * MagicNumber / 100.0);

                    // 将新的攻击事件加入攻击事件序列
                    攻击事件.AddDamageToNext(反击);
                }
            }
        }
    }
}