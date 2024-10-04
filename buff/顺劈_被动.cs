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
            UUID = "普通攻击可以伤害所有敌人";
            this.创建者 = 创建者;
            可以被驱散 = false;
            是正面buff = true;
            是负面buff = false;
            MagicNumber = 技能倍率;
        }

        public override bool 发动普通攻击效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            伤害效果 damage = 攻击事件.GetDamage();

            bool flag = true;
            // 选择普通攻击目标之外的所有敌人
            foreach (var 角色 in 战斗管理器.GetInstance().敌人)
            {
                if (角色 != damage.承受者)
                {
                    // 复制一份攻击事件
                    伤害效果 顺劈 = damage.Clone();
                    顺劈.承受者 = 角色;

                    // 追加攻击事件的信息
                    if (flag)
                    {
                        顺劈.Message = $"{创建者} 使 {buff持有者.Name} 可以攻击所有敌人\n{buff持有者.Name} 的攻击造成溅射伤害";
                        flag = false;
                    }
                    else
                    {
                        顺劈.Message = $"{buff持有者.Name} 的攻击造成溅射伤害";
                    }

                    // 攻击类型修改为追击
                    顺劈.AttackType = 攻击类型.追击;
                    顺劈.创建者 = 创建者;

                    // 乘算伤害倍率
                    顺劈.基础伤害 = 顺劈.基础伤害 * MagicNumber / 100;

                    // 将新的攻击事件加入攻击事件序列
                    攻击事件.AddDamageToNext(顺劈);
                }
            }

            //执行结束返回true
            return true;
        }
    }
}
