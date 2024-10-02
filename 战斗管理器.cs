namespace 战斗小游戏
{
    class 战斗管理器
    {
        private static 战斗管理器 Instance;
        private 战斗管理器() { }
        public static 战斗管理器 GetInstance()
        {
            if (Instance == null)
            {
                Instance = new 战斗管理器();
            }
            return Instance;
        }

        public 角色[] 友方 { get; set; }
        public 角色[] 敌人 { get; set; }

        public static void 游戏结束()
        {
            Instance = null;
        }

        public void 游戏开始(角色[] 玩家, 角色[] 敌人)
        {
            this.友方 = 玩家;
            this.敌人 = 敌人;

            // 设置ai接管
            foreach (var player in 玩家)
            {
                player.IsPlayer = true;
            }
            foreach (var enemy in 敌人)
            {
                enemy.IsPlayer = false;
            }

            // 发动被动技能
            foreach (var player in 玩家)
            {
                foreach (var skill in player.技能组)
                {
                    skill.被动效果(player);
                }
            }
            foreach (var enemy in 敌人)
            {
                foreach (var skill in enemy.技能组)
                {
                    skill.被动效果(enemy);
                }
            }

        }

        // 此方法不设置缓存，考虑到之后会出现战斗中改变属性的技能。
        public 角色[] 计算行动顺序()
        {
            // 合并玩家和敌人数组
            List<角色> 所有角色 = new();
            所有角色.AddRange(友方);
            所有角色.AddRange(敌人);

            // 排除死亡的角色
            所有角色.RemoveAll(x => x.死亡标记);

            // 根据速度属性排序，如果速度相同，玩家优先
            所有角色.Sort((a, b) =>
            {
                int speedComparison = b.速度.CompareTo(a.速度);
                if (speedComparison == 0)
                {
                    return b.IsPlayer.CompareTo(a.IsPlayer);
                }
                return speedComparison;
            });

            return 所有角色.ToArray();
        }

        public void 处理伤害事件(DamageInfo 攻击事件)
        {
            do
            {
                伤害效果 攻击效果 = 攻击事件.GetDamage();

                Console.WriteLine(攻击效果.Message);

                // 处理事件
                if (攻击效果.AttackType == 攻击类型.普通攻击)
                {
                    foreach (Buff b in 攻击效果.发动者.Buff池)
                    {
                        b.发动攻击效果(攻击效果.发动者, 攻击事件);
                    }
                }

                switch (攻击效果.DamageType)
                {
                    case 伤害类型.物理伤害:
                        foreach (Buff b in 攻击效果.发动者.Buff池)
                        {
                            b.造成物理伤害效果(攻击效果.发动者, 攻击事件);
                        }
                        break;
                    case 伤害类型.法术伤害:
                        foreach (Buff b in 攻击效果.发动者.Buff池)
                        {
                            b.造成法术伤害效果(攻击效果.发动者, 攻击事件);
                        }
                        break;
                    case 伤害类型.治疗:
                        foreach (Buff b in 攻击效果.发动者.Buff池)
                        {
                            b.发动治疗效果(攻击效果.发动者, 攻击事件);
                        }
                        break;
                }

                // 攻击效果.承受者事件
                switch (攻击效果.DamageType)
                {
                    case 伤害类型.物理伤害:
                        foreach (角色 角色 in 攻击效果.承受者)
                        {
                            foreach (Buff b in 角色.Buff池)
                            {
                                b.受到物理伤害效果(攻击效果.发动者, 攻击事件);
                            }
                            角色.受到攻击伤害(攻击效果);
                        }
                        break;
                    case 伤害类型.法术伤害:
                        foreach (角色 角色 in 攻击效果.承受者)
                        {
                            foreach (Buff b in 角色.Buff池)
                            {
                                b.受到法术伤害效果(攻击效果.发动者, 攻击事件);
                            }
                            角色.受到攻击伤害(攻击效果);
                        }
                        break;
                    case 伤害类型.治疗:
                        foreach (角色 角色 in 攻击效果.承受者)
                        {
                            foreach (Buff b in 角色.Buff池)
                            {
                                b.受到治疗效果(攻击效果.发动者, 攻击事件);
                            }
                            角色.获得治疗(攻击效果);
                        }
                        break;
                }

            } while (!攻击事件.RemoveDamage());
        }

        public void 回合结束()
        {
            // 结算buff池的回合结束事件
        }

        public void 打印玩家可选技能(角色 角色)
        {
            Console.WriteLine("请选择技能：");
            // 循环角色技能组的技能，调用技能的释放合法性检查方法，如果返回true则打印技能名字
            int i = 1;
            foreach (var skill in 角色.技能组)
            {
                string massage = "";
                switch (skill.释放合法性检查(角色))
                {
                    case 技能状态.可用:
                        // do nothing
                        break;
                    case 技能状态.不可用:
                        massage = "（不可用）";
                        break;
                    case 技能状态.没有有效目标:
                        massage = "（没有有效目标）";
                        break;
                    case 技能状态.MP不足:
                        massage = "（MP不足）";
                        break;
                    case 技能状态.冷却中:
                        massage = "（冷却中）";
                        break;
                    case 技能状态.被动技能:
                        massage = "（被动技能）";
                        break;
                }
                Console.WriteLine($"{i}:{skill.Name}{massage}");
                i++;
            }
        }

        public void 打印可选的技能目标(角色[] 目标)
        {
            Console.WriteLine("请选择技能目标：");
            int i = 1;
            foreach (var 角色 in 目标)
            {
                Console.WriteLine($"{i}:{角色.Name}");
                i++;
            }
        }

        public bool 释放合法性检查(角色 角色, int 技能id)
        {
            if (技能id < 1 || 技能id > 角色.技能组.Count)
            {
                Console.WriteLine("请输入有效的数字！");
                return false;
            }

            技能 skill = 角色.技能组[技能id - 1];
            switch (skill.释放合法性检查(角色))
            {
                case 技能状态.可用:
                    return true;
                case 技能状态.不可用:
                    Console.WriteLine("该技能不可用");
                    return false;
                case 技能状态.没有有效目标:
                    Console.WriteLine("该技能没有可选择的目标");
                    return false;
                case 技能状态.MP不足:
                    Console.WriteLine("MP不足，无法发动");
                    return false;
                case 技能状态.冷却中:
                    Console.WriteLine("技能冷却中，无法使用");
                    return false;
                case 技能状态.被动技能:
                    Console.WriteLine("被动技能无法主动发动");
                    return false;
                default:
                    Console.WriteLine("输入参数不合法");
                    return false;
            }
        }
    }
}
