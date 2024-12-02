using JaratKezeloProject;

namespace TestJaratKezeloProject
{
    public class Tests
    {
        JaratKezelo jaratKezelo;

        [SetUp]
        public void Setup()
        {
            jaratKezelo = new JaratKezelo();
        }

        [Test]
        public void ujJarat_HelyesAdatokkal_NemDobExceptiont()
        {
            Assert.DoesNotThrow(() => jaratKezelo.ujJarat("123", "BUD", "LHR", DateTime.Now.AddHours(1)));
        }

        [Test]
        public void ujJarat_NullJaratSzammal_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.ujJarat(null, "BUD", "LHR", DateTime.Now.AddHours(1)));
        }

        [Test]
        public void ujJarat_UresJaratSzammal_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.ujJarat("", "BUD", "LHR", DateTime.Now.AddHours(1)));
        }

        [Test]
        public void ujJarat_NullRepterHonnan_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.ujJarat("123", null, "LHR", DateTime.Now.AddHours(1)));
        }

        [Test]
        public void ujJarat_UresRepterHonnan_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.ujJarat("123", "", "LHR", DateTime.Now.AddHours(1)));
        }

        [Test]
        public void ujJarat_NullRepterHova_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.ujJarat("123", "BUD", null, DateTime.Now.AddHours(1)));
        }

        [Test]
        public void ujJarat_UresRepterHova_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.ujJarat("123", "BUD", "", DateTime.Now.AddHours(1)));
        }

        [Test]
        public void ujJarat_IndulasElott_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.ujJarat("123", "BUD", "LHR", DateTime.Now.AddHours(-1)));
        }

        [Test]
        public void keses_HelyesAdatokkal_NemDobExceptiont()
        {
            jaratKezelo.ujJarat("123", "BUD", "LHR", DateTime.Now.AddHours(1));
            Assert.DoesNotThrow(() => jaratKezelo.keses("123", 10));
        }

        [Test]
        public void keses_NemLetezoJarat_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.keses("123", 10));
        }

        [Test]
        public void keses_NegativKeses_DobExceptiont()
        {
            jaratKezelo.ujJarat("123", "BUD", "LHR", DateTime.Now.AddHours(1));
            Assert.Throws<NegativKesesException>(() => jaratKezelo.keses("123", -10));
        }

        [Test]
        public void mikorIndul_HelyesAdatokkal_NemDobExceptiont()
        {
            jaratKezelo.ujJarat("123", "BUD", "LHR", DateTime.Now.AddHours(1));
            jaratKezelo.keses("123", 10);
            Assert.DoesNotThrow(() => jaratKezelo.mikorIndul("123"));
        }

        [Test]
        public void mikorIndul_NullJaratSzam_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.mikorIndul(null));
        }

        [Test]
        public void mikorIndul_UresJaratSzam_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.mikorIndul(""));
        }

        [Test]
        public void mikorIndul_NemLetezoJarat_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.mikorIndul("123"));
        }

        [Test]
        public void jaratokRepuloterrol_HelyesAdatokkal_NemDobExceptiont()
        {
            jaratKezelo.ujJarat("123", "BUD", "LHR", DateTime.Now.AddHours(1));
            Assert.DoesNotThrow(() => jaratKezelo.jaratokRepuloterrol("BUD"));
        }

        [Test]
        public void jaratokRepuloterrol_NullRepter_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.jaratokRepuloterrol(null));
        }

        [Test]
        public void jaratokRepuloterrol_UresRepter_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.jaratokRepuloterrol(""));
        }

        [Test]
        public void jaratokRepuloterrol_NemLetezoRepter_DobExceptiont()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.jaratokRepuloterrol("BUD"));
        }

        [Test]
        public void jaratokRepuloterrol_EgyJarat()
        {
            jaratKezelo.ujJarat("123", "BUD", "LHR", DateTime.Now.AddHours(1));
            Assert.AreEqual(1, jaratKezelo.jaratokRepuloterrol("BUD").Count);
        }

        [Test]
        public void jaratokRepuloterrol_TobbJarat()
        {
            jaratKezelo.ujJarat("123", "BUD", "LHR", DateTime.Now.AddHours(1));
            jaratKezelo.ujJarat("456", "BUD", "LHR", DateTime.Now.AddHours(1));
            Assert.AreEqual(2, jaratKezelo.jaratokRepuloterrol("BUD").Count);
        }

        [Test]
        public void jaratokRepuloterrol_NincsJarat()
        {
            jaratKezelo.ujJarat("123", "BUD", "LHR", DateTime.Now.AddHours(1));
            Assert.AreEqual(0, jaratKezelo.jaratokRepuloterrol("LHR").Count);
        }
    }
}