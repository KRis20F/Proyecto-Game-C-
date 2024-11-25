class Magic : Player{
    public string attack { get; set; }
    public string speciallyAttack { get; set; }



    public Magic( int health, int level, int hability, string attack, string speciallyAttack) : base (health, level, hability)  {
        this.attack = attack;
        this.speciallyAttack = speciallyAttack;
    }
}