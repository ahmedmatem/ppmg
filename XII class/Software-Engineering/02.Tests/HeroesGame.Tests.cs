using HeroesGame.Contract;
using HeroesGame.Implementation.Hero;
using Moq;
using Moq.Protected;
using static HeroesGame.Constant.HeroConstants;
using static System.Net.Mime.MediaTypeNames;

namespace HeroesGame.HeroTests
{
    public class HeroTests
    {
        private IHero hero;

        [SetUp]
        public void Setup()
        {
            hero = new Warrior();
        }

        [Test]
        [TestCase(40)]
        [TestCase(100)]
        [TestCase(20)]
        public void TakeHitTest(int damage)
        {
            // Arange
            var hero = new Mage();
            //var damage = 40;

            // Act
            hero.TakeHit(damage);

            // Assert
            Assert.That(hero.Health, Is.EqualTo(InitialMaxHealth - damage + InitialArmor));
        }

        [Test]
        public void TakeHitTest_Combine([Values(10, 20, 30)]int damage)
        {
            // Arange
            //var hero = new Mage();
            //var damage = 40;

            // Act
            hero.TakeHit(damage);

            // Assert
            Assert.That(hero.Health, Is.EqualTo(InitialMaxHealth - damage + InitialArmor));
        }

        [Test]
        public void TakeHitTest_Range([Range(10, 20)] int damage)
        {
            // Arange
            //var hero = new Mage();
            //var damage = 40;

            // Act
            hero.TakeHit(damage);

            // Assert
            Assert.That(hero.Health, Is.EqualTo(InitialMaxHealth - damage + InitialArmor));
        }

        [Test]
        public void TakeHitTestNegativeDamaga()
        {
            // Arange
            //var hero = new Mage();
            var damage = -40;

            // Act

            // Assert
            var ex = Assert.Throws<ArgumentException>(() => { hero.TakeHit(damage); }, "Damage cannot be negative");
            Assert.That(ex.Message, Is.EqualTo("Negative damage not allowed"));
        }

        [Test]
        public void TakeHitByMoq()
        {
            var hero = new Mock<Mage>();
            hero.Protected()
                .Setup("LevelUp")
                .CallBase();
            var damage = 50;

            // Act
            hero.Object.TakeHit(damage);

            // Assert
            Assert.That(hero.Object.Health, Is.EqualTo(InitialMaxHealth - damage + InitialArmor));
        }

        [TearDown]
        public void TearDown()
        {

        }
        
    }
}