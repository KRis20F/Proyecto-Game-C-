class Warrior : Player {

    public int speciallyAttack { get; set; }

    public Warrior(string name, int health, int level, int hability, int speciallyAttack):base (name, health, level, hability){
        this.speciallyAttack = speciallyAttack;
    }

    public override int  Attack() {
        return base.Attack() + 2;
    }

    public bool canBlock(int shift)
    {
        return (shift - speciallyAttack) >= 3;
    }

    public void Bloc(int shift)
    {
        speciallyAttack = shift;
    }

    
}