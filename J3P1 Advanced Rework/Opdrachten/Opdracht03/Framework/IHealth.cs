namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;

public interface IHealth
{
    public int Health { get; set; }
    public void Die();
    public void TakeDamage(int pDamage);
}