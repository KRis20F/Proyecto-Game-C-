class Warrior : Player {

    public string attack { get; set; }
    public string speciallyAttack { get; set; }

    public Warrior( int health, int level, double hability, string attack, string speciallyAttack) : base (health, level, hability)  {
        this.attack = attack;
        this.speciallyAttack = speciallyAttack;
    }

    
}