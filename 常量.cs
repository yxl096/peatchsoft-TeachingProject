﻿namespace 战斗小游戏
{
    enum 允许目标 { 敌方单体, 敌方全体, 友方单体, 友方全体, 自己 };
    enum 伤害类型 { 物理, 法术, 治疗, 法力恢复 };
    enum 攻击类型 { 普通攻击, 追击, 技能伤害, 附加伤害 };
    enum 技能状态 { 可用, 不可用, 被动技能, 没有有效目标, 冷却中, MP不足 };
    enum 角色属性 { 攻击力, 防御力, 法术强度, 速度 };

    // 镇静：不受debuff影响
    enum 角色状态 { 正常, 镇静, 无法行动, 禁止普攻, 禁止使用技能 };
    enum 游戏状态 { 敌方全灭, 友方全灭, 游戏继续 };

    class 常量
    {


    }
}
