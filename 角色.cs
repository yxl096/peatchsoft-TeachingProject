namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 角色模版
    /// </summary>
    class 角色
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int 攻击力 { get; set; }
        public int 法术强度 { get; set; }
        public int 防御力 { get; set; }
        public int 速度 { get; set; }
        public bool IsPlayer { get; set; }
        public bool 死亡标记 { get; set; }
        public 角色状态 状态 { get; set; }


        public List<技能> 技能组 { get; set; }

        public List<Buff> Buff池 { get; set; }

        public 角色(string name, int hp, int mp, int 攻击力, int 法术强度, int 防御力, int 速度, List<技能> 技能组)
        {
            Name = name;
            HP = hp;
            MP = mp;
            this.攻击力 = 攻击力;
            this.法术强度 = 法术强度;
            this.防御力 = 防御力;
            this.速度 = 速度;
            this.技能组 = 技能组;
            死亡标记 = false;
            状态 = 角色状态.正常;
            Buff池 = new List<Buff>();
        }

        public void AddBuff(Buff buff)
        {
            // 通过对比uuid检查是否有重复buff
            foreach (Buff b in Buff池)
            {
                if (b.UUID == buff.UUID)
                {
                    b.重复施加(buff);
                    return;
                }
            }
            Buff池.Add(buff);
        }

        public void 受到攻击伤害(伤害效果 damage)
        {
            if (damage.DamageType == 伤害类型.物理伤害)
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
            else if (damage.DamageType == 伤害类型.法术伤害)
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

            Console.WriteLine($"{Name} 获得了 {damage.Value} 点治疗");

            Console.WriteLine($"{Name} 剩余生命值：{HP}");
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
