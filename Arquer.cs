class Arquer : Player
{
    int speciallyHability { get; set; }

    public Arquer (string name, int health, int level, int hability, int speciallyHability):base (name, health, level, hability){
        this.speciallyHability = speciallyHability;
    }

    public override int Attack (){
        return base.Attack() + 3;
    }

    public int doubleAttack(int shift)
    {
        if ((shift + speciallyHability) >= 10)
        {
            Console.WriteLine("El Arquero realiza un ataque doble.");
            return Attack() + Attack();
        }
        return Attack();
    }
}