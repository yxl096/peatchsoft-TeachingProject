using 战斗小游戏;

Console.WriteLine("战斗模拟器开始");

// 创建双方单位

// 坦克桃
角色 桃酱 = new 角色(
    "桃酱",
    3500, // hp
    500, // mp
    150, // 攻击力
    100, // 法术强度
    160, // 防御力
    80, // 速度
    [new 普通攻击(伤害类型.物理), new 不动如山(114, 85)]
    );

// 牢饼平砍连击带顺劈
角色 牢饼 = new 角色(
    "牢饼",
    2500, // hp
    500, // mp
    200, // 攻击力
    60, // 法术强度
    150, // 防御力
    150, // 速度
    [new 普通攻击(伤害类型.物理), 
        new 饼饼突击(), new 见一个爱一个()]
    );

// 法刀希亚
角色 希亚 = new 角色(
    "希亚",
    2500, // hp
    1000, // mp
    100, // 攻击力
    200, // 法术强度
    100, // 防御力
    130, // 速度
    [new 普通攻击(伤害类型.法术, 85), new 防御力强化(), new 测试技能_核爆()]
    );

// 敌方

角色 史莱姆A = new (
    "史莱姆A",
    1500, // hp
    0, // mp
    50, // 攻击力
    50, // 法术强度
    50, // 防御力
    50, // 速度
    [new 普通攻击(伤害类型.物理), new 防御力强化()]
    );

角色 史莱姆B = new (
    "史莱姆B",
    1500, // hp
    0, // mp
    50, // 攻击力
    50, // 法术强度
    50, // 防御力
    50, // 速度
    [new 普通攻击(伤害类型.物理), new 防御力强化()]
    );

角色 史莱姆王 = new (
    "史莱姆王",
    5000, // hp
    1000, // mp
    150, // 攻击力
    80, // 法术强度
    100, // 防御力
    40, // 速度
    [new 普通攻击(伤害类型.物理), new 防御力强化()]
    );

战斗管理器 战斗管理 = 战斗管理器.GetInstance();

战斗管理.游戏开始(
    [桃酱, 牢饼, 希亚],
    [史莱姆A, 史莱姆B, 史莱姆王]
    );

// 开始战斗
Console.WriteLine();
Console.WriteLine("战斗开始");
Console.WriteLine();
while (true)
{
    // 计算行动顺序
    角色[] 行动顺序 = 战斗管理.计算行动顺序();

    // 逐个单位行动
    foreach (var 角色 in 行动顺序)
    {
        // 如果角色死亡，跳过本次循环
        if (角色.死亡标记)
        {
            continue;
        }

        // 先执行角色行动前效果，再判断是否可以行动
        if (角色.buff池.获取角色状态() == 角色状态.无法行动)
        {
            continue;
        }

        Console.WriteLine($"{角色.Name} 的回合");

        // 如果是玩家单位
        if (角色.IsPlayer)
        {
            // 玩家选择技能
            战斗管理.打印玩家可选技能(角色);
            技能 选择的技能;

            // 等待玩家输入，判断玩家选择是否合法
            while (true)
            {
                string? 玩家选择 = Console.ReadLine();
                if (int.TryParse(玩家选择, out int 技能id))
                {
                    // 通过合法性检查才可以释放技能
                    if(战斗管理.释放合法性检查(角色, 技能id))
                    {
                        选择的技能 = 角色.技能组[技能id-1];
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("请输入有效的数字！");
                }
                Console.WriteLine();
                Console.WriteLine("请选择技能：");
            }

            // 选择技能目标
            switch (选择的技能.有效目标)
            {
                case 允许目标.敌方单体:

                    // 选择敌方单位
                    角色 选择的目标;
                    角色[] 敌方单位 = 战斗管理.敌人;
                    战斗管理.打印可选的技能目标(敌方单位);

                    // 等待玩家输入，判断玩家选择是否合法
                    while (true)
                    {
                        string? 玩家选择 = Console.ReadLine();
                        if (int.TryParse(玩家选择, out int 技能id))
                        {
                            // 通过合法性检查才可以释放技能
                            if (技能id < 1 || 技能id > 敌方单位.Length)
                            {
                                Console.WriteLine("请输入有效的数字！");
                            }
                            else
                            {
                                选择的目标 = 敌方单位[技能id - 1];
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("请输入有效的数字！");
                        }
                        Console.WriteLine();
                        Console.WriteLine("请选择技能目标：");
                    }
                    选择的技能.使用技能(角色, [选择的目标]);
                    break;

                case 允许目标.敌方全体:
                    选择的技能.使用技能(角色, 战斗管理.敌人);
                    break;
                case 允许目标.自己:
                    选择的技能.使用技能(角色, [角色]);
                    break;
                case 允许目标.友方单体:

                    // 选择友方单位
                    角色 目标选择;
                    角色[] 友方单位 = 战斗管理.友方;
                    战斗管理.打印可选的技能目标(友方单位);

                    // 等待玩家输入，判断玩家选择是否合法
                    while (true)
                    {
                        string? 玩家选择 = Console.ReadLine();
                        if (int.TryParse(玩家选择, out int 技能id))
                        {
                            // 通过合法性检查才可以释放技能
                            if (技能id < 1 || 技能id > 友方单位.Length)
                            {
                                Console.WriteLine("请输入有效的数字！");
                            }
                            else
                            {
                                目标选择 = 友方单位[技能id - 1];
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("请输入有效的数字！");
                        }
                        Console.WriteLine();
                        Console.WriteLine("请选择技能目标：");
                    }
                    选择的技能.使用技能(角色, [目标选择]);
                    break;

                case 允许目标.友方全体:
                    选择的技能.使用技能(角色, 战斗管理.友方);
                    break;
            }

        }
        else
        {
            // ai会释放所有可用的技能，目标随机选择。
            foreach (var skill in 角色.技能组)
            {
                switch (skill.释放合法性检查(角色))
                {
                    case 技能状态.可用:
                        // 只有可用才往下走。
                        break;
                    case 技能状态.不可用:
                        continue;
                    case 技能状态.没有有效目标:
                        continue;
                    case 技能状态.MP不足:
                        continue;
                    case 技能状态.冷却中:
                        continue;
                    case 技能状态.被动技能:
                        continue;
                    default:
                        continue;
                }

                // 选择技能目标
                角色 选择的目标;
                Random random = new Random();
                int 随机数;

                switch (skill.有效目标)
                {
                    case 允许目标.敌方单体:
                        随机数 = random.Next(0, 战斗管理.友方.Length);
                        选择的目标 = 战斗管理.友方[随机数];
                        skill.使用技能(角色, [选择的目标]);
                        break;
                    case 允许目标.敌方全体:
                        skill.使用技能(角色, 战斗管理.友方);
                        break;
                    case 允许目标.自己:
                        skill.使用技能(角色, [角色]);
                        break;
                    case 允许目标.友方单体:
                        随机数 = random.Next(0, 战斗管理.敌人.Length);
                        选择的目标 = 战斗管理.敌人[随机数];
                        skill.使用技能(角色, [选择的目标]);
                        break;
                    case 允许目标.友方全体:
                        skill.使用技能(角色, 战斗管理.敌人);
                        break;
                }

            }
        }

        // 检查游戏结束
        bool 敌方全灭 = true;
        bool 友方全灭 = true;

        foreach (var unit in 战斗管理.敌人)
            敌方全灭 = 敌方全灭 && unit.死亡标记;

        foreach (var unit in 战斗管理.友方)
            友方全灭 = 友方全灭 && unit.死亡标记;

        if (友方全灭)
        {
            // 玩家失败
            Console.WriteLine("失败");

            // 游戏结束，释放资源
            战斗管理 = null;
            战斗管理器.游戏结束();
            return;
        }
        else if (敌方全灭)
        {
            // 玩家胜利
            Console.WriteLine("击败所有敌人，游戏胜利");

            // 游戏结束，释放资源
            战斗管理 = null;
            战斗管理器.游戏结束();
            return;
        }

        Console.WriteLine();

    }

    // 回合结束
    战斗管理.回合结束();
}
