public class Gun extends Weapon{
    private float caliber;
    private int fireRate;
    private String country;

    public Gun(String name, float range, float accuracy, float weight, float caliber, int fireRate, String country) {
        super(name, range, accuracy, weight);
        this.caliber = caliber;
        this.fireRate = fireRate;
        this.country = country;
    }

    public Gun() {
    }

    public float getCaliber() {
        return caliber;
    }

    public int getFireRate() {
        return fireRate;
    }

    public String getCountry() {
        return country;
    }

    public void setCaliber(float caliber) {
        this.caliber = caliber;
    }

    public void setFireRate(int fireRate) {
        this.fireRate = fireRate;
    }

    public void setCountry(String country) {
        this.country = country;
    }
}
