namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 角色模版
    /// </summary>
    class 角色
    {
        public string Name { get; private set; }
        public int 生命值上限 { get; private set; }
        public int HP { get; private set; }
        public int 法力值上限 { get; private set; }
        public int MP { get; private set; }
        public int 攻击力
        { 
            get
            {
                return buff池.计算Buff后的攻击力(基础攻击力);
            }
            private set { }
        }
        private int 基础攻击力;
        public int 法术强度
        {
            get
            {
                return buff池.计算Buff后的法术强度(基础法强);
            }
            private set { }
        }
        private int 基础法强;
        public int 防御力
        {
            get
            {
                return buff池.计算Buff后的防御力(基础防御力);
            }
            private set { }
        }
        private int 基础防御力;
        public int 速度
        {
            get
            {
                return buff池.计算Buff后的速度(基础速度);
            }
            private set { }
        }
        private int 基础速度;
        public bool IsPlayer { get; set; }
        public bool 死亡标记 { get; private set; }
        public 角色状态 状态
        {
            get
            {
                return buff池.获取角色状态();
            }
            private set { }
        }


        public List<技能> 技能组 { get; set; }

        public Buff池 buff池 { get; set; }

        public 角色(string name, int hp, int mp, int 攻击力, int 法术强度, int 防御力, int 速度, List<技能> 技能组)
        {
            Name = name;
            生命值上限 = hp;
            HP = hp;
            MP = mp;
            基础攻击力 = 攻击力;
            基础法强 = 法术强度;
            基础防御力 = 防御力;
            基础速度 = 速度;
            this.技能组 = 技能组;
            死亡标记 = false;
            状态 = 角色状态.正常;
            buff池 = new Buff池();
        }

        public void 受到攻击伤害(伤害效果 damage)
        {
            if (damage.DamageType == 伤害类型.物理)
            {
                // 计算防御造成的伤害减免，公式：防御力 * 1.2 / 防御力+200
                double 伤害减免 = (防御力 * 1.2) / (防御力 + 200);

                if (伤害减免 > 0.95)
                {
                    伤害减免 = 0.95;
                }

                int 伤害 = (int)(damage.Value * 伤害减免);

                HP -= 伤害;

                Console.WriteLine($"{Name} 受到了 {伤害} 点伤害");
            }
            else if (damage.DamageType == 伤害类型.法术)
            {
                // 计算法术强度提供的伤害减免，公式暂时和物理伤害一样
                double 伤害减免 = (法术强度 * 1.2) / (法术强度 + 200);

                if (伤害减免 > 0.95)
                {
                    伤害减免 = 0.95;
                }

                int 伤害 = (int)(damage.Value * 伤害减免);

                HP -= 伤害;

                Console.WriteLine($"{Name} 受到了 {伤害} 点伤害");
            }

            // 检查是否死亡，如果没死亡则输出剩余生命值
            if (HP <= 0)
            {
                死亡标记 = true;
                Console.WriteLine($"{Name} 无法战斗！");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{Name} 剩余生命值：{HP}");
                Console.WriteLine();
            }

        }

        public void 获得治疗(伤害效果 damage)
        {
            HP += damage.Value;
            if (HP > 生命值上限)
            {
                HP = 生命值上限;
            }

            Console.WriteLine($"{Name} 获得了 {damage.Value} 点治疗");

            Console.WriteLine($"{Name} 剩余生命值：{HP}");
            Console.WriteLine();

        }

        public void 获得法力值恢复(伤害效果 damage)
        {
            MP += damage.Value;
            if (MP > 法力值上限)
            {
                MP = 法力值上限;
            }

            Console.WriteLine($"{Name} 恢复了 {damage.Value} 点法力值");

            Console.WriteLine($"{Name} 剩余法力值：{MP}");
            Console.WriteLine();

        }

        /// <summary>
        /// 调用前需要先进行回合前检查
        /// </summary>
        /// <returns></returns>
        public 角色状态 检查角色状态()
        {
            return 状态;
        }

    }
}
