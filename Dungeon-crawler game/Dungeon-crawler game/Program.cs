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
    public void TakeDamage(int amount)
    {
        HP -= amount;
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
    public Monster currentMonster { get; set; }
    public int MonstersDefeated { get; set; }

    public Game()
    {
        Hero = null;
    }

    public void CreateHero(string name, int hp, int xp, int damage, string heroType)
    {
        Hero = new Hero(name, hp, hp, xp, damage);
    }

    public Monster GenerateMonster()
    {
        Random random = new Random();
        return new Monster("Goblin", 20, 10, 10);
    }

    public void Battle(string action)
    {
        if (Hero != null)
        {
            int heroDamage = Hero.Attack();
            int monsterDamage = currentMonster.Damage;

            if (action == "Direct")
            {
                currentMonster.TakeDamage(heroDamage);
                Hero.TakeDamage(monsterDamage);
            }
            else if (action == "Side")
            {
                int sideDamage = heroDamage / 2;
                currentMonster.TakeDamage(sideDamage);
            }
            else if (action == "Counter")
            {
                int counterDamage = heroDamage * 2;
                Hero.TakeDamage(monsterDamage);
                currentMonster.TakeDamage(counterDamage);
            }

            if (Hero.IsDead())
            {
                Console.WriteLine("Hero is defeated!");
                // GameOver();
            }
            else if (currentMonster.IsDefeated())
            {
                Console.WriteLine("Monster is defeated!");
                // HandleVictory();
            }
        }
        else
        {
            Console.WriteLine("Hero is not created yet!");
        }
    }

    public void LevelUp()
    {
        int xpThreshold = 100;
        if (Hero != null && Hero.XP >= xpThreshold)
        {
            int hpIncrease = 20;
            int damageIncrease = 5;
            Hero.LevelUp(hpIncrease, damageIncrease);
            Hero.XP -= xpThreshold;
        }
    }

    public void Heal()
    {
        int healAmount = 30;
        if (Hero != null)
        {
            Hero.Heal(healAmount);
        }
    }

    public void Play()
    {
        for (int i = 0; i < 10; i++)
        {
            currentMonster = GenerateMonster();

            Battle("Direct");

            if (Hero != null)
            {
                if (Hero.XP >= 100)
                {
                    LevelUp();
                }

                if (Hero.HP < 50)
                {
                    Heal();
                }
            }
        }

        if (Hero != null && !Hero.IsDead())
        {
            Console.WriteLine("Victory! The hero defeated all monsters!");
        }
        else
        {
            Console.WriteLine("Defeat. The hero failed to defeat all monsters.");
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.CreateHero("HeroName", 100, 0, 10, "SomeType"); // Kreiraj heroja s određenim atributima
        game.Play(); // Pokreni igru
    }
}