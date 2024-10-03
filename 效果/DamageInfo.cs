
namespace 战斗小游戏
{
    /// <summary>
    /// Author: 桃
    /// Description: 伤害事件类，一次伤害事件可以包含多个伤害效果
    /// </summary>
    class DamageInfo
    {
        public LinkedList<伤害效果> 效果序列 { get; set; }

        public DamageInfo(伤害效果 damage)
        {
            效果序列 = new LinkedList<伤害效果>();
            效果序列.AddLast(damage);
        }

        public DamageInfo()
        {
            效果序列 = new LinkedList<伤害效果>();
        }

        public void AddDamageToLast(伤害效果 damage)
        {
            效果序列.AddLast(damage);
        }

        public void AddDamageToNext(伤害效果 damage)
        {
            效果序列.AddAfter(效果序列.First, damage);
        }

        public 伤害效果 GetDamage()
        {
            return 效果序列.First.Value;
        }

        public bool RemoveDamage()
        {
            效果序列.RemoveFirst();
            if (效果序列.Count == 0)
                return true;
            else
                return false;
        }
    }
}
