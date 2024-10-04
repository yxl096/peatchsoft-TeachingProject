
namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 管理buff池的类
    /// </summary>
    class Buff池
    {
        private readonly Dictionary<string, Buff> 常规buff池 = [];
        private readonly LinkedList<属性变更buff> 属性buff池 = [];

        public void Add(Buff buff)
        {
            if (buff is 属性变更buff)
            {
                属性buff池.AddLast((属性变更buff)buff);
            }
            // 如果已经存在这个buff，那么调用buff的重复施加方法
            if (常规buff池.ContainsKey(buff.UUID))
            {
                常规buff池[buff.UUID].重复施加(buff);
            }
            else
            {
                buff.属性变更效果(this);
                常规buff池.Add(buff.UUID, buff);
            }
        }

        public void Remove(Buff buff, 角色 buff持有者)
        {
            // 调用buff的移除buff事件
            常规buff池[buff.UUID].移除buff事件(buff持有者);
            常规buff池.Remove(buff.UUID);
        }
        public void Remove(属性变更buff buff)
        {
            属性buff池.Remove(buff);
        }

        public void 回合开始效果(角色 buff持有者)
        {
            foreach (Buff buff in 常规buff池.Values)
                buff.回合开始效果(buff持有者);
        }
        public void 角色行动前效果(角色 buff持有者)
        {
            foreach (Buff buff in 常规buff池.Values)
                buff.角色行动前效果(buff持有者);
        }
        public void 角色行动后效果(角色 buff持有者)
        {
            foreach (Buff buff in 常规buff池.Values)
                buff.角色行动后效果(buff持有者);
        }
        public void 回合结束效果(角色 buff持有者)
        {
            foreach (Buff buff in 常规buff池.Values)
                buff.回合结束效果(buff持有者);
            foreach (属性变更buff buff in 属性buff池)
                buff.回合结束效果(buff持有者);
        }
        public bool 发动普通攻击效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            foreach (Buff buff in 常规buff池.Values)
                if (!buff.发动普通攻击效果(buff持有者, 攻击事件))
                    return false;
            return true;
        }
        public bool 受到普通攻击效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            foreach (Buff buff in 常规buff池.Values)
                if (buff.受到普通攻击效果(buff持有者, 攻击事件))
                    return false;
            return true;
        }
        public bool 发动技能效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            foreach (Buff buff in 常规buff池.Values)
                if (!buff.发动技能效果(buff持有者, 攻击事件))
                    return false;
            return true;
        }
        public bool 成为技能目标(角色 buff持有者, DamageInfo 攻击事件)
        {
            foreach (Buff buff in 常规buff池.Values)
                if (!buff.成为技能目标(buff持有者, 攻击事件))
                    return false;
            return true;
        }
        public bool 发动治疗效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            foreach (Buff buff in 常规buff池.Values)
                if (!buff.发动治疗效果(buff持有者, 攻击事件))
                    return false;
            return true;
        }
        public bool 受到治疗效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            foreach (Buff buff in 常规buff池.Values)
                if (!buff.受到治疗效果(buff持有者, 攻击事件))
                    return false;
            return true;
        }
        public bool 造成物理伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            foreach (Buff buff in 常规buff池.Values)
                if (!buff.造成物理伤害效果(buff持有者, 攻击事件))
                    return false;
            return true;
        }
        public bool 造成法术伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            foreach (Buff buff in 常规buff池.Values)
                if (!buff.造成法术伤害效果(buff持有者, 攻击事件))
                    return false;
            return true;
        }
        public bool 受到物理伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            foreach (Buff buff in 常规buff池.Values)
                if (!buff.受到物理伤害效果(buff持有者, 攻击事件))
                    return false;
            return true;
        }
        public bool 受到法术伤害效果(角色 buff持有者, DamageInfo 攻击事件)
        {
            foreach (Buff buff in 常规buff池.Values)
                if (!buff.受到法术伤害效果(buff持有者, 攻击事件))
                    return false;
            return true;
        }

        public int 计算Buff后的攻击力(int 攻击力)
        {
            foreach (属性变更buff buff in 属性buff池)
                攻击力 = buff.计算Buff后的攻击力(攻击力);
            return 攻击力;
        }
        public int 计算Buff后的防御力(int 防御力)
        {
            foreach (属性变更buff buff in 属性buff池)
                防御力 = buff.计算Buff后的防御力(防御力);
            return 防御力;
        }
        public int 计算Buff后的法术强度(int 法术强度)
        {
            foreach (属性变更buff buff in 属性buff池)
                法术强度 = buff.计算Buff后的法术强度(法术强度);
            return 法术强度;
        }
        public int 计算Buff后的速度(int 速度)
        {
            foreach (属性变更buff buff in 属性buff池)
                速度 = buff.计算Buff后的速度(速度);
            return 速度;
        }

        public 角色状态 获取角色状态(角色 buff持有者)
        {
            bool 禁止普攻 = false;
            bool 禁止技能 = false;
            bool 无法行动 = false;
            foreach (Buff buff in 常规buff池.Values)
            {
                角色状态 状态 = buff.获取角色状态(buff持有者);
                switch (状态)
                {
                    case 角色状态.正常:
                        break;

                    case 角色状态.无法行动:
                        无法行动 = true;
                        break;

                    case 角色状态.禁止普攻:
                        禁止普攻 = true;
                        break;

                    case 角色状态.禁止使用技能:
                        禁止技能 = true;
                        break;

                    case 角色状态.镇静:
                        return 角色状态.正常;
                }
            }
            if (无法行动)
                return 角色状态.无法行动;
            if (禁止普攻 && 禁止技能)
                return 角色状态.无法行动;
            if (禁止普攻)
                return 角色状态.禁止普攻;
            if (禁止技能)
                return 角色状态.禁止使用技能;

            return 角色状态.正常;
        }
    }
}
