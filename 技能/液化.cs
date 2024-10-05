namespace 战斗小游戏
{
    /// <summary>
    /// 负责人: 陈
    /// Description: 液化主动技能：为己方提供3次目标随机100%法术强度的恢复
    /// </summary>
    class 液化 : 技能
    {
        public 液化(int 倍率)
        {
            Name = "液化";
            技能描述 = $"为己方提供3次目标随机{倍率}%法术强度的生命恢复";
            是主动技能 = true;
            有效目标 = 允许目标.友方全体;
            冷却 = 2;
            冷却剩余 = 0;
            消耗MP = 30;
            this.倍率 = 倍率;
        }

        public override void 使用技能(角色 释放者, 角色[] 目标)
        {
            //同时判断目标、MP、冷却
            switch (目标.Length == 0 && 释放者.MP < this.消耗MP && 冷却剩余 > 0)
            {
                case false when 目标.Length == 0:
                    // 目标无效
                    Console.WriteLine("技能无法释放：目标无效。");
                    return;
                case false when 释放者.MP < this.消耗MP:
                    // MP不足
                    Console.WriteLine("技能无法释放：MP不足。");
                    return;
                case false when 冷却剩余 > 0:
                    // 冷却未完成
                    Console.WriteLine("技能无法释放：冷却未完成。");
                    return;
            }

            Console.WriteLine($"{释放者.Name} 使用了 {Name}");

            int 治疗量 = 释放者.法术强度 * 倍率 / 100;

            // 提取对应目标
            if (释放者.IsPlayer)
            {
                // 提取友方单位数组
                目标 = 战斗管理器.GetInstance().友方;
            }
            else
            {
                // 提取敌人单位数组
                目标 = 战斗管理器.GetInstance().敌人;
            }


            // 创建随机数实例
            Random rand = new Random();
            // 创建存储对应有效目标数量的角色数组
            角色[] rollName = new 角色[目标.Length];

            // 进行三次循环选择对象
            for (int i = 0; i < 3; i++)
            {
                rollName[i] = 目标[rand.Next(目标.Length)];//选择治疗单位
            }

            foreach (var roll in rollName) //对已选出的目标进行顺序治疗
            {
                //技能文本
                string message = $"{roll.Name} 受到 {释放者.Name} {治疗量}点治疗";

                ///将释放对象角色转换为角色数组
                ///角色[] rollNamei = new 角色[] { roll };
                ///治疗目标重定义到已选定的三位友方单位之一
                ///目标 = rollNamei;
                ///废弃流程，如目标角色后续修改为数组再启用

                //进行治疗流程
                伤害效果 液化 = new 伤害效果(释放者, roll, Name, message, 伤害类型.治疗, 攻击类型.技能伤害, 治疗量);
                战斗管理器.GetInstance().处理伤害事件(new DamageInfo(液化));

            }

        }
    }
}
