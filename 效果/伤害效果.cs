
namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 伤害效果类，包含攻击者信息等
    /// Question: 伤害值允许任何人修改，但目标允许多个，需要修改
    /// </summary>
    class 伤害效果
    {
        public 角色 发动者 { get; set; }
        public 角色 承受者 { get; set; }
        public string 创建者 { get; set; }
        public string Message { get; set; }
        public 伤害类型 DamageType { get; set; }
        public 攻击类型 AttackType { get; set; }
        public int 基础伤害 { get; set; }
        public int 最终伤害 { get; set; }

        public 伤害效果(角色 发动者, 角色 承受者, string 创建者, string message,
            伤害类型 damageType, 攻击类型 attackType, int value)
        {
            this.发动者 = 发动者;
            this.承受者 = 承受者;
            this.创建者 = 创建者;
            Message = message;
            DamageType = damageType;
            AttackType = attackType;
            基础伤害 = value;
            最终伤害 = value;
        }

        public 伤害效果 Clone()
        {
            return new 伤害效果(发动者, 承受者, 创建者, Message, DamageType, AttackType, Value);
        }
    }
}
