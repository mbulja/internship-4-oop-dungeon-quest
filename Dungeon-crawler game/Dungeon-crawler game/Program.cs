using System;

public class Hero
{
    public string Name { get; set; }
    public int MaxHP { get; set; }
    public int HP { get; set; }
    public int XP { get; set; }
    public int Damage { get; set; }

    public Hero(string name, int maxHP, int hp, int xp, int damage)
    {
        Name = name;
        MaxHP = maxHP;
        HP = hp;
        XP = xp;
        Damage = damage;
    }

    public void LevelUp(int hpIncrease, int damageIncrease)
    {
        MaxHP += hpIncrease;
        HP = MaxHP;
        Damage += damageIncrease;
    }

    public void Heal(int amount)
    {
        HP = Math.Min(MaxHP, HP + amount);
    }

    public int Attack()
    {
        return Damage;
    }

    public bool IsDead()
    {
        return HP <= 0;
    }
}

public class Monster
{
    public string MonsterType { get; set; }
    public int HP { get; set; }
    public int Damage { get; set; }
    public int XPValue { get; set; }

    public Monster(string monsterType, int hp, int damage, int xpValue)
    {
        MonsterType = monsterType;
        HP = hp;
        Damage = damage;
        XPValue = xpValue;
    }

    public void TakeDamage(int amount)
    {
        HP = Math.Max(0, HP - amount);
    }

    public bool IsDefeated()
    {
        return HP <= 0;
    }
}

public class Game
{
    public Hero Hero { get; set; }
    public int MonstersDefeated { get; set; }

    public void CreateHero(string name, int hp, int xp, int damage, string heroType)
    {
        Hero = new Hero(name, hp, xp, damage);
    }

    public Monster GenerateMonster()
    {
        Random random = new Random();
        
        return new Monster("Goblin", 20, 10, 10);
    }

    public void Battle(string action)
    {
       
    }

    public void LevelUp()
    {
        
    }

    public void Heal()
    {
        
    }

    public void Play()
    {
        
    }
}

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
       
    }
}
